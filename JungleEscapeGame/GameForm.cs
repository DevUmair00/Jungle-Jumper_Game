//using JungleEscapeGame.Levels;
using EZInput;
using GameFrameWork;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Movements;
using JungleEscapeGame.Properties;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JungleEscapeGame
{
    public partial class GameForm : Form
    {

        private Game game = new Game();
        //private Level1 level;



        private PointF cameraOffset = PointF.Empty;

        private Player player;



        float worldWidth = 800;
        float worldHeight = 400;
        float thickness = 32f;

        public GameForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            ClientSize = new Size(800, 400);
            Setting();

        }


        private void Setting()
        {


            // -------- PLAYER --------

            game.AddObject(new Player
            {
                Position = new PointF(20, 310),
                Size = new Size(50, 50),
                Sprite = Properties.Resources.player,
                Movement = new KeyboardMovement(),
                HasPhysics = true,
            });


            // -------- Floor --------

            for (int i = -1; i < 40; i++)
            {
                // floor tiles (static)
                game.AddObject(new GameObject
                {
                    Position = new PointF(i * 30, 360),
                    Size = new SizeF(60, 60),
                    Sprite = Properties.Resources.smallBox,
                    IsRigidBody = true,
                    HasPhysics = false  // static
                });
            }


            // -------- EXIT --------

            GameObject exitDoor = new GameObject
            {
                Position = new PointF(500, 210),
                Size = new SizeF(370, 220),
                Sprite = Properties.Resources.exit,
            };
            game.AddObject(exitDoor);



            // -------- Enemy --------


            game.AddObject(new Enemy
            {
                Position = new PointF(300, 100),
                Size = new Size(50, 50),
                HasPhysics = true, // Enable physics with default gravity
                Sprite = Properties.Resources.enemy1,
                IsRigidBody = true,
                IsActive = true
            });





            game.AddObject(new Player
            {
                HasPhysics = true,
                IsRigidBody = false, // player is movable
                CustomGravity = 3,
                Movement = new KeyboardMovement()
            });

  


        }



        protected override void OnPaint(PaintEventArgs e)
        {
            // 1️⃣ Draw background (no camera movement yet)
            DrawBackground(e.Graphics);

            // 2️⃣ Apply camera transform
            e.Graphics.TranslateTransform(-cameraOffset.X, -cameraOffset.Y);

            // 3️⃣ Draw all game objects
            game.Draw(e.Graphics);

            // 4️⃣ Reset transform (important!)
            e.Graphics.ResetTransform();
        }

        private void DrawBackground(Graphics g)
        {
            g.DrawImage(
                Properties.Resources.bg1,
                new Rectangle(0, 0, 1600, 1200)
            );
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.Update(new GameTime(0.016f));
            Invalidate();

        }
    }
}
