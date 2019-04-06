let game;
            let gameOptions = {
                platformSpeedRange: [300, 300],
                mountainSpeed: 80,
                spawnRange: [80, 300],
                platformSizeRange: [90, 300],
                platformHeightRange: [-5, 5],
                platformHeighScale: 20,
                platformVerticalLimit: [0.4, 0.8],
                playerGravity: 900,
                jumpForce: 400,
                playerStartPosition: 200,
                jumps: 2,
                coinPercent: 50,
                firePercent: 25
            }
            
            window.onload = function() {
                let gameConfig = {
                    type: Phaser.AUTO,
                    width: 1334,
                    height: 750,
                    scene: [MainMenu, PreloadGame, PlayGame, gameover],
                    backgroundColor: 0x0c88c7,
                    physics: {
                        default: "arcade"
                    }
                }
                game = new Phaser.Game(gameConfig);
                window.focus();

            }