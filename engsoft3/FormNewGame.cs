﻿using engsoft3.requisicoes_ws;
using Newtonsoft.Json;
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
        private static string previousResult = null;
        private static Dictionary<int, PlayerObject> poDic = new Dictionary<int, PlayerObject>();
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

        private void FormNewGame_Load(object sender, EventArgs e)
        {
            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/get-free-players/"));

            if (String.IsNullOrEmpty(result))
            {
                MessageBox.Show("Opa! Não foi possível carregar os dados de jogadores disponíveis para um novo jogo! Tente mais tarde novamente!");
                if (String.IsNullOrEmpty(previousResult))
                {
                    return;
                }

                result = previousResult;
                MessageBox.Show("Mostrando resultados previamente salvos...!");
            }

            if (String.IsNullOrEmpty(previousResult))
            {
                previousResult = result;
            }

            Dictionary<int, PlayerObject> dic = JsonConvert.DeserializeObject<Dictionary<int, PlayerObject>>(result);
            if (dic.ContainsKey(Convert.ToInt32(this.idPlayer)))
            {
                dic.Remove(Convert.ToInt32(this.idPlayer));
            }

            if (dic.Count() > 0)
            {
                poDic = dic;

                DataTable user = new DataTable("User");
                DataColumn c0 = new DataColumn("Nome");
                DataColumn c1 = new DataColumn("E-mail");
                user.Columns.Add(c0);
                user.Columns.Add(c1);

                foreach (var x in dic)
                {
                    PlayerObject po = x.Value;

                    DataRow row = user.NewRow();
                    row["Nome"] = po.name;
                    row["E-mail"] = po.email;
                    user.Rows.Add(row);
                }

                dataGridView1.DataSource = user;

                labelOponentes.Text = "Existem jogadores disponíveis!";
            }
            else
            {
                DataTable user = new DataTable("User");
                DataColumn c0 = new DataColumn("Nome");
                DataColumn c1 = new DataColumn("E-mail");
                user.Columns.Add(c0);
                user.Columns.Add(c1);

                dataGridView1.DataSource = user;

                labelOponentes.Text = "Sem jogadores disponíveis!";
            }


            

            

            
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string email = Convert.ToString(selectedRow.Cells["E-mail"].Value);
                string nome = Convert.ToString(selectedRow.Cells["Nome"].Value);

                using (var db = new dominoeng3Entities())
                {
                    var id = db.players.Where(x => x.Nome == nome).Select(x => x.ID);
                    if (id.Count() > 0)
                    {
                        MessageBox.Show("Pedindo novo jogo com o jogador de id: " + id.First() + " meu id: " + idPlayer);
                        var partidas = db.Set<partida>();
                        partidas.Add(new partida { player1 = Convert.ToInt32(idPlayer), player2 = Convert.ToInt32(id.First()), resultado = "" });
                        db.SaveChanges();

                        MessageBox.Show("Pedido de novo jogo feito!");
                    }                    
                }
            }
                
            
        }

        private void btnManageNewGameRequest_Click(object sender, EventArgs e)
        {

        }
    }
}
