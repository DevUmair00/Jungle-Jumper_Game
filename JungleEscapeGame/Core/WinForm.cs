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
    public partial class WinForm : Form
    {
        private int currentLevel;
        public WinForm(int currentLevel)
        {
            InitializeComponent();
            this.currentLevel = currentLevel;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnNextLevel_Click(object sender, EventArgs e)
        {
            if (currentLevel < 3)
            {
                GameForm game = new GameForm(currentLevel + 1);
                game.Show();
            }
            else
            {
                MessageBox.Show("All levels completed!");
                MenuForm menu = new MenuForm();
                menu.Show();
            }

            //this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
            this.Close();
        }
    }
}
