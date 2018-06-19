using engsoft3.requisicoes_ws;
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
    public partial class FormRanking : Form
    {
        public FormRanking()
        {
            InitializeComponent();
        }

        private string GetPlayerName(int idPlayer)
        {
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.players
                            where u.ID == idPlayer
                            select u;

                if (query.Count() == 1)
                {
                    var x = query.First();

                    return x.Nome;
                }
            }

            return "";
        }

        private string GetPlayerEmail(int idPlayer)
        {
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.players
                            where u.ID == idPlayer
                            select u;

                if (query.Count() == 1)
                {
                    var x = query.First();

                    return x.Email;
                }
            }

            return "";
        }

        private void LoadAllData()
        {
            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/get-all-rankings"));

            if (String.IsNullOrEmpty(result))
            {
                MessageBox.Show("Opa! Não foi possível carregar os dados de Ranking! Tente mais tarde novamente!");
                return;
            }

            List<RankingObject> l = JsonConvert.DeserializeObject<List<RankingObject>>(result);

            if (l.Count() == 0)
            {
                MessageBox.Show("Sem rankings disponíveis!");
                return;
            }

            DataTable rankingTable = new DataTable("Ranking");
            DataColumn c0 = new DataColumn("Ranking");
            DataColumn c1 = new DataColumn("Nome");
            DataColumn c2 = new DataColumn("E-mail");
            DataColumn c3 = new DataColumn("Vitórias");
            DataColumn c4 = new DataColumn("Partidas Jogadas");
            rankingTable.Columns.Add(c0);
            rankingTable.Columns.Add(c1);
            rankingTable.Columns.Add(c2);
            rankingTable.Columns.Add(c3);
            rankingTable.Columns.Add(c4);

            int rankingPos = 1;

            foreach (RankingObject ro in l)
            {
                DataRow row = rankingTable.NewRow();
                row["Ranking"] = rankingPos;

                row["Nome"] = this.GetPlayerName(ro.player);
                row["E-mail"] = this.GetPlayerEmail(ro.player);
                row["Vitórias"] = ro.vitorias;
                row["Partidas Jogadas"] = ro.partidas_jogadas;
                rankingTable.Rows.Add(row);
                rankingPos++;
            }

            dataGridView1.DataSource = rankingTable;
        }

        private void FormRanking_Load(object sender, EventArgs e)
        {
            this.LoadAllData();
        }

        private void btnSearchRanking_Click(object sender, EventArgs e)
        {
            this.LoadAllData();
            string ranking = txtSearchRanking.Text;

            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataRow desired = null;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Ranking"].ToString().Equals(ranking))
                {
                    desired = row;
                }
            }

            DataTable rankingTable = new DataTable("Ranking");
            DataColumn c0 = new DataColumn("Ranking");
            DataColumn c1 = new DataColumn("Nome");
            DataColumn c2 = new DataColumn("E-mail");
            DataColumn c3 = new DataColumn("Vitórias");
            DataColumn c4 = new DataColumn("Partidas Jogadas");
            rankingTable.Columns.Add(c0);
            rankingTable.Columns.Add(c1);
            rankingTable.Columns.Add(c2);
            rankingTable.Columns.Add(c3);
            rankingTable.Columns.Add(c4);

            if (desired != null)
            {
                DataRow row = rankingTable.NewRow();
                row["Ranking"] = 1;

                row["Nome"] = desired["Nome"];
                row["E-mail"] = desired["E-mail"];
                row["Vitórias"] = desired["Vitórias"];
                row["Partidas Jogadas"] = desired["Partidas Jogadas"];
                rankingTable.Rows.Add(row);
            }

            dataGridView1.DataSource = rankingTable;
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            this.LoadAllData();
            string nome = txtSearchPlayer.Text;

            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataRow desired = null;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Nome"].ToString().Equals(nome))
                {
                    desired = row;
                }
            }

            DataTable rankingTable = new DataTable("Ranking");
            DataColumn c0 = new DataColumn("Ranking");
            DataColumn c1 = new DataColumn("Nome");
            DataColumn c2 = new DataColumn("E-mail");
            DataColumn c3 = new DataColumn("Vitórias");
            DataColumn c4 = new DataColumn("Partidas Jogadas");
            rankingTable.Columns.Add(c0);
            rankingTable.Columns.Add(c1);
            rankingTable.Columns.Add(c2);
            rankingTable.Columns.Add(c3);
            rankingTable.Columns.Add(c4);

            if (desired != null)
            {
                DataRow row = rankingTable.NewRow();
                row["Ranking"] = 1;

                row["Nome"] = desired["Nome"];
                row["E-mail"] = desired["E-mail"];
                row["Vitórias"] = desired["Vitórias"];
                row["Partidas Jogadas"] = desired["Partidas Jogadas"];
                rankingTable.Rows.Add(row);
            }

            dataGridView1.DataSource = rankingTable;
        }

        private void btnReloadAll_Click(object sender, EventArgs e)
        {
            this.LoadAllData();
        }
    }
}
