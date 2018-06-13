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
    public partial class FormNewGame : Form
    {
        private string idPlayer;
        public FormNewGame(string idPlayer)
        {
            InitializeComponent();
            this.txtIDPlayer.Text = idPlayer;
            this.idPlayer = idPlayer;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
