using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Movements;
using System.Drawing;

namespace JungleEscapeGame.Levels
{
    public class Level1
    {
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }

   
        public void Load(Game game)
        {
            float worldWidth = 2500f;
            float worldHeight = 500f;
            float floorHeight = 64f;
            float groundY = worldHeight - floorHeight;

            // ================= PLAYER =================

            Player = new Player
            {
                Position = new PointF(100, groundY - 50),
                Size = new SizeF(45, 50),
                Sprite = Properties.Resources.player,
                HasPhysics = true
            };
            Player.AddMovement(new KeyboardMovement(4));
            Player.AddMovement(new JumpingMovement(12f));
            game.AddObject(Player);

            // ================= ENEMIES =================

            Enemy = new Enemy
            {
                Sprite = Properties.Resources.enemy1,
                Position = new PointF(380, groundY - 60),
                Movement = new PatrolMovement(380, 990),
                Size = new SizeF(80, 60),
                IsRigidBody = true,
                HasPhysics = true
            };
            game.AddObject(Enemy);



            //game.AddObject(new Enemy
            //{
            //    Sprite = Properties.Resources.enemy2,
            //    Position = new PointF(970, groundY - 60),
            //    Size = new SizeF(80, 60),
            //    HasPhysics = true,
            //    IsRigidBody = true,
            //    Movement = new PatrolMovement(970, 1600)
            //});

            //game.AddObject(new Enemy
            //{
            //    Sprite = Properties.Resources.enemy3,
            //    Position = new PointF(1100, groundY - 60),
            //    Size = new SizeF(80, 60),
            //    HasPhysics = true,
            //    IsRigidBody = true,
            //    Movement = new PatrolMovement(1050, 1600)
            //});

            // ================= FLOOR =================
            game.AddObject(new GameObject
            {
                Position = new PointF(0, groundY),
                Size = new SizeF(worldWidth, floorHeight),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true,
                Visible = false
            });


            // ================= LEFT WALL (BOUNDARY) =================

            game.AddObject(new GameObject
            {
                Position = new PointF(0, 0),
                Size = new SizeF(10, worldHeight),
                IsRigidBody = true,
                Visible = false
            });


            // ================= PLATFORMS =================

            game.AddObject(new GameObject
            {
                Position = new PointF(450, groundY - 170),
                Size = new SizeF(250, 100),
                Sprite = Properties.Resources.horizontalBrick,
                IsRigidBody = true
            });

            game.AddObject(new GameObject
            {
                Position = new PointF(800, groundY - 170),
                Size = new SizeF(250, 100),
                Sprite = Properties.Resources.horizontalBrick,
                IsRigidBody = true
            });


            game.AddObject(new GameObject
            {
                Position = new PointF(1370, groundY - 150),
                Size = new SizeF(250, 100),
                Sprite = Properties.Resources.plus,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(1680, groundY - 150),
                Size = new SizeF(250, 100),
                Sprite = Properties.Resources.plus,
                IsRigidBody = true
            });




            // ================= Boxes =================

            game.AddObject(new GameObject
            {
                Position = new PointF(226, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(300, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(300, groundY - 128),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });



            game.AddObject(new GameObject
            {
                Position = new PointF(1100, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(1164, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(1132, groundY - 128),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });


            game.AddObject(new GameObject
            {
                Position = new PointF(2000, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(2064, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(2064, groundY - 128),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });


            game.AddObject(new GameObject
            {
                Position = new PointF(2128, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(2128, groundY - 128),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Position = new PointF(2128, groundY - 192),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });


            // ================= Key  =================


                game.AddObject(new GameObject
                {
                    Name = "Key", // This is the secret! Use a Name or Tag property
                    Position = new PointF(1600, groundY - 100),
                    Size = new SizeF(35, 35),
                    Sprite = Properties.Resources.key,
                    IsRigidBody = false, // Set to false so the player can walk through it
                    HasPhysics = false
                });


            // ================= COINS (Soul Shards) =================


            for (int i = 1; i <= 7; i++)
            {
                game.AddObject(new GameObject
                {
                    Name = "Coin", // This is the secret! Use a Name or Tag property
                    Position = new PointF(400+(i*80), groundY - 50),
                    Size = new SizeF(20, 20),
                    Sprite = Properties.Resources.coin,
                    IsRigidBody = false, // Set to false so the player can walk through it
                    HasPhysics = false,
                    
                });
            }


            for (int i = 1; i <= 8; i++)
            {
                game.AddObject(new GameObject
                {
                    Name = "Coin", // This is the secret! Use a Name or Tag property
                    Position = new PointF(1250+(i*80), groundY - 35),
                    Size = new SizeF(20, 20),
                    Sprite = Properties.Resources.coin,
                    IsRigidBody = false, // Set to false so the player can walk through it
                    HasPhysics = false
                });
            }


            // ================= EXIT =================
            game.AddObject(new GameObject
            {
                Name = "Exit",
                Position = new PointF(worldWidth - 200, groundY - 250),
                Size = new SizeF(200, 250),
                Sprite = Properties.Resources.exit,
                IsRigidBody = true
            });
        }

    }
}