class PlayGame extends Phaser.Scene{
constructor(){
    super({key: "PlayGame"});
}
    
create(){
    this.soundJump = this.sound.add("jump");
    this.soundJump.volume = 0.4;

    this.stepSound = this.sound.add("steps", {loop: "true"});
    this.stepSound.volume = 4;
    
    this.coinSound = this.sound.add('coinSound');
    this.coinSound.volume = 0.4;

    this.score = 0;
    this.scoreText = this.add.text(16,16, 'Score: 0', { font: '40px Impact', fill: '#000'});

    this.soundFX = this.sound.add("music", {loop: "true"});
    this.soundFX.volume = 0.1;
    this.soundFX.play();

    this.mountainGroup = this.add.group();
    this.platformGroup = this.add.group({
        removeCallback: function(platform){
            platform.scene.platformPool.add(platform)
        }
    });

    this.platformPool = this.add.group({
        removeCallback: function(platform){
            platform.scene.platformGroup.add(platform)
        }
    });

    this.coinGroup = this.add.group({
        removeCallback: function(coin){
            coin.scene.coinPool.add(coin)
        }
    });

    this.coinPool = this.add.group({
        removeCallback: function(coin){
            coin.scene.coinGroup.add(coin)
        }
    });

    this.fireGroup = this.add.group({
        removeCallback: function(fire){
            fire.scene.firePool.add(fire)
        }
    });

    this.firePool = this.add.group({
        removeCallback: function(fire){
            fire.scene.fireGroup.add(fire)
        }
    });

    this.addMountains()
    this.addedPlatforms = 0;
    this.playerJumps = 0;
    this.addPlatform(game.config.width, game.config.width / 2, game.config.height * gameOptions.platformVerticalLimit[1]);

    this.player = this.physics.add.sprite(gameOptions.playerStartPosition, game.config.height * 0.7, "player");
    this.player.setScale(0.15);
    this.player.setGravityY(gameOptions.playerGravity);
    this.player.setDepth(2);

    this.dying = false;

    this.platformCollider = this.physics.add.collider(this.player, this.platformGroup, function(){
        if(!this.player.anims.isPlaying){
            this.player.anims.play("run");
            this.stepSound.play();
        }
    }, null, this);
    this.physics.add.overlap(this.player, this.coinGroup, collectCoin, null, this);

    function collectCoin (player, coin){
        coin.disableBody(true,true);
        
        this.coinSound.play(); 
        this.score += 10;
        this.scoreText.setText('Score: ' + this.score);  

        this.tweens.add({
            targets: coin,
            y: coin.y - 100,
            alpha: 0,
            duration: 800,
            ease: "Cubic.easeOut",
            callbackScope: this,
            onComplete: function(){
                this.coinGroup.killAndHide(coin);
                this.coinGroup.remove(coin);               
            }
        });
    }

    this.physics.add.overlap(this.player, this.fireGroup, function(player, fire){           
        this.dying = true;
        this.player.anims.stop();
        this.player.setFrame(2);
        this.player.body.setVelocityY(-200);
        this.physics.world.removeCollider(this.platformCollider);           
    }, null, this);
    this.input.on("pointerdown", this.jump, this);
}

addMountains(){
    let rightmostMountain = this.getRightmostMountain();
    if(rightmostMountain < game.config.width * 2){
        let mountain = this.physics.add.sprite(rightmostMountain + Phaser.Math.Between(100, 350), game.config.height + Phaser.Math.Between(0, 100), "mountain");
        mountain.setOrigin(0.5, 1);
        mountain.body.setVelocityX(gameOptions.mountainSpeed * -1)
        this.mountainGroup.add(mountain);
        if(Phaser.Math.Between(0, 1)){
            mountain.setDepth(1);
        }
        mountain.setFrame(Phaser.Math.Between(0, 3))
        this.addMountains()
    }
}

getRightmostMountain(){
    let rightmostMountain = -200;
    this.mountainGroup.getChildren().forEach(function(mountain){
        rightmostMountain = Math.max(rightmostMountain, mountain.x);
    })
    return rightmostMountain;
}

addPlatform(platformWidth, posX, posY){
    this.addedPlatforms ++;
    let platform;

    if(this.platformPool.getLength()){
        platform = this.platformPool.getFirst();
        platform.x = posX;
        platform.y = posY;
        platform.active = true;
        platform.visible = true;
        this.platformPool.remove(platform);
        let newRatio =  platformWidth / platform.displayWidth;
        platform.displayWidth = platformWidth;
        platform.tileScaleX = 1 / platform.scaleX;
    }

    else{
        platform = this.add.tileSprite(posX, posY, platformWidth, 32, "platform");
        this.physics.add.existing(platform);
        platform.body.setImmovable(true);
        platform.body.setVelocityX(Phaser.Math.Between(gameOptions.platformSpeedRange[0], gameOptions.platformSpeedRange[1]) * -1);
        platform.setDepth(2);
        this.platformGroup.add(platform);
    }

    this.nextPlatformDistance = Phaser.Math.Between(gameOptions.spawnRange[0], gameOptions.spawnRange[1]);

    if(this.addedPlatforms > 1){
        if(Phaser.Math.Between(1, 100) <= gameOptions.coinPercent){
            if(this.coinPool.getLength()){
                let coin = this.coinPool.getFirst();
                coin.x = posX;
                coin.y = posY - 50;
                coin.alpha = 1;
                coin.active = true;
                coin.visible = true;
                this.coinPool.remove(coin);
            }

            else{
                let coin = this.physics.add.sprite(posX, posY - 50, "coin");
                coin.setImmovable(true);
                coin.setVelocityX(platform.body.velocity.x);
                coin.anims.play("rotate");
                coin.setDepth(2);
                this.coinGroup.add(coin);
            }
        }

        if(Phaser.Math.Between(1, 100) <= gameOptions.firePercent){
            if(this.firePool.getLength()){
                let fire = this.firePool.getFirst();
                fire.x = posX - platformWidth / 2 + Phaser.Math.Between(1, platformWidth);
                fire.y = posY - 46;
                fire.alpha = 1;
                fire.active = true;
                fire.visible = true;
                this.firePool.remove(fire);
            }
            else{
                let fire = this.physics.add.sprite(posX - platformWidth / 2 + Phaser.Math.Between(1, platformWidth), posY - 46, "fire");
                fire.setImmovable(true);
                fire.setVelocityX(platform.body.velocity.x);
                fire.setSize(8, 2, true)
                fire.anims.play("burn");
                fire.setDepth(2);
                this.fireGroup.add(fire);
            }
        }
    }
}

jump(){
    this.stepSound.stop();
    if((!this.dying) && (this.player.body.touching.down || (this.playerJumps > 0 && this.playerJumps < gameOptions.jumps))){
        if(this.player.body.touching.down){
            this.playerJumps = 0;
        }
        this.player.setVelocityY(gameOptions.jumpForce * -1);
        this.playerJumps ++;
        this.soundJump.play();

        this.player.anims.stop();
    }
}

update(){
    if(this.player.y > game.config.height){
        this.stepSound.stop();
        this.soundFX.stop();
        this.scene.start("gameover");
    }

    this.player.x = gameOptions.playerStartPosition;

    let minDistance = game.config.width;
    let rightmostPlatformHeight = 0;
    this.platformGroup.getChildren().forEach(function(platform){
        let platformDistance = game.config.width - platform.x - platform.displayWidth / 2;
       
        if(platformDistance < minDistance){
            minDistance = platformDistance;
            rightmostPlatformHeight = platform.y;
        }

        if(platform.x < - platform.displayWidth / 2){
            this.platformGroup.killAndHide(platform);
            this.platformGroup.remove(platform);
        }
    }, this);

    this.coinGroup.getChildren().forEach(function(coin){
        if(coin.x < - coin.displayWidth / 2){
            this.coinGroup.killAndHide(coin);
            this.coinGroup.remove(coin);
        }
    }, this);

    this.fireGroup.getChildren().forEach(function(fire){
        if(fire.x < - fire.displayWidth / 2){
            this.fireGroup.killAndHide(fire);
            this.fireGroup.remove(fire);
        }
    }, this);

    this.mountainGroup.getChildren().forEach(function(mountain){
        if(mountain.x < - mountain.displayWidth){
            let rightmostMountain = this.getRightmostMountain();
            mountain.x = rightmostMountain + Phaser.Math.Between(100, 350);
            mountain.y = game.config.height + Phaser.Math.Between(0, 100);
            mountain.setFrame(Phaser.Math.Between(0, 3))
            if(Phaser.Math.Between(0, 1)){
                mountain.setDepth(1);
            }
        }
    }, this);

    if(minDistance > this.nextPlatformDistance){
        let nextPlatformWidth = Phaser.Math.Between(gameOptions.platformSizeRange[0], gameOptions.platformSizeRange[1]);
        let platformRandomHeight = gameOptions.platformHeighScale * Phaser.Math.Between(gameOptions.platformHeightRange[0], gameOptions.platformHeightRange[1]);
        let nextPlatformGap = rightmostPlatformHeight + platformRandomHeight;
        let minPlatformHeight = game.config.height * gameOptions.platformVerticalLimit[0];
        let maxPlatformHeight = game.config.height * gameOptions.platformVerticalLimit[1];
        let nextPlatformHeight = Phaser.Math.Clamp(nextPlatformGap, minPlatformHeight, maxPlatformHeight);
        this.addPlatform(nextPlatformWidth, game.config.width + nextPlatformWidth / 2, nextPlatformHeight);
    }
}
}