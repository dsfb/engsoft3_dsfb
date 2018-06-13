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
    public partial class FormMainScreen : Form
    {
        private string idPlayer;
        public FormMainScreen(string idPlayer)
        {
            InitializeComponent();
            this.idPlayer = idPlayer;
        }

        private void btnRankings_Click(object sender, EventArgs e)
        {
            FormRanking fr = new FormRanking();
            fr.ShowDialog();
        }

        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            FormNewGame fng = new FormNewGame(this.idPlayer);
            fng.ShowDialog();
        }
    }
}
