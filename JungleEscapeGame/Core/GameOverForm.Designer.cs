namespace JungleEscapeGame.Core
{
    partial class GameOverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnMenu = new Button();
            btnRestart = new Button();
            txtGame_Over = new TextBox();
            SuspendLayout();
            // 
            // btnMenu
            // 
            btnMenu.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.Location = new Point(426, 288);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(197, 54);
            btnMenu.TabIndex = 5;
            btnMenu.Text = "Back to Menu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRestart.Location = new Point(175, 288);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(197, 54);
            btnRestart.TabIndex = 4;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // txtGame_Over
            // 
            txtGame_Over.BackColor = SystemColors.ScrollBar;
            txtGame_Over.Font = new Font("Showcard Gothic", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGame_Over.Location = new Point(123, 63);
            txtGame_Over.Name = "txtGame_Over";
            txtGame_Over.Size = new Size(583, 126);
            txtGame_Over.TabIndex = 3;
            txtGame_Over.Text = "Game Over";
            // 
            // GameOverForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMenu);
            Controls.Add(btnRestart);
            Controls.Add(txtGame_Over);
            Name = "GameOverForm";
            Text = "GameOverForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMenu;
        private Button btnRestart;
        private TextBox txtGame_Over;
    }
}