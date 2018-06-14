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

        private void FormNewGame_Load(object sender, EventArgs e)
        {
            DataTable user = new DataTable("User");
            DataColumn c0 = new DataColumn("Nome");
            DataColumn c1 = new DataColumn("E-mail");
            user.Columns.Add(c0);
            user.Columns.Add(c1);

            using (var context = new dominoeng3Entities())
            {
                var players = from p in context.players
                              where !p.ID.ToString().Equals(this.idPlayer)
                              select p;
                foreach (var player in players)
                {
                    DataRow row = user.NewRow();
                    row["Nome"] = player.Nome;
                    row["E-mail"] = player.Email;
                    user.Rows.Add(row);
                }
            }

            dataGridView1.DataSource = user;
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
    }
}
