using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Extentions;
using GameFrameWork.Movements;
using System.Collections.Generic;
using System.Drawing;

namespace JungleEscapeGame.Levels
{
    public class Level3 : ILevel
    {
        public Player Player { get; private set; }
        public List<Enemy> Enemies { get; } = new();
        public List<Bullet> Bullets { get; } = new();

        public Bitmap BackgroundImage => Properties.Resources.bg3;

        public void Load(Game game)
        {
            // Clear previous data
            game.Objects.Clear();
            Enemies.Clear();
            Bullets.Clear();

            float worldWidth = 3800f;
            float worldHeight = 500f;
            float floorHeight = 50f;
            float groundY = worldHeight - floorHeight;


            // ================= FLOOR =================
            game.AddObject(new GameObject
            {
                Name = "Floor",
                Position = new PointF(0, groundY),
                Size = new SizeF(worldWidth, floorHeight),
                IsRigidBody = true,
                Visible = false
            });




            // ================= BOUNDARIES =================
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(0, 0),
                Size = new SizeF(10, worldHeight),
                IsRigidBody = true,
                Visible = false
            });

            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(3300, 0),
                Size = new SizeF(10, worldHeight),
                IsRigidBody = true,
                Visible = false
            });





            // ================= PLAYER =================
            Player = new Player
            {
                Name = "Player",
                Position = new PointF(80, groundY - 120),
                Size = new SizeF(45, 50),
                Sprite = Properties.Resources.player,
                HasPhysics = true
            };
            Player.AddMovement(new KeyboardMovement(6));
            Player.AddMovement(new JumpingMovement(19f));
            game.AddObject(Player);






            // ================= ENEMIES (Ground Patrol) =================

            AddEnemy(game, Properties.Resources.enemy2, 400, groundY - 64);
            AddEnemy(game, Properties.Resources.enemy3, 600, groundY - 64);
            //AddEnemy(game, Properties.Resources.enemy2, 2800, groundY - 64);
            //AddEnemy(game, Properties.Resources.enemy3, 4200, groundY - 64);



            //// ================= ENEMIES (Fire Ball) =================

            AddFireBall(game, 1300, groundY - 124, groundY - 400, groundY - 64, 10f);
            AddFireBall(game, 1450, groundY - 124, groundY - 400, groundY - 64, 9f);
            AddFireBall(game, 1600, groundY - 124, groundY - 400, groundY - 64, 10f);


            //// ================= GHOSTS (Air Control) =================
            //AddGhost(game, Properties.Resources.ghost, 900, 120, 700, 1400, 80, 260, 5f);
            //AddGhost(game, Properties.Resources.ghost, 2500, 150, 2300, 3200, 100, 300, 6f);
            //AddGhost(game, Properties.Resources.ghost, 4700, 200, 4500, 5600, 120, 350, 7f);





            // ================= BOX =================

            CreateBox(game, 300, groundY -60);
            CreateBox(game, 360, groundY -60);
            CreateBox(game, 360, groundY-120);

            CreateSmallBox(game, 765, groundY -300);
            CreateSmallBox(game, 805, groundY -300);
            CreateSmallBox(game, 845, groundY - 300);

            CreateBox(game, 1100, groundY - 60);
            CreateBox(game, 1100, groundY - 120);
            CreateBox(game, 1160, groundY - 60);




            CreateBox(game, 1720, groundY - 60);
            CreateBox(game, 1780, groundY - 60);
            CreateBox(game, 1780, groundY - 120);


            CreateBox(game, 2920, groundY - 60);   // step 1
            CreateBox(game, 2980, groundY - 60);  // step 2
            CreateBox(game, 2980, groundY - 120);  // step 3

            CreateBox(game, 3040, groundY - 60);  // step 4
            CreateBox(game, 3040, groundY - 120);  // step 4
            CreateBox(game, 3040, groundY - 180);  // step 4



            // ================= PLATFORM MAZE =================
            CreateBrick(game, 700, groundY - 170);


            CreateBrick(game, 1920, groundY - 200);
            CreateBrick(game, 2220, groundY - 300);
            CreateBrick(game, 2420, groundY - 300);
            CreateBrick(game, 2650, groundY - 200);





            // ================= KEY (Hard to Reach) =================
            game.AddObject(new GameObject
            {
                Name = "Key",
                Position = new PointF(3650, groundY - 420),
                Size = new SizeF(35, 35),
                Sprite = Properties.Resources.key,
                IsRigidBody = false,
                HasPhysics = false
            });


            // ================= COINS (Vertical Reward Path) =================
            for (int i = 0; i < 8; i++)
            {
                game.AddObject(new GameObject
                {
                    Name = "Coin",
                    Position = new PointF(900 + i * 150, groundY - 200 - (i * 30)),
                    Size = new SizeF(20, 20),
                    Sprite = Properties.Resources.coin,
                    IsRigidBody = false,
                    HasPhysics = false
                });
            }

            // ================= EXIT (Final Challenge) =================
            game.AddObject(new GameObject
            {
                Name = "Exit",
                Position = new PointF(3400, groundY - 300),
                Size = new SizeF(220, 300),
                Sprite = Properties.Resources.exit,
                IsRigidBody = false
            });


            // ================= MUSIC =================
            Game.Audio.Stop("level2_music");
            Game.Audio.Play("level1_music");
        }

        // ================= HELPERS =================

        private void AddEnemy(Game game, Bitmap sprite, float x, float y)
        {
            var e = new Enemy
            {
                Name = "Enemy",
                Sprite = sprite,
                Position = new PointF(x, y),
                Size = new SizeF(80, 60),
                HasPhysics = true,
                Movement = new PatrolMovement(x - 200, x + 200)
            };
            Enemies.Add(e);
            game.AddObject(e);
        }


        private void AddGhost(Game game, Bitmap sprite, float startX, float startY,
                              float minX, float maxX, float minY, float maxY, float speed)
        {
            var ghost = new Enemy
            {
                Name = "Enemy",
                Sprite = sprite,
                Position = new PointF(startX, startY),
                Size = new SizeF(60, 60),
                HasPhysics = false,
                IsRigidBody = false,
                Movement = new RandomPatrolMovement(minX, maxX, minY, maxY, speed)
            };
            Enemies.Add(ghost);
            game.AddObject(ghost);
        }

        private void AddFireBall(Game game,float x,float startY,float topBound,float bottomBound,float speed)
        {
            var fireBall = new Enemy
            {
                Name = "FireBall",
                Sprite = Properties.Resources.fireBall,
                Position = new PointF(x, startY),
                Size = new SizeF(60, 60),
                HasPhysics = false,      
                IsRigidBody = false,     
                Velocity = PointF.Empty,
                Movement = new VerticalMovement(
                    topBound: topBound,
                    bottomBound: bottomBound,
                    speed: speed
                )
            };

            Enemies.Add(fireBall);
            game.AddObject(fireBall);
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
        private void CreateSmallBox(Game game, float x, float y)
        {
            game.AddObject(new GameObject
            {
                Name = "Wall",
                Position = new PointF(x, y),
                Size = new SizeF(40, 40),
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
                Size = new SizeF(220, 40),
                Sprite = Properties.Resources.horizontalBrick,
                IsRigidBody = true
            });
        }

        public void UpdateBullets(GameTime gameTime, Game game)
        {
            if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.Space))
            {
                var bullet = Player.Fire();
                if (bullet != null)
                {
                    Bullets.Add(bullet);
                    game.AddObject(bullet);
                }
            }

            foreach (var b in Bullets)
                b.Update(gameTime);

            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                if (!Bullets[i].IsActive)
                    Bullets.RemoveAt(i);
            }
        }
    }
}
