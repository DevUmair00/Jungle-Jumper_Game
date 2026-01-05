using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JungleEscapeGame.Core
{
    public partial class GameOverForm : Form
    {
        private int currentLevel;

        public GameOverForm(int CurrentLevel)
        {
            InitializeComponent();
            this.currentLevel = CurrentLevel;
        }


        private void btnRestart_Click(object sender, EventArgs e)
        {
            GameForm game = new GameForm(currentLevel);
            game.Show();
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
            this.Close();
        }
    }
}
