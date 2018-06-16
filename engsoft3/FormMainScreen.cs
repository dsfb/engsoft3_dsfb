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
            NewGameRequestManager.GetInstance(Convert.ToInt32(this.idPlayer));
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

        private void btnSeeRequest_Click(object sender, EventArgs e)
        {
            FormRequest fr = new FormRequest(Convert.ToInt32(this.idPlayer));
            fr.ShowDialog();
        }

        private void btnPlayAcceptedGame_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new dominoeng3Entities())
                {
                    int id = Convert.ToInt32(idPlayer);
                    partida p = db.partidas.Single(c => c.player1 == id && c.estado == 1);
                    p.estado = 3;

                    db.SaveChanges();

                    MessageBox.Show("Pedido feito para começar o jogo aceito agora!");
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Não existem jogos aceitos para pedidos deste jogador!");
            }
        }

        private void FormMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            NewGameRequestManager.Cancel();
        }
    }
}
