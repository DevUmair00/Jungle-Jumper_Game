using GameFrameWork.Core;
using GameFrameWork.System;
using JungleEscapeGame.Core;
using JungleEscapeGame.Levels;

namespace JungleEscapeGame
{
    public static class GameState
    {
        public static bool LevelCompleted = false;
        public static bool GameOver = false;

    }

    public partial class GameForm : Form
    {

        private Game game = new Game();
        private PhysicsSystem physics = new PhysicsSystem();
        private CollisionSystem collisions = new CollisionSystem();

        private ILevel level;
        private Player player;

        public int MaxHealth { get; set; } = 100;
        public int Health { get; set; } = 100;
        public int Score { get; set; } = 0;


        private PointF cameraOffset = PointF.Empty;

        private float deltaTime = 0.016f;

        float worldWidth = 2500f;

        int currentLevel = 1;

        public GameForm(int StartLevel)
        {
            InitializeComponent();
            DoubleBuffered = true;
            ClientSize = new Size(800, 500);

            this.currentLevel = 2; // Set the level from the menu
            LoadLevel();
        }

        void LoadLevel()
        {
            game.Objects.Clear();

            if (currentLevel == 1)
            {
                level = new Level1();
            }
            else if (currentLevel == 2)
            {
                level = new Level2();
            }

            if (level != null)
            {
                level.Load(game);
                player = level.Player;
            }

            GameState.LevelCompleted = false;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (player == null) return;

            Graphics g = e.Graphics;

            DrawBackground(g);

            g.TranslateTransform(-cameraOffset.X, 0);
            game.Draw(g);
            g.ResetTransform();

            DrawScore(g);
            DrawKey(g);
            DrawHealthBar(g);
        }

        private void DrawHealthBar(Graphics g)
        {
            if (player == null) return;

            // Position and Size of the Health Bar
            int x = 20;
            int y = 60;
            int width = 200;
            int height = 20;

            //Draw the Background (The empty slot)
            g.FillRectangle(Brushes.Gray, x, y, width, height);

            //Current health percentage
            float healthPercentage = (float)player.Health / player.MaxHealth;
            float currentHealthWidth = width * healthPercentage;

            //Choose color based on level theme
            Brush healthBrush = (level is Level1) ? Brushes.LimeGreen : Brushes.DarkViolet;

            //Draw the actual Health
            g.FillRectangle(healthBrush, x, y, currentHealthWidth, height);

            g.DrawRectangle(Pens.Black, x, y, width, height);

            g.DrawString("HP", new Font("Arial", 10, FontStyle.Bold), Brushes.White, x + 5, y + 2);



            Font lifeFont = new Font("Arial", 12, FontStyle.Bold);
            string lifeText = "LIVES: ";
            g.DrawString(lifeText, lifeFont, Brushes.White, 20, 90);

            for (int i = 0; i < player.Lives; i++)
            {
                g.FillEllipse(Brushes.Red, 80 + (i * 25), 90, 15, 15);
            }

            if (player.Lives <= 0)
            {
                DrawGameOver(g);
            }
        }


        private void DrawGameOver(Graphics g)
        {
            Rectangle screenRect = new Rectangle(0, 0, this.Width, this.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(150, 0, 0, 0)), screenRect); // Darken screen

            Font bigFont = new Font("Impact", 50);
            string msg = "GAME OVER";
            SizeF size = g.MeasureString(msg, bigFont);
            g.DrawString(msg, bigFont, Brushes.Red, (this.Width - size.Width) / 2, (this.Height - size.Height) / 2);
        }


        private void DrawScore(Graphics g)
        {
            g.DrawString($"Score: {player.Score}",
                new Font("Impact", 18), Brushes.LimeGreen, 20, 20);
        }

        private void DrawKey(Graphics g)
        {
            g.DrawString($"Keys: {player.Keys}",
                new Font("Impact", 18), Brushes.Gold, 650, 20);
        }

        private void DrawBackground(Graphics g)
        {
            g.DrawImage(Properties.Resources.bg1, 0, 0, 800, 500);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // If the game is over, stop updating but keep drawing
            if (GameState.GameOver)
            {
                Invalidate(); // Keep drawing the Game Over screen
                return;
            }

            if (player.Lives <= 0) // Check lives instead of IsActive
            {
                GameState.GameOver = true;
                return;
            }

            if (GameState.LevelCompleted)
            {
                //currentLevel++;
                LoadLevel();
            }


            // Update bullets (spawn, move, remove)
            level?.UpdateBullets(new GameTime(deltaTime), game);

            game.Update(new GameTime(deltaTime));
            physics.Apply(game.Objects);
            collisions.Check(game.Objects);
            game.Cleanup();

            cameraOffset = new PointF(Math.Max(0, Math.Min(player.Position.X - ClientSize.Width / 2, worldWidth - ClientSize.Width)), 0);


            if (GameState.LevelCompleted)
            {
                currentLevel++;
                SaveSystem.SaveLevel(currentLevel); // Save progress to the file
                LoadLevel();
            }


            Invalidate();
        }
    }
}
