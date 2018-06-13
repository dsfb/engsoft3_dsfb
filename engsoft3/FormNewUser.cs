using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engsoft3
{
    public partial class FormNewUser : Form
    {
        public FormNewUser()
        {
            InitializeComponent();
        }

        private void FormNewUser_Load(object sender, EventArgs e)
        {

        }

        private Boolean validateTextBoxField(TextBox tb, int maxLength, string tbName)
        {
            if (tb.TextLength == 0 || tb.TextLength >= maxLength)
            {
                MessageBox.Show(tbName + " é inválido!");
                return false;
            }

            return true;
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            if (!validateTextBoxField(txtUserName, 100, "Nome de Usuário"))
            {
                return;
            }

            if (!validateTextBoxField(txtUserPass, 25, "Dado de Senha de Usuário"))
            {
                return;
            }

            if (!validateTextBoxField(txtUserMail, 50, "E-mail de Usuário"))
            {
                return;
            }

            if (Decimal.ToInt32(numUserAge.Value) == 0)
            {
                MessageBox.Show("Dado de Idade de Usuário é inválido!");
                return;
            }

            using (var db = new dominoeng3Entities())
            {
                var players = db.Set<player>();
                players.Add(new player { Nome = txtUserName.Text, Senha = txtUserPass.Text,
                    Email = txtUserMail.Text, Idade = Decimal.ToInt32(numUserAge.Value) });

                db.SaveChanges();

                MessageBox.Show("Novo usuário cadastrado com sucesso!");
            }
        }
    }
}
