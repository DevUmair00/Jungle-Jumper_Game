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
        private Player player; // This is the player we will use for EVERYTHING

        private PointF cameraOffset = PointF.Empty;
        private float deltaTime = 0.016f;

        float worldWidth = 2500f;
        float worldHeight = 500f;

        public GameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ClientSize = new Size(800, 500);

            level = new Level1();
            level.Load(game);
            player = level.Player; // Assigning the real player from Level 1
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // FIX: Use == for comparison, not =
            if (this.Visible && game != null)
            {
                Graphics g = e.Graphics;

                // 1. Draw Background (Stationary or Parallax)
                DrawBackground(g);

                // 2. Apply Camera for Game Objects
                g.TranslateTransform(-cameraOffset.X, 0);
                game.Draw(g);
                g.ResetTransform();

                // 3. Draw UI (Always stationary on screen)
                DrawScore(g);

                DrawKey(g);
            }
        }

        // Moved UI logic to a dedicated helper to keep code clean
        private void DrawScore(Graphics g)
        {

            if (player == null) return;

            Font scoreFont = new Font("Impact", 20, FontStyle.Regular);

            Brush scoreBrush = Brushes.LimeGreen;
            PointF textPosition = new PointF(20, 20);

            string displayString = $"Score : {player.Score}";

            g.DrawString(displayString, scoreFont, Brushes.DarkGreen, textPosition.X + 2, textPosition.Y + 2);
            g.DrawString(displayString, scoreFont, scoreBrush, textPosition.X, textPosition.Y);
        }

        private void DrawKey(Graphics g)
        {

            if (player == null) return;

            Font keyFont = new Font("Impact", 20, FontStyle.Regular);

            Brush keyBrush = Brushes.LimeGreen;
            PointF textPosition = new PointF(700, 20);

            string displayString = $"Key : {player.Key}";

            g.DrawString(displayString, keyFont, Brushes.DarkGreen, textPosition.X + 2, textPosition.Y + 2);
            g.DrawString(displayString, keyFont, keyBrush, textPosition.X, textPosition.Y);
        }


        private void DrawBackground(Graphics g)
        {
            g.DrawImage(Properties.Resources.bg1, new Rectangle(0, 0, 800, 500));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // FIRE BULLET
            if (EZInput.Keyboard.IsKeyPressed(Key.Space))
            {
                Bullet bullet = player?.Fire();
                if (bullet != null)
                    game.AddObject(bullet);
            }

            game.Update(new GameTime(deltaTime));
            physics.Apply(game.Objects);
            collisions.Check(game.Objects);
            game.Cleanup();


            // CAMERA FOLLOWS PLAYER
            if (player != null)
            {
                cameraOffset = new PointF(
                    Math.Max(0, Math.Min(player.Position.X - ClientSize.Width / 2, worldWidth - ClientSize.Width)),
                    0 // Keep Y static for side-scrolling
                );
            }

            Invalidate(); // Refresh the screen
        }
    }
}