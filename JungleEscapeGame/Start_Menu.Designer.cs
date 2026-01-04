namespace JungleEscapeGame
{
    partial class Start_Menu
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
            btn_StartGame = new Button();
            btn_Exit = new Button();
            SuspendLayout();
            // 
            // btn_StartGame
            // 
            btn_StartGame.Font = new Font("Stencil", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_StartGame.Location = new Point(300, 140);
            btn_StartGame.Name = "btn_StartGame";
            btn_StartGame.Size = new Size(168, 56);
            btn_StartGame.TabIndex = 0;
            btn_StartGame.Text = "Start Game";
            btn_StartGame.UseVisualStyleBackColor = true;
            btn_StartGame.Click += btn_StartGame_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.BackColor = Color.IndianRed;
            btn_Exit.Font = new Font("Stencil", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Location = new Point(300, 224);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(168, 58);
            btn_Exit.TabIndex = 1;
            btn_Exit.Text = "Exit";
            btn_Exit.UseVisualStyleBackColor = false;
            // 
            // Start_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Exit);
            Controls.Add(btn_StartGame);
            Name = "Start_Menu";
            Text = "Start_Menu";
            Load += Start_Menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_StartGame;
        private Button btn_Exit;
    }
}