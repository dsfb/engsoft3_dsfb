using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engsoft3
{
    public partial class fmdomino : Form
    {
        private bool initialized = false;
        private int[] allowed_numbers = new int[2];
        private Dictionary<Button, string> dic_but_str = new Dictionary<Button, string>();
        private string idGame;
        private string idPlayer;
        private string idOpponent;


        public fmdomino(string idGame, string idPlayer, string idOpponent)
        {
            InitializeComponent();
            this.idGame = idGame;
            this.idPlayer = idPlayer;
            this.idOpponent = idOpponent;
        }

        public string ranimg()
        {
            //Buscando imagens aleatórias, -: futuramente peças inicializadas no banco
            var rand = new Random(DateTime.Now.Millisecond);
            var files = Directory.GetFiles(Utils.get_img_dir(), "*.png");                                           
            return files[rand.Next(files.Length)];
        }

        private Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void playDominoTile()
        {
            bool condition = !this.initialized;

            if (condition)
            {

            }
            else
            {
                condition = true;
            }
        }

        private void fmdomino_Load(object sender, EventArgs e)
        {
            //Inicia com as peças iniciais + peça central.
            /*Os códigos de botões novos terão de ser criados aqui
            Pensei que criar peças novas usando as funções 
            E nessas mesmas funções colocar os pensamentos lógicos de 
            posicionamento certo ou errado.*/
            /*As peças serão inicializadas com structs identificando
             * a cabeça e o final da peça */
            /* As peças podem ser cadastradas no banco de dados */



            Point newLoc = new Point(250, 350);
            for (int i = 0; i < 5; ++i)
            {
                string filePath = ranimg();
                Button b = new Button();

                dic_but_str[b] = filePath;

                b.Size = new Size(50, 90);
                b.Location = newLoc;
                b.Click += (s, ne) => {
                    string file_name = Utils.get_file_name(dic_but_str[b]);
                    TileData td = TileDataStorage.GetTileData(file_name);


                };
                newLoc.Offset(b.Height + 10, 0);




                b.BackgroundImage = Image.FromFile(filePath);
                b.ImageAlign = ContentAlignment.MiddleRight;
                b.TextAlign = ContentAlignment.MiddleLeft;
                Controls.Add(b);
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
