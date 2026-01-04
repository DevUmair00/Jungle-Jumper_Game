namespace JungleEscapeGame
{
    partial class MenuForm
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
            pictureBox1 = new PictureBox();
            btn_newGame = new Button();
            btn_Continue = new Button();
            btn_Exit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bgMenu;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(783, 464);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btn_newGame
            // 
            btn_newGame.BackColor = Color.OliveDrab;
            btn_newGame.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_newGame.ForeColor = Color.Gold;
            btn_newGame.Location = new Point(313, 205);
            btn_newGame.Name = "btn_newGame";
            btn_newGame.Size = new Size(169, 41);
            btn_newGame.TabIndex = 1;
            btn_newGame.Text = "New Game";
            btn_newGame.UseVisualStyleBackColor = false;
            btn_newGame.Click += btn_newGame_Click;
            // 
            // btn_Continue
            // 
            btn_Continue.BackColor = Color.OliveDrab;
            btn_Continue.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Continue.ForeColor = Color.Gold;
            btn_Continue.Location = new Point(313, 283);
            btn_Continue.Name = "btn_Continue";
            btn_Continue.Size = new Size(169, 41);
            btn_Continue.TabIndex = 2;
            btn_Continue.Text = "Continue";
            btn_Continue.UseVisualStyleBackColor = false;
            btn_Continue.Click += btn_Continue_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.BackColor = Color.OliveDrab;
            btn_Exit.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Exit.ForeColor = Color.Gold;
            btn_Exit.Location = new Point(338, 358);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(120, 41);
            btn_Exit.TabIndex = 3;
            btn_Exit.Text = "Exit";
            btn_Exit.UseVisualStyleBackColor = false;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(btn_Exit);
            Controls.Add(btn_Continue);
            Controls.Add(btn_newGame);
            Controls.Add(pictureBox1);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btn_newGame;
        private Button btn_Continue;
        private Button btn_Exit;
    }
}