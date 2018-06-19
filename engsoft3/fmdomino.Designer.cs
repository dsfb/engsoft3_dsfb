namespace engsoft3
{
    partial class fmdomino
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmdomino));
            this.cbBChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuyPiece = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPecaAdvers = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // cbBChoice
            // 
            this.cbBChoice.FormattingEnabled = true;
            this.cbBChoice.Items.AddRange(new object[] {
            "Direita",
            "Esquerda"});
            this.cbBChoice.Location = new System.Drawing.Point(150, 55);
            this.cbBChoice.Name = "cbBChoice";
            this.cbBChoice.Size = new System.Drawing.Size(121, 21);
            this.cbBChoice.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escolha o lado:";
            // 
            // btnBuyPiece
            // 
            this.btnBuyPiece.Location = new System.Drawing.Point(302, 53);
            this.btnBuyPiece.Name = "btnBuyPiece";
            this.btnBuyPiece.Size = new System.Drawing.Size(128, 23);
            this.btnBuyPiece.TabIndex = 2;
            this.btnBuyPiece.Text = "Comprar novas peças";
            this.btnBuyPiece.UseVisualStyleBackColor = true;
            this.btnBuyPiece.Click += new System.EventHandler(this.btnBuyPiece_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status do Jogo:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(566, 58);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status do Jogo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(683, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Adversário tem quantas peças?";
            // 
            // lblPecaAdvers
            // 
            this.lblPecaAdvers.AutoSize = true;
            this.lblPecaAdvers.Location = new System.Drawing.Point(861, 58);
            this.lblPecaAdvers.Name = "lblPecaAdvers";
            this.lblPecaAdvers.Size = new System.Drawing.Size(13, 13);
            this.lblPecaAdvers.TabIndex = 6;
            this.lblPecaAdvers.Text = "7";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // fmdomino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 516);
            this.Controls.Add(this.lblPecaAdvers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuyPiece);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBChoice);
            this.Name = "fmdomino";
            this.Text = "fmdomino";
            this.Load += new System.EventHandler(this.fmdomino_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuyPiece;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPecaAdvers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}