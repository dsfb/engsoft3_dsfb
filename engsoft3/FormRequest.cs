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
    public partial class FormRequest : Form
    {
        private int idPlayer;
        public FormRequest(int idPlayer)
        {
            this.idPlayer = idPlayer;
            InitializeComponent();
        }

        private void UpdateDataGridView()
        {
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.partidas
                            where u.estado == 0 && u.player2 == idPlayer
                            select u;

                DataTable user = new DataTable("User");
                DataColumn c0 = new DataColumn("Nome");
                DataColumn c1 = new DataColumn("E-mail");
                user.Columns.Add(c0);
                user.Columns.Add(c1);

                foreach (var x in query)
                {
                    int id = x.player1;
                    var pquery = from u in db.players
                                 where u.ID == id
                                 select u;
                    var y = pquery.FirstOrDefault();

                    DataRow row = user.NewRow();
                    row["Nome"] = y.Nome;
                    row["E-mail"] = y.Email;
                    user.Rows.Add(row);
                }

                dataGridView1.DataSource = user;
            }
        }

        private void FormRequest_Load(object sender, EventArgs e)
        {
            this.UpdateDataGridView();
        }

        private void btnAcceptRequest_Click(object sender, EventArgs e)
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
                        MessageBox.Show("Aceitando novo jogo com o jogador de id: " + id.FirstOrDefault() + " meu id: " + idPlayer);
                        partida p = db.partidas.Single(c => c.player1 == id.FirstOrDefault() && c.player2 == idPlayer && c.estado == 0);
                        
                        p.estado = 1;

                        db.SaveChanges();

                        MessageBox.Show("Pedido de novo jogo aceito!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Selecione um pedido válido antes de aceitá-lo!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um pedido antes de aceitá-lo!");
            }
        }

        private void btnRejectGameRequest_Click(object sender, EventArgs e)
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
                        MessageBox.Show("Rejeitando novo jogo com o jogador de id: " + id.FirstOrDefault() + " meu id: " + idPlayer);
                        partida p = db.partidas.Single(c => c.player1 == id.FirstOrDefault() && c.player2 == idPlayer && c.estado == 0);

                        p.estado = 2;

                        db.SaveChanges();

                        MessageBox.Show("Pedido de novo jogo rejeitado!");
                        this.UpdateDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Selecione um pedido válido antes de rejeitá-lo!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um pedido antes de rejeitá-lo!");
            }
        }
    }
}
