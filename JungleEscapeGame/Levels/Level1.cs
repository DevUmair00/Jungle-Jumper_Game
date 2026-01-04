using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Extentions;
using GameFrameWork.Movements;
using System.Drawing;

namespace JungleEscapeGame.Levels
{
    public class Level1
    {
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }

        public List<Enemy> Enemies { get; } = new();

        public List<Bullet> Bullets { get; } = new List<Bullet>();


        public void Load(Game game)
        {
            float worldWidth = 2500f;
            float worldHeight = 500f;
            float floorHeight = 64f;
            float groundY = worldHeight - floorHeight;

            // ================= PLAYER =================

            Player = new Player
            {
                Name = "Player",
                Position = new PointF(100, groundY - 130),
                Size = new SizeF(45, 50),
                Sprite = Properties.Resources.player,
                HasPhysics = true
            };
            Player.AddMovement(new KeyboardMovement(4));
            Player.AddMovement(new JumpingMovement(16f));
            game.AddObject(Player);

            // ================= ENEMIES =================

            Enemies.Add(new Enemy
            {
                Name = "Enemy",
                Sprite = Properties.Resources.enemy1,
                Position = new PointF(305, groundY - 60),
                Movement = new PatrolMovement(0, 2500),
                Size = new SizeF(80, 60),
                HasPhysics = true
            });

            Enemies.Add(new Enemy
            {
                Name = "Enemy",
                Sprite = Properties.Resources.enemy1,
                Position = new PointF(1265, groundY - 60),
                Movement = new PatrolMovement(0, 2500),
                Size = new SizeF(80, 60),
                HasPhysics = true
            });

            foreach (var e in Enemies)
                game.AddObject(e);






            // ================= FLOOR =================
            
            game.AddObject(new GameObject
            {
                Name = "Floor",
                Position = new PointF(0, groundY),
                Size = new SizeF(worldWidth, floorHeight),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true,
                Visible = false
            });


            // ================= LEFT WALL (Start  BOUNDARY) =================

            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(0, 0),
                Size = new SizeF(10, worldHeight),
                IsRigidBody = true,
                Visible = false
            });


            // ================= PLATFORMS =================

            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(440, groundY - 170),
                Size = new SizeF(250, 100),
                Sprite = Properties.Resources.horizontalBrick,
                IsRigidBody = true
            });

            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(760, groundY - 170),
                Size = new SizeF(250, 100),
                Sprite = Properties.Resources.horizontalBrick,
                IsRigidBody = true
            });




            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(1370, groundY - 180),
                Size = new SizeF(250, 100),
                Sprite = Properties.Resources.plus,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(1685, groundY - 180),
                Size = new SizeF(250, 100),
                Sprite = Properties.Resources.plus,
                IsRigidBody = true
            });




            // ================= Boxes =================

            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(226, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(300, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(300, groundY - 128),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });





            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(1170, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(1234, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(1201, groundY - 128),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });






            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(2000, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(2064, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(2064, groundY - 128),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true,

            });


            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(2128, groundY - 64),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true,
                
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(2128, groundY - 128),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });
            game.AddObject(new GameObject
            {
                Name = "Wall",
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
                    Name = "Coin", // Tag property
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


        public void UpdateBullets(GameTime gameTime, Game game)
        {
            // Spawn bullets
            if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.Space))
            {
                var newBullet = Player.Fire();
                if (newBullet != null)
                {
                    Bullets.Add(newBullet);
                    game.AddObject(newBullet); // Add to Game's general object list
                }
            }

            // Update bullet positions (optional, because Game.Update already updates them)
            foreach (var b in Bullets)
            {
                b.Update(gameTime);
            }


            // Cleanup bullets that are inactive
            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                if (!Bullets[i].IsActive)
                    Bullets.RemoveAt(i);
            }
        }
    }
}