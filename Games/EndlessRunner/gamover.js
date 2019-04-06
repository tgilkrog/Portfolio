class gameover extends Phaser.Scene{
    constructor(){
        super({key: 'gameover'});
    }

    preload(){
        this.load.audio('gameoverMusic', 'assets/sounds/Strangeness.mp3');
    }

    create(){
        this.gameoverMusic = this.sound.add("gameoverMusic", {loop: "true"});
        this.gameoverMusic.play();

        this.startButton = this.add.text(450, 200, 'Tap here to play again', { font: '50px Impact', fill: '#000' })
        .setInteractive()
        .on('pointerdown', () => this.updateClickButton() )
        .on('pointerover', () => this.enterButtonHoverState() )
        .on('pointerout', () => this.enterButtonRestState() );

        this.mainmenuButton = this.add.text(425, 400, 'Tap here to go to Main Menu', { font: '50px Impact', fill: '#000' })
        .setInteractive()
        .on('pointerdown', () => this.updateMenuButton() )
        .on('pointerover', () => this.menuHoverState() )
        .on('pointerout', () => this.menuRestState() );
    }

    updateClickButton(){
        this.gameoverMusic.stop();
        this.scene.start("PlayGame");
    }

    updateMenuButton(){
        this.gameoverMusic.stop();
        this.scene.start("MainMenu");
    }

    enterButtonHoverState(){
        this.startButton.setStyle({fill: '#ff0'});
    }

    enterButtonRestState(){
        this.startButton.setStyle({fill: '#000'});
    }

    menuHoverState(){
        this.mainmenuButton.setStyle({fill: '#ff0'});
    }

    menuRestState(){
        this.mainmenuButton.setStyle({fill: '#000'});
    }
}