using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Movements;
using JungleEscapeGame.Levels;
using System.Windows.Forms;



namespace JungleEscapeGame
{
    public partial class GameForm : Form
    {
        Timer timer;
        float deltaTime = 0.016f;

        public GameForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            level = new Level1();

            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += GameLoop;
            timer.Start();
        }


        private void GameLoop(object sender, EventArgs e)
        {
            level.Update(new GameTime(deltaTime));
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            level.Draw(e.Graphics);
        }
    }
}
