class PreloadGame extends Phaser.Scene{
    constructor(){
        super({key:"PreloadGame"});
    }

    preload(){
        this.load.image("platform", "assets/platform2.png");

        this.load.image("player", "assets/Player/run1.png");

        this.load.spritesheet("coin", "assets/coin.png", {
            frameWidth: 20,
            frameHeight: 20
        });

        this.load.spritesheet("fire", "assets/fire.png", {
            frameWidth: 40,
            frameHeight: 70
        });

        this.load.spritesheet("mountain", "assets/mountain.png", {
            frameWidth: 512,
            frameHeight: 512
        });

        this.load.image("run1", "assets/Player/Run1.png");
        this.load.image("run2", "assets/Player/Run2.png");
        this.load.image("run3", "assets/Player/Run3.png");
        this.load.image("run4", "assets/Player/Run4.png");
        this.load.image("run5", "assets/Player/Run5.png");
        this.load.image("run6", "assets/Player/Run6.png");
        this.load.image("run7", "assets/Player/Run7.png");
        this.load.image("run8", "assets/Player/Run8.png");
        this.load.image("run9", "assets/Player/Run9.png");
        this.load.image("run10", "assets/Player/Run10.png");
        this.load.image("run11", "assets/Player/Run11.png");
        this.load.image("run12", "assets/Player/Run12.png");
        this.load.image("run13", "assets/Player/Run13.png");
        this.load.image("run14", "assets/Player/Run14.png");
        this.load.image("run15", "assets/Player/Run15.png");
        this.load.image("run16", "assets/Player/Run16.png");
        this.load.image("run17", "assets/Player/Run17.png");
        this.load.image("run18", "assets/Player/Run18.png");
        this.load.image("run19", "assets/Player/Run19.png");
        this.load.image("run20", "assets/Player/Run20.png");

        this.load.audio('music', 'assets/sounds/mayhem.mp3');
        this.load.audio('mountain', 'assets/sounds/mount.wav');
        this.load.audio('jump', 'assets/sounds/jump.wav');
        this.load.audio('steps', 'assets/sounds/woodstep.wav');
        this.load.audio('coinSound', 'assets/sounds/coin.wav');
    }

    create(){       
        this.anims.create({
            key: "run32",
            frames: this.anims.generateFrameNumbers("player", {
                start: 0,
                end: 1
            }),
            frameRate: 8,
            repeat: -1
        });

        this.anims.create({
            key: "run",
            frames: [
                {key: "run1"},
                {key: "run2"},
                {key: "run3"},
                {key: "run4"},
                {key: "run5"},
                {key: "run6"},
                {key: "run7"},
                {key: "run8"},
                {key: "run9"},
                {key: "run10"},
                {key: "run11"},
                {key: "run12"},
                {key: "run13"},
                {key: "run14"},
                {key: "run15"},
                {key: "run16"},
                {key: "run17"},
                {key: "run18"},
                {key: "run19"},
                {key: "run20"},
            ],
            frameRate: 20,
            repeat: -1
        });

        this.anims.create({
            key: "rotate",
            frames: this.anims.generateFrameNumbers("coin", {
                start: 0,
                end: 5
            }),
            frameRate: 15,
            yoyo: true,
            repeat: -1
        });

        this.anims.create({
            key: "burn",
            frames: this.anims.generateFrameNumbers("fire", {
                start: 0,
                end: 4
            }),
            frameRate: 15,
            repeat: -1
        });

        this.scene.start("PlayGame");
    }
}
