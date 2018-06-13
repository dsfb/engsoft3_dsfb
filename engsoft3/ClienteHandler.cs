using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engsoft3
{
    class ClienteHandler
    {
        private ClienteHandler()
        {

        }

        private static readonly ClienteHandler _singleton = new ClienteHandler();

        public static ClienteHandler GetSingleton()
        {
            return _singleton;
        }

        private string ConString = "Data Source=den1.mssql1.gear.host;Persist Security Info=True;User ID=dominoeng3;Password=Sg68Vox_O0a?";
        private SqlConnection conn { get; set; }
        private string errorMessage { get; set; }

        public string GetErrorMessage()
        {
            return this.errorMessage;
        }

        private void OpenConnection()
        {
            try
            {
                if (this.conn != null)
                {
                    this.conn.Close();
                    this.conn.Dispose();
                }

                this.conn = new SqlConnection(this.ConString);
                this.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Opa! Ocorreu um erro na operação 'OpenConnection'");
            }

        }

        private void CloseConnection()
        {
            this.conn.Close();
            this.conn.Dispose();
        }

        public bool InsertPlayer(string playerName, string playerEmail, int playerAge, string playerSenha)
        {
            try
            {
                this.OpenConnection();

                string sql = "INSERT INTO player (Nome, Email, Idade, senha) VALUES (@val_nome, @val_email, @val_idade, @val_senha);";

                SqlCommand cmd = new SqlCommand(sql, this.conn);
                cmd.Parameters.Add("@val_nome", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@val_email", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@val_idade", SqlDbType.Int, 50);
                cmd.Parameters.Add("@val_senha", SqlDbType.VarChar, 20);
                cmd.Parameters["@val_nome"].Value = playerName;
                cmd.Parameters["@val_email"].Value = playerEmail;
                cmd.Parameters["@val_idade"].Value = playerAge;
                cmd.Parameters["@val_senha"].Value = playerSenha;
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                this.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                this.errorMessage = ex.Message;
                MessageBox.Show("Ocorreu um erro ao inserir um jogador no BD: " + ex.Message);

                this.CloseConnection();

                return false;
            }
        }

        public bool InsertRanking(int rank, int idPlayer, int playedGames)
        {
            try
            {
                this.OpenConnection();

                string sql = "INSERT INTO ranking (ranking, player, partidas_jogadas) VALUES (@val_rank, @val_id_play, @val_played_game);";

                SqlCommand cmd = new SqlCommand(sql, this.conn);

                cmd.Parameters.Add("@val_rank", SqlDbType.Int, 50);
                cmd.Parameters.Add("@val_id_play", SqlDbType.Int, 50);
                cmd.Parameters.Add("@val_played_game", SqlDbType.Int, 50);
                cmd.Parameters["@val_rank"].Value = rank;
                cmd.Parameters["@val_id_play"].Value = idPlayer;
                cmd.Parameters["@val_played_game"].Value = playedGames;
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                this.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                this.errorMessage = ex.Message;

                MessageBox.Show("Ocorreu um erro ao inserir um ranking no BD: " + ex.Message);

                this.CloseConnection();

                return false;
            }
        }
    }
}
