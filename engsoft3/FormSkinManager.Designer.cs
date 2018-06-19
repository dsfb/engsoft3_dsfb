namespace engsoft3
{
    partial class FormSkinManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxFundoTab = new System.Windows.Forms.PictureBox();
            this.cbBFundoTab = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBSkinPeca = new System.Windows.Forms.ComboBox();
            this.pictureBoxSkinPeca = new System.Windows.Forms.PictureBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFundoTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkinPeca)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escolha o seu skin favorito:";
            // 
            // pictureBoxFundoTab
            // 
            this.pictureBoxFundoTab.Location = new System.Drawing.Point(29, 92);
            this.pictureBoxFundoTab.Name = "pictureBoxFundoTab";
            this.pictureBoxFundoTab.Size = new System.Drawing.Size(227, 112);
            this.pictureBoxFundoTab.TabIndex = 1;
            this.pictureBoxFundoTab.TabStop = false;
            // 
            // cbBFundoTab
            // 
            this.cbBFundoTab.FormattingEnabled = true;
            this.cbBFundoTab.Location = new System.Drawing.Point(135, 56);
            this.cbBFundoTab.Name = "cbBFundoTab";
            this.cbBFundoTab.Size = new System.Drawing.Size(121, 21);
            this.cbBFundoTab.TabIndex = 2;
            this.cbBFundoTab.SelectedValueChanged += new System.EventHandler(this.cbBFundoTab_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tabuleiro Escolhido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Skin escolhido de peça:";
            // 
            // cbBSkinPeca
            // 
            this.cbBSkinPeca.FormattingEnabled = true;
            this.cbBSkinPeca.Location = new System.Drawing.Point(153, 219);
            this.cbBSkinPeca.Name = "cbBSkinPeca";
            this.cbBSkinPeca.Size = new System.Drawing.Size(103, 21);
            this.cbBSkinPeca.TabIndex = 5;
            this.cbBSkinPeca.SelectedValueChanged += new System.EventHandler(this.cbBSkinPeca_SelectedValueChanged);
            // 
            // pictureBoxSkinPeca
            // 
            this.pictureBoxSkinPeca.Location = new System.Drawing.Point(52, 256);
            this.pictureBoxSkinPeca.Name = "pictureBoxSkinPeca";
            this.pictureBoxSkinPeca.Size = new System.Drawing.Size(111, 63);
            this.pictureBoxSkinPeca.TabIndex = 6;
            this.pictureBoxSkinPeca.TabStop = false;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(29, 328);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(227, 23);
            this.btnSaveConfig.TabIndex = 7;
            this.btnSaveConfig.Text = "Salvar configurações";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // FormSkinManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 363);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.pictureBoxSkinPeca);
            this.Controls.Add(this.cbBSkinPeca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBFundoTab);
            this.Controls.Add(this.pictureBoxFundoTab);
            this.Controls.Add(this.label1);
            this.Name = "FormSkinManager";
            this.Text = "FormSkinManager";
            this.Load += new System.EventHandler(this.FormSkinManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFundoTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkinPeca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxFundoTab;
        private System.Windows.Forms.ComboBox cbBFundoTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBSkinPeca;
        private System.Windows.Forms.PictureBox pictureBoxSkinPeca;
        private System.Windows.Forms.Button btnSaveConfig;
    }
}