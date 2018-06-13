namespace engsoft3
{
    partial class FormRanking
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
            this.txtSearchPlayer = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColunaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaIdade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaVitorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchRanking = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pequisar:";
            // 
            // txtSearchPlayer
            // 
            this.txtSearchPlayer.Location = new System.Drawing.Point(116, 62);
            this.txtSearchPlayer.Name = "txtSearchPlayer";
            this.txtSearchPlayer.Size = new System.Drawing.Size(100, 20);
            this.txtSearchPlayer.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColunaNome,
            this.ColunaIdade,
            this.ColunaEmail,
            this.ColunaVitorias});
            this.dataGridView1.Location = new System.Drawing.Point(46, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 214);
            this.dataGridView1.TabIndex = 2;
            // 
            // ColunaNome
            // 
            this.ColunaNome.HeaderText = "Nome";
            this.ColunaNome.Name = "ColunaNome";
            this.ColunaNome.ReadOnly = true;
            // 
            // ColunaIdade
            // 
            this.ColunaIdade.HeaderText = "Idade";
            this.ColunaIdade.Name = "ColunaIdade";
            this.ColunaIdade.ReadOnly = true;
            // 
            // ColunaEmail
            // 
            this.ColunaEmail.HeaderText = "E-mail";
            this.ColunaEmail.Name = "ColunaEmail";
            this.ColunaEmail.ReadOnly = true;
            // 
            // ColunaVitorias
            // 
            this.ColunaVitorias.HeaderText = "Vitórias";
            this.ColunaVitorias.Name = "ColunaVitorias";
            this.ColunaVitorias.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ranking:";
            // 
            // txtSearchRanking
            // 
            this.txtSearchRanking.Location = new System.Drawing.Point(352, 62);
            this.txtSearchRanking.Name = "txtSearchRanking";
            this.txtSearchRanking.Size = new System.Drawing.Size(100, 20);
            this.txtSearchRanking.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(377, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Procurar";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // FormRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 371);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchRanking);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearchPlayer);
            this.Controls.Add(this.label1);
            this.Name = "FormRanking";
            this.Text = "Rankings dos Jogadores";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchPlayer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaIdade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaVitorias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchRanking;
        private System.Windows.Forms.Button btnSearch;
    }
}