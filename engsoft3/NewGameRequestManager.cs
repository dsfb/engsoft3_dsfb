using engsoft3.requisicoes_ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engsoft3
{
    public class NewGameRequestManager
    {
        private System.Threading.Timer timer;
        private int idPlayer;
        private Boolean doIt = true;
        private Boolean playIt = true;
        private static NewGameRequestManager instance = null;
        
        private NewGameRequestManager(int idPlayer)
        {
            this.idPlayer = idPlayer;
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromSeconds(5);

            timer = new System.Threading.Timer((e) =>
            {
                if (this.doIt)
                {
                    this.MyMethod();
                }

                if (this.playIt)
                {
                    this.PlayMethod();
                }
            }, null, startTimeSpan, periodTimeSpan);
        }       

        private void MyMethod()
        {
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.partidas
                            where u.estado == 0 && u.player2 == idPlayer
                            select u;

                if (query.Count() > 0)
                {
                    MessageBox.Show("Há pedidos de novos jogos pendentes para você! Verifique isto na tela correspondente!");
                    this.disableChecking();
                }
            }
        }

        public void enableChecking()
        {
            this.doIt = true;
        }

        public void disableChecking()
        {
            this.doIt = false;
        }

        private void HoldNewGameState4(int idGame)
        {
            while (true)
            {
                using (var db = new dominoeng3Entities())
                {
                    var query = from u in db.partidas
                                where (u.ID == idGame)
                                select u;

                    if (query.Count() > 0)
                    {
                        partida p = query.First();
                        if (p.estado == 5)
                        {
                            MessageBox.Show("O outro jogador aceitou jogar com você! Começando a jogar agora...!");

                            string idGameStr = Convert.ToString(p.ID);
                            string idPlayer1 = Convert.ToString(p.player1);
                            string idPlayer2 = Convert.ToString(p.player2);

                            string idOpponent;

                            if (idPlayer1.Equals(this.idPlayer))
                            {
                                idOpponent = idPlayer2;
                            }
                            else
                            {
                                idOpponent = idPlayer1;
                            }

                            fmdomino fd = new fmdomino(idGameStr, Convert.ToString(this.idPlayer), idOpponent);
                            fd.ShowDialog();
                        }
                        else if (p.estado == 7)
                        {
                            MessageBox.Show("O outro jogador desistiu de jogar o jogo agora! Abortando esta partida agora...!");
                            break;
                        }
                    }
                }
            }
        }

        private void PlayMethod()
        {
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.partidas
                            where (u.estado == 3 && u.player2 == idPlayer)
                            select u;

                if (query.Count() > 0)
                {
                    DialogResult res = MessageBox.Show("Você quer jogar agora, assim como o Jogador 1?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (res == DialogResult.OK)
                    {
                        int idGame;
                        partida p = query.First();
                        idGame = p.ID;
                        p.estado = p.estado + 1;
                        db.SaveChanges();
                        MessageBox.Show("Você decidiu jogar agora!");
                        HoldNewGameState4(idGame);
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        partida p = query.First();
                        p.estado = 7;
                        db.SaveChanges();
                        MessageBox.Show("Você decidiu não jogar agora!");
                    }
                } 
                else
                {
                    query = from u in db.partidas
                                where (u.estado == 4 && (u.player1 == idPlayer || u.player2 == idPlayer))
                                select u;

                    if (query.Count() > 0)
                    {
                        DialogResult res = MessageBox.Show("O jogo pode ser iniciado agora, mesmo?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            partida p = query.First();

                            string idGame = Convert.ToString(p.ID);
                            string idPlayer1 = Convert.ToString(p.player1);
                            string idPlayer2 = Convert.ToString(p.player2);

                            p.estado = p.estado + 1;
                            db.SaveChanges();

                            List<string> dadosWs = new List<string>();
                            dadosWs.Add(idGame);
                            dadosWs.Add(idPlayer1);
                            dadosWs.Add(idPlayer2);

                            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/newgame"), dadosWs);

                            if (String.IsNullOrEmpty(result))
                            {
                                MessageBox.Show("Não foi possível logar-se! Tente novamente, mais tarde!");
                                return;
                            }

                            if (Convert.ToBoolean(result))
                            {
                                string idOpponent;

                                if (idPlayer1.Equals(this.idPlayer))
                                {
                                    idOpponent = idPlayer2;
                                }
                                else
                                {
                                    idOpponent = idPlayer1;
                                }

                                fmdomino fd = new fmdomino(idGame, Convert.ToString(this.idPlayer), idOpponent);
                                fd.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("O Web Service retornou um resultado inválido! Abortando a operação de inicio de jogo!");
                            }
                            
                        }
                        else if (res == DialogResult.Cancel)
                        {
                            partida p = query.First();
                            p.estado = 7;
                            db.SaveChanges();
                            MessageBox.Show("Você decidiu não jogar agora!");
                        }
                    }
                }
            }
        }

        public static NewGameRequestManager GetInstance(int idPlayer)
        {
            if (NewGameRequestManager.instance == null)
            {
                NewGameRequestManager.instance = new NewGameRequestManager(idPlayer);
            }

            return NewGameRequestManager.instance;
        }

        public static void Cancel()
        {
            NewGameRequestManager.instance.timer.Dispose();
            NewGameRequestManager.instance = null;
        }
    }
}
