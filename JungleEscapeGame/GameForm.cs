using DocumentFormat.OpenXml.Wordprocessing;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Movements;
//using JungleEscapeGame.Levels;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace JungleEscapeGame
{
    public partial class GameForm : Form
    {

        private Game game = new Game();
        //private Level1 level;


        private PointF cameraOffset = PointF.Empty;

        private Player player;

        public GameForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            ClientSize = new Size(800, 600);

            CreateLevel();
            CreateObjects();

        }

        private void CreateLevel()
        {
            // PLAYER
            player = new Player
            {
                Position = new PointF(100, 100),
                Size = new SizeF(40, 40),
                Sprite = Properties.Resources.player
            };
            player.AddMovement(new GameFrameWork.Movements.KeyboardMovement(4));
            game.AddObject(player);


            // WALLS (simple level)
            for (int i = 0; i < 20; i++)
            {
                game.AddObject(new GameObject
                {
                    Position = new PointF(i * 64, 300),
                    Size = new SizeF(64, 64),
                    Sprite = Properties.Resources.smallBox,
                    IsRigidBody = true
                });
            }
        }


        private void CreateObjects()
        {
            // -------- PLAYER --------
            Player player = new Player
            {
                Position = new PointF(50, 50),
                Size = new SizeF(32, 32),
                Sprite = Properties.Resources.player
            };
            player.AddMovement(new KeyboardMovement(3));
            game.AddObject(player);



            // -------- WALL --------
            GameObject wall = new GameObject
            {
                Position = new PointF(150, 50),
                Size = new SizeF(32, 32),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            };
            game.AddObject(wall);



            // -------- EXIT --------
            GameObject exitDoor = new GameObject
            {
                Position = new PointF(300, 50),
                Size = new SizeF(32, 32),
                Sprite = Properties.Resources.exit
            };

            game.AddObject(exitDoor);
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            // 1?? Draw background (no camera movement yet)
            DrawBackground(e.Graphics);

            // 2?? Apply camera transform
            e.Graphics.TranslateTransform(-cameraOffset.X, -cameraOffset.Y);

            // 3?? Draw all game objects
            game.Draw(e.Graphics);

            // 4?? Reset transform (important!)
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
