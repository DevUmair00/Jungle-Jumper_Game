using JungleEscapeGame.Core;

namespace JungleEscapeGame
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }


        private void StartGame(int levelNumber)
        {
            this.Hide();

            GameForm gameForm = new GameForm(levelNumber);

            gameForm.FormClosed += (s, args) => this.Show();

            gameForm.Show();
        }

        private void btn_newGame_Click(object sender, EventArgs e)
        {
            SaveSystem.SaveLevel(1); // Reset to Level 1
            StartGame(1);
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            int savedLevel = SaveSystem.LoadLevel();
            StartGame(savedLevel);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
