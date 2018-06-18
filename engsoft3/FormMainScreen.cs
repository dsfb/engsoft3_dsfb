using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace engsoft3
{
    public partial class FormMainScreen : Form
    {
        private string idPlayer;
        private string idGame = null;
        private System.Timers.Timer aTimer;
        public FormMainScreen(string idPlayer)
        {
            InitializeComponent();
            this.idPlayer = idPlayer;
            NewGameRequestManager.GetInstance(Convert.ToInt32(this.idPlayer));
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            using (var db = new dominoeng3Entities())
            {
                int id = Convert.ToInt32(idPlayer);
                var query = from u in db.partidas
                            where u.player1 == id && (u.estado == 0 || u.estado == 1)
                            select u;

                if (query.Count() > 0)
                {
                    partida p = query.First();
                    if (p.estado == 0)
                    {
                        idGame = Convert.ToString(p.ID);
                    }
                    else if (p.estado == 1)
                    {
                        if (String.IsNullOrEmpty(idGame))
                        {
                            idGame = Convert.ToString(p.ID);
                        }

                        if (idGame.Equals(Convert.ToString(p.ID)))
                        {
                            MessageBox.Show("Seu pedido de jogo foi aceito! Você pode jogar agora!");
                        }
                    }
                }
            }
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
