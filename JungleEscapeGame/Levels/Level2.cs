using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Extentions;
using GameFrameWork.Movements;
using System.Collections.Generic;
using System.Drawing;

namespace JungleEscapeGame.Levels
{
    public class Level2 : ILevel
    {
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }
        public List<Enemy> Enemies { get; } = new();
        public List<Bullet> Bullets { get; } = new List<Bullet>();

        public Bitmap BackgroundImage => Properties.Resources.bg2;

        public void Load(Game game)
        {

            // Clear previous level data if any
            game.Objects.Clear();
            Enemies.Clear();
            Bullets.Clear();

            float worldWidth = 5000f; // Made Level 2 a bit longer
            float worldHeight = 500f;
            float floorHeight = 64f;
            float groundY = worldHeight - floorHeight;




            // ================= FLOOR =================

            game.AddObject(new GameObject
            {
                Name = "Floor",
                Position = new PointF(0, groundY + 15),
                Size = new SizeF(worldWidth, floorHeight),
                IsRigidBody = true,
                Visible = false
            });


            // ================= BOUNDARIES = start =================

            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(0, 0),
                Size = new SizeF(10, worldHeight),
                IsRigidBody = true,
                Visible = false
            });

            // ================= BOUNDARIES = end =================

            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(4500, 0),
                Size = new SizeF(10, worldHeight),
                IsRigidBody = true,
                Visible = false
            });


            // ================= PLAYER =================
            Player = new Player
            {
                Name = "Player",
                Position = new PointF(100, groundY - 130),
                Size = new SizeF(45, 50),
                Sprite = Properties.Resources.player,
                HasPhysics = true
            };
            Player.AddMovement(new KeyboardMovement(5)); // Slightly faster for Level 2
            Player.AddMovement(new JumpingMovement(17f)); // Slightly higher jump
            game.AddObject(Player);



            // ================= ENEMIES =================

            AddEnemy(game, Properties.Resources.enemy2, 500, groundY - 60);
            AddEnemy(game, Properties.Resources.enemy2, 1600, groundY - 60);
            AddEnemy(game, Properties.Resources.enemy3, 1350, groundY - 60);
            //AddEnemy(game, Properties.Resources.enemy3, 1450, groundY - 60);


            // Example: Adding a ghost that haunts the middle area

            AddGhost(game, Properties.Resources.ghost, 300, 50, 200f, 1200f, 20f, 350f, 5f);

            AddGhost(game, Properties.Resources.ghost, 1400, 150, 1300f, 2200f, 20f, 350f, 4f);
            AddGhost(game, Properties.Resources.ghost, 1400, 150, 1300f, 2200f, 20f, 350f, 4f);

            //// Example: Adding a second, faster ghost near the end of the level


            // ================= Boxes =================

            CreateBox(game, 230, groundY - 60);
            CreateBox(game, 285, groundY - 60);
            CreateBox(game, 255, groundY - 120);


            CreateBox(game, 880, groundY - 60);
            CreateBox(game, 941, groundY - 60);
            CreateBox(game, 941, groundY - 120);



            CreateBox(game, 1692, groundY - 60);
            CreateBox(game, 1692, groundY - 120);
            CreateBox(game, 1692, groundY - 180);
            CreateBox(game, 1752, groundY - 60);
            CreateBox(game, 1752, groundY - 120);
            CreateBox(game, 1812, groundY - 60);




            // ================= NEW PLATFORM LAYOUT (Verticality) =================



            // Staircase effect
            CreateBrick(game, 400, groundY - 100);
            CreateBrick(game, 600, groundY - 200);
            CreateBrick(game, 870, groundY - 280);


            // "Bridge" Platforms

            CreateBrick(game, 1000, groundY - 90);
            CreateBrick(game, 1500, groundY - 90);




            // High Platform with Key

            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(1250, groundY - 250),
                Size = new SizeF(200, 200),
                Sprite = Properties.Resources.plus,
                IsRigidBody = true
            });




            // ================= KEY (Placed Higher) =================
            game.AddObject(new GameObject
            {
                Name = "Key",
                Position = new PointF(1320, groundY - 67),
                Size = new SizeF(35, 35),
                Sprite = Properties.Resources.key,
                IsRigidBody = false,
                HasPhysics = false
            });




           //================= COINS =================

            for (int i = 0; i < 10; i++)
            {
                game.AddObject(new GameObject
                {
                    Name = "Coin",
                    Position = new PointF(500 + (i * 180), groundY - 150 - (i % 2 * 50)),
                    Size = new SizeF(20, 20),
                    Sprite = Properties.Resources.coin,
                    IsRigidBody = false,
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

            // ================= EXIT =================
            game.AddObject(new GameObject
            {
                Name = "Exit",
                Position = new PointF(worldWidth - 200, groundY - 250),
                Size = new SizeF(200, 250),
                Sprite = Properties.Resources.exit,
                IsRigidBody = true
            });

            // Switch to Level 2 Music
            Game.Audio.Stop("level1_music");
                Game.Audio.Play("level2_music");
        }


        // Helper methods to keep code clean
        private void AddEnemy(Game game, Bitmap sprite, float x, float y)
        {
            var e = new Enemy
            {
                Name = "Enemy",
                Sprite = sprite,
                Position = new PointF(x, y),
                Movement = new PatrolMovement(0, 2500),
                Size = new SizeF(80, 60),
                HasPhysics = true
            };
            Enemies.Add(e);
            game.AddObject(e);
        }

        private void AddGhost(Game game, Bitmap sprite, float startX, float startY, float minX, float maxX, float minY, float maxY, float speed)
        {
            var ghost = new Enemy
            {
                Name = "Enemy",
                Sprite = sprite,
                Position = new PointF(startX, startY),
                Size = new SizeF(60, 60),
                HasPhysics = false, // Ghost flies
                IsRigidBody = false,
                Movement = new RandomPatrolMovement(minX, maxX, minY, maxY, speed)
            };

            Enemies.Add(ghost);
            game.AddObject(ghost);
        }


        private void CreateBox(Game game, float x, float y)
        {
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(x, y),
                Size = new SizeF(60, 60),
                Sprite = Properties.Resources.woodBox,
                IsRigidBody = true
            });
        }

        private void CreateBrick(Game game, float x, float y)
        {
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(x, y),
                Size = new SizeF(200, 40),
                Sprite = Properties.Resources.horizontalBrick,
                IsRigidBody = true
            });
        }

        public void UpdateBullets(GameTime gameTime, Game game)
        {
            if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.Space))
            {
                var newBullet = Player.Fire();
                if (newBullet != null)
                {
                    Bullets.Add(newBullet);
                    game.AddObject(newBullet);
                }
            }
            foreach (var b in Bullets) b.Update(gameTime);
            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                if (!Bullets[i].IsActive) Bullets.RemoveAt(i);
            }
        }
    }
}