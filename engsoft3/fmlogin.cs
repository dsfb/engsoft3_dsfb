using engsoft3.requisicoes_ws;
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
                    bool getIdJogador = false;
                    int tentativas = 0;
                    string idJogador = "";
                    while (!getIdJogador && tentativas < 5)
                    {
                        try
                        {
                            idJogador = RequisicoesRestWS.ObterRequisicao("https://agora-vai.herokuapp.com/domino/connect");
                            int idPlayer;
                            if (Int32.TryParse(idJogador, out idPlayer))
                            {
                                getIdJogador = true;
                                MessageBox.Show("O id do seu jogador é: " + idJogador);
                            }
                            else
                            {
                                MessageBox.Show("Erro! O WS retornou um id de jogador inválido!");
                            }
                        }
                        catch (System.Exception ex)
                        {
                            tentativas++;
                        }
                    }

                    if (tentativas == 5)
                    {
                        MessageBox.Show("Falha ao conectar-se com o WS!");
                    }
                    else
                    {
                        FormMainScreen ms = new FormMainScreen(idJogador);
                        ms.ShowDialog();
                        txtpass.Text = "";
                        txtuser.Text = "";
                        this.Show();
                    }
                } else
                {
                    MessageBox.Show("Nome e senha de usuário inválidos!");
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
