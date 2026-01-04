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
        public List<Enemy> Enemies { get; } = new();
        public List<Bullet> Bullets { get; } = new List<Bullet>();

        public void Load(Game game)
        {
            // Clear previous level data if any
            game.Objects.Clear();
            Enemies.Clear();
            Bullets.Clear();

            float worldWidth = 3500f; // Made Level 2 a bit longer
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
            Player.AddMovement(new KeyboardMovement(5)); // Slightly faster for Level 2
            Player.AddMovement(new JumpingMovement(17f)); // Slightly higher jump
            game.AddObject(Player);



            // ================= ENEMIES (Updated for Level 2) =================

            AddEnemy(game, Properties.Resources.enemy2, 500, groundY - 60, 400, 900);
            AddEnemy(game, Properties.Resources.enemy2, 1100, groundY - 60, 1000, 1500);
            AddEnemy(game, Properties.Resources.enemy3, 1800, groundY - 60, 1600, 2200);


            // ================= FLOOR =================

            game.AddObject(new GameObject
            {
                Name = "Floor",
                Position = new PointF(0, groundY),
                Size = new SizeF(worldWidth, floorHeight),
                IsRigidBody = true,
                Visible = false
            });

            // ================= BOUNDARIES = sender =================
            game.AddObject(new GameObject { Name = "Wall", Position = new PointF(0, 0), Size = new SizeF(10, worldHeight), IsRigidBody = true, Visible = false });

            // ================= NEW PLATFORM LAYOUT (Verticality) =================

            // Staircase effect
            CreateBrick(game, 400, groundY - 100);
            CreateBrick(game, 600, groundY - 200);
            CreateBrick(game, 850, groundY - 280);

            // High Platform with Key
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(1200, groundY - 250),
                Size = new SizeF(300, 40),
                Sprite = Properties.Resources.plus,
                IsRigidBody = true
            });

            // "Bridge" Platforms
            CreateBrick(game, 1700, groundY - 180);
            CreateBrick(game, 2000, groundY - 180);

            // ================= KEY (Placed Higher) =================
            game.AddObject(new GameObject
            {
                Name = "Key",
                Position = new PointF(1350, groundY - 300),
                Size = new SizeF(35, 35),
                Sprite = Properties.Resources.key,
                IsRigidBody = false,
                HasPhysics = false
            });

            // ================= COINS =================
            for (int i = 0; i < 10; i++)
            {
                game.AddObject(new GameObject
                {
                    Name = "Coin",
                    Position = new PointF(500 + (i * 150), groundY - 150 - (i % 2 * 50)),
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
                Position = new PointF(worldWidth - 250, groundY - 250),
                Size = new SizeF(200, 250),
                Sprite = Properties.Resources.exit,
                IsRigidBody = true
            });

            // Switch to Level 2 Music
            Game.Audio.Stop("level1_music");
            Game.Audio.Play("level2_music");
        }

        // Helper methods to keep code clean
        private void AddEnemy(Game game, Bitmap sprite, float x, float y, float minX, float maxX)
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