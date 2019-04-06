class MainMenu extends Phaser.Scene{
    constructor(){
        super({key: 'MainMenu'});
    }

    preload(){
        this.load.audio('menuSong', 'assets/sounds/menuSong.mp3');
    }

    create(){
        this.scene.backgroundColor = '#000';
        this.songs = this.sound.add("menuSong", {loop: "true"});
        this.songs.play();

        this.text = this.add.text(425, 100, "Welcome to Running Girl", {font: "50px Impact", fill: '#0F0'});
        //this.welcome = this.add.text(500, 400, "Press Enter to Start", {font: "30px Impact"});

        var tween = this.tweens.add({
            targets: this.text,
            x:425,
            y:300,
            duration: 2000,
            ease: "Elastic",
            easeParams: [1.5,0.5],
            delay: 0
        }, this);

        this.input.keyboard.on('keyup', function(e){
            if(e.key == "Enter"){
                this.songs.stop();
                this.scene.start("PreloadGame");
            }
        }, this);

        this.startButton = this.add.text(450, 400, 'Tap here to start game', { font: '50px Impact', fill: '#000' })
        .setInteractive()
        .on('pointerdown', () => this.updateClickButton() )
        .on('pointerover', () => this.enterButtonHoverState() )
        .on('pointerout', () => this.enterButtonRestState() );
    }

    updateClickButton(){
        this.songs.stop();
        this.scene.start("PreloadGame");
    }

    enterButtonHoverState(){
        this.startButton.setStyle({fill: '#ff0'});
    }

    enterButtonRestState(){
        this.startButton.setStyle({fill: '#000'});
    }
}
