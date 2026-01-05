namespace JungleEscapeGame.Core
{
    partial class WinForm
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
            textBox1 = new TextBox();
            btnNextLevel = new Button();
            btnMenu = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.Font = new Font("Showcard Gothic", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(200, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(427, 126);
            textBox1.TabIndex = 0;
            textBox1.Text = "YOU WIN";
            // 
            // btnNextLevel
            // 
            btnNextLevel.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNextLevel.Location = new Point(177, 283);
            btnNextLevel.Name = "btnNextLevel";
            btnNextLevel.Size = new Size(197, 54);
            btnNextLevel.TabIndex = 1;
            btnNextLevel.Text = "Next Level";
            btnNextLevel.UseVisualStyleBackColor = true;
            btnNextLevel.Click += btnNextLevel_Click;
            // 
            // btnMenu
            // 
            btnMenu.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.Location = new Point(441, 283);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(197, 54);
            btnMenu.TabIndex = 2;
            btnMenu.Text = "Back to Menu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // WinForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMenu);
            Controls.Add(btnNextLevel);
            Controls.Add(textBox1);
            Name = "WinForm";
            Text = "WinForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnNextLevel;
        private Button btnMenu;
    }
}