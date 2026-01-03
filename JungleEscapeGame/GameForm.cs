using EZInput;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Extentions;
using GameFrameWork.System;
using JungleEscapeGame.Levels;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JungleEscapeGame
{
    public partial class GameForm : Form
    {
        private Game game = new Game();
        private PhysicsSystem physics = new PhysicsSystem();
        private CollisionSystem collisions = new CollisionSystem();

        private Level1 level;
        private Player player;

        private PointF cameraOffset = PointF.Empty;
        private float deltaTime = 0.016f;

        public GameForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            ClientSize = new Size(800, 400);

            level = new Level1();
            level.Load(game);
            player = level.Player;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Visible = true && game != null)
            {

                DrawBackground(e.Graphics);

                e.Graphics.TranslateTransform(-cameraOffset.X, 0); // side scrolling only
                game.Draw(e.Graphics);
                e.Graphics.ResetTransform();
            }
        }

        private void DrawBackground(Graphics g)
        {
            if (this.Visible = true && game != null)
            {
                g.DrawImage(
                Properties.Resources.bg1,
                new Rectangle(0, 0, 1600, 400)
                );
            }
            
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // FIRE BULLET
            if (EZInput.Keyboard.IsKeyPressed(Key.Space))
            {
                Bullet bullet = player.Fire();
                if (bullet != null)
                    game.AddObject(bullet);
            }

            game.Update(new GameTime(deltaTime));
            physics.Apply(game.Objects);
            collisions.Check(game.Objects);
            game.Cleanup();

            // CAMERA FOLLOWS PLAYER (X only)
            cameraOffset = new PointF(
                player.Position.X - ClientSize.Width / 2,
                0
            );

            Invalidate();
        }
    }
}
