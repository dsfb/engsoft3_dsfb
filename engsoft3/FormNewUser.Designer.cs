namespace engsoft3
{
    partial class FormNewUser
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserPass = new System.Windows.Forms.TextBox();
            this.txtUserMail = new System.Windows.Forms.TextBox();
            this.numUserAge = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numUserAge)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do usuário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha do Usuário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "E-mail do Usuário:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Idade do Usuário:";
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(42, 179);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(207, 23);
            this.btnNewUser.TabIndex = 4;
            this.btnNewUser.Text = "Cadastrar Novo Usuário";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(149, 44);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 5;
            // 
            // txtUserPass
            // 
            this.txtUserPass.Location = new System.Drawing.Point(149, 77);
            this.txtUserPass.Name = "txtUserPass";
            this.txtUserPass.Size = new System.Drawing.Size(100, 20);
            this.txtUserPass.TabIndex = 6;
            // 
            // txtUserMail
            // 
            this.txtUserMail.Location = new System.Drawing.Point(149, 108);
            this.txtUserMail.Name = "txtUserMail";
            this.txtUserMail.Size = new System.Drawing.Size(100, 20);
            this.txtUserMail.TabIndex = 7;
            // 
            // numUserAge
            // 
            this.numUserAge.Location = new System.Drawing.Point(149, 141);
            this.numUserAge.Name = "numUserAge";
            this.numUserAge.Size = new System.Drawing.Size(100, 20);
            this.numUserAge.TabIndex = 9;
            // 
            // FormNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 261);
            this.Controls.Add(this.numUserAge);
            this.Controls.Add(this.txtUserMail);
            this.Controls.Add(this.txtUserPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormNewUser";
            this.Text = "Cadastro de Novo Usuário";
            this.Load += new System.EventHandler(this.FormNewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUserAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserPass;
        private System.Windows.Forms.TextBox txtUserMail;
        private System.Windows.Forms.NumericUpDown numUserAge;
    }
}