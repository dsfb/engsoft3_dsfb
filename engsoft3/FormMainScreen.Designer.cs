namespace engsoft3
{
    partial class FormMainScreen
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
            this.btnCreateGame = new System.Windows.Forms.Button();
            this.btnRankings = new System.Windows.Forms.Button();
            this.btnFindGame = new System.Windows.Forms.Button();
            this.btnChooseSkin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateGame
            // 
            this.btnCreateGame.Location = new System.Drawing.Point(126, 114);
            this.btnCreateGame.Name = "btnCreateGame";
            this.btnCreateGame.Size = new System.Drawing.Size(97, 23);
            this.btnCreateGame.TabIndex = 0;
            this.btnCreateGame.Text = "Criar Jogo";
            this.btnCreateGame.UseVisualStyleBackColor = true;
            this.btnCreateGame.Click += new System.EventHandler(this.btnCreateGame_Click);
            // 
            // btnRankings
            // 
            this.btnRankings.Location = new System.Drawing.Point(376, 114);
            this.btnRankings.Name = "btnRankings";
            this.btnRankings.Size = new System.Drawing.Size(92, 23);
            this.btnRankings.TabIndex = 1;
            this.btnRankings.Text = "Rankings";
            this.btnRankings.UseVisualStyleBackColor = true;
            this.btnRankings.Click += new System.EventHandler(this.btnRankings_Click);
            // 
            // btnFindGame
            // 
            this.btnFindGame.Location = new System.Drawing.Point(126, 175);
            this.btnFindGame.Name = "btnFindGame";
            this.btnFindGame.Size = new System.Drawing.Size(97, 23);
            this.btnFindGame.TabIndex = 2;
            this.btnFindGame.Text = "Encontrar Jogo";
            this.btnFindGame.UseVisualStyleBackColor = true;
            // 
            // btnChooseSkin
            // 
            this.btnChooseSkin.Location = new System.Drawing.Point(376, 175);
            this.btnChooseSkin.Name = "btnChooseSkin";
            this.btnChooseSkin.Size = new System.Drawing.Size(92, 23);
            this.btnChooseSkin.TabIndex = 3;
            this.btnChooseSkin.Text = "Escolher Skins";
            this.btnChooseSkin.UseVisualStyleBackColor = true;
            // 
            // FormMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 261);
            this.Controls.Add(this.btnChooseSkin);
            this.Controls.Add(this.btnFindGame);
            this.Controls.Add(this.btnRankings);
            this.Controls.Add(this.btnCreateGame);
            this.Name = "FormMainScreen";
            this.Text = "Tela Principal do Jogo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateGame;
        private System.Windows.Forms.Button btnRankings;
        private System.Windows.Forms.Button btnFindGame;
        private System.Windows.Forms.Button btnChooseSkin;
    }
}