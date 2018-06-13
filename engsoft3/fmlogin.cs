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
    public partial class fmlogin : Form
    {
        public fmlogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.players
                            where u.Nome == txtuser.Text && u.Senha == txtpass.Text
                            select u;

                if (query.Count() == 1)
                {
                    fmdomino m1 = new fmdomino();
                    m1.ShowDialog();
                    this.Close();
                } else
                {
                    MessageBox.Show("Wrong!");
                }
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            FormNewUser f = new FormNewUser();
            f.ShowDialog(); // Shows Form New User
        }
    }
}
