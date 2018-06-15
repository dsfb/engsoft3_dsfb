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
                    List<string> dadosWs = new List<string>();
                    dadosWs.Add(Convert.ToString(query.First().ID));
                    dadosWs.Add(query.First().Email);
                    dadosWs.Add(txtuser.Text);
                    string idJogador = Convert.ToString(query.First().ID);
                    string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/connect"), dadosWs);
                    
                    if (String.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Não foi possível logar-se! Tente novamente, mais tarde!");
                        return;
                    }

                    if (Convert.ToBoolean(result))
                    {
                        MessageBox.Show("O id do seu jogador é: " + idJogador);
                        FormMainScreen ms = new FormMainScreen(idJogador);
                        ms.ShowDialog();
                        txtpass.Text = "";
                        txtuser.Text = "";
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("O Web Service retornou um resultado inválido! Abortando a operação de login!");
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
