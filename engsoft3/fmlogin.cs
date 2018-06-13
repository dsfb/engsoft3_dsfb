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
            //Isso vai no banco
            txtpass.Text = "admin";
            txtuser.Text = "admin";
            if (txtpass.Text != "admin" && txtuser.Text != "admin")
            {
                MessageBox.Show("Wrong!");
                
            }
            else
            {
                fmdomino m1 = new fmdomino();
                m1.ShowDialog();
                this.Close();
                
            }
        }
    }
}
