namespace engsoft3
{
    partial class FormRequest
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAcceptRequest = new System.Windows.Forms.Button();
            this.btnRejectGameRequest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jogadores que pediram para jogar com você:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnAcceptRequest
            // 
            this.btnAcceptRequest.Location = new System.Drawing.Point(30, 231);
            this.btnAcceptRequest.Name = "btnAcceptRequest";
            this.btnAcceptRequest.Size = new System.Drawing.Size(240, 23);
            this.btnAcceptRequest.TabIndex = 2;
            this.btnAcceptRequest.Text = "Aceitar o pedido do Jogador Selecionado";
            this.btnAcceptRequest.UseVisualStyleBackColor = true;
            this.btnAcceptRequest.Click += new System.EventHandler(this.btnAcceptRequest_Click);
            // 
            // btnRejectGameRequest
            // 
            this.btnRejectGameRequest.Location = new System.Drawing.Point(30, 274);
            this.btnRejectGameRequest.Name = "btnRejectGameRequest";
            this.btnRejectGameRequest.Size = new System.Drawing.Size(240, 23);
            this.btnRejectGameRequest.TabIndex = 3;
            this.btnRejectGameRequest.Text = "Rejeitar o pedido do Jogador Selecionado";
            this.btnRejectGameRequest.UseVisualStyleBackColor = true;
            this.btnRejectGameRequest.Click += new System.EventHandler(this.btnRejectGameRequest_Click);
            // 
            // FormRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 309);
            this.Controls.Add(this.btnRejectGameRequest);
            this.Controls.Add(this.btnAcceptRequest);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "FormRequest";
            this.Text = "FormRequest";
            this.Load += new System.EventHandler(this.FormRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAcceptRequest;
        private System.Windows.Forms.Button btnRejectGameRequest;
    }
}