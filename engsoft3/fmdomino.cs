using engsoft3.requisicoes_ws;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Dictionary<Button, PieceObject> dic_but_po = new Dictionary<Button, PieceObject>();
        private string idGame;
        private string idPlayer;
        private string idOpponent;
        private string idTabuleiro;
        private List<PieceObject> lista;
        private conj_img_pecas cip;
        private img_fundo_tab ift;
        private int top = 250;
        private int left = 350;
        private int extremoA = -1;
        private int extremoB = -1;
        private int topBody = 150;
        private int leftBody = 150;

        public fmdomino(string idGame, string idPlayer, string idOpponent)
        {
            InitializeComponent();
            this.idGame = idGame;
            this.idPlayer = idPlayer;
            this.idOpponent = idOpponent;
        }

        private byte[] GetImageContent(int id_cip, int faceA, int faceB)
        {
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.img_peca
                            where u.id_conjunto_pecas == id_cip && 
                            (u.peca_num_abaixo == faceA && u.peca_num_cima == faceB)
                            select u;

                if (query.Count() == 0)
                {
                    query = from u in db.img_peca
                            where u.id_conjunto_pecas == id_cip &&
                            (u.peca_num_abaixo == faceB && u.peca_num_cima == faceA)
                            select u;

                    if (query.Count() == 0)
                    {
                        MessageBox.Show("Opa! Não foi possível carregar a imagem desejada! Id_cip: " + id_cip + " ,faces: " + faceA + "-" + faceB);
                        return new byte[] { };
                    }
                }

                var peca = query.FirstOrDefault();
                return peca.conteudo_arquivo;
            }
        }

        private void SetPieces()
        {
            List<string> dadosWs = new List<string>();
            dadosWs.Add(this.idGame);
            dadosWs.Add(this.idPlayer);
            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/get-pieces"), dadosWs);

            if (String.IsNullOrEmpty(result))
            {
                MessageBox.Show("Não foi possível pegar as suas peças! Tente novamente, mais tarde!");
                return;
            }

            lista = JsonConvert.DeserializeObject<List<PieceObject>>(result);
        }

        private Image ResizeImage(Image imgToResize, Size size)
        {
            return this.ScaleImage(imgToResize, size.Width, size.Height);
        }

        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
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

        private Image RotateImage90Degrees(Image img)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return bmp;
        }

        private void DrawTile(PieceObject po)
        {
            PictureBox pb1 = new PictureBox();
            byte[] dadosImg = this.GetImageContent(this.cip.ID, po.faceA, po.faceB);
            MemoryStream ms = new MemoryStream(dadosImg);
            Image img = Image.FromStream(ms);

            if (po.faceA != po.faceB)
            {
                img = this.RotateImage90Degrees(img);
            }
            
            Point newLoc = new Point(topBody, leftBody);
            pb1.Image = img;
            pb1.Size = img.Size;
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
            pb1.Location = newLoc;

            Controls.Add(pb1);
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

            this.SetPieces();

            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.conj_img_pecas
                            select u;

                if (query.Count() > 0)
                {
                    cip = query.FirstOrDefault();

                }
                else
                {
                    MessageBox.Show("Opa! Não existe um conjunto de imagens carregado! O jogo não irá prosseguir!");
                    return;
                }

                var query2 = from u in db.img_fundo_tab
                        select u;

                if (query2.Count() > 0)
                {
                    ift = query2.FirstOrDefault();
                }
                else
                {
                    MessageBox.Show("Opa! Não existe ao menos uma imagem de tabuleiro cadastrada! O jogo não irá prosseguir!");
                    return;
                }
            }

            foreach(var piece in lista)
            {
                Point newLoc = new Point(top, left);
                top += 55;
                Button b = new Button();

                dic_but_po[b] = piece;

                b.Size = new Size(50, 90);
                b.Location = newLoc;
                b.Click += (s, ne) => {
                    PieceObject po = dic_but_po[b];
                    MessageBox.Show("Voce quer jogar a peça: " + po.faceA + "-" + po.faceB);

                    string result;
                    if (extremoA != -1)
                    {
                        string escolha = cbBChoice.SelectedValue.ToString();
                        if (escolha.Equals("Direita"))
                        {
                            List<string> dadosWs = new List<string>();
                            dadosWs.Add(idGame);
                            dadosWs.Add(idPlayer);
                            result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/connect"), dadosWs);
                        }
                        else if (escolha.Equals("Esquerda"))
                        {
                            List<string> dadosWs = new List<string>();
                            result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/connect"), dadosWs);
                        }
                        else
                        {
                            MessageBox.Show("Escolha um sentido: Direita ou Esquerda!");
                            return;
                        }
                    }
                    else 
                    {
                        List<string> dadosWs = new List<string>();
                        dadosWs.Add(idGame);
                        dadosWs.Add(idPlayer);
                        dadosWs.Add(po.faceA.ToString());
                        dadosWs.Add(po.faceB.ToString());
                        dadosWs.Add("A");
                        result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/play"), dadosWs);
                    }
                    
                    if (String.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Não foi possível jogar-se! Tente novamente, mais tarde!");
                        return;
                    }

                    if (Convert.ToBoolean(result))
                    {
                        this.DrawTile(po);
                    }
                };

                newLoc.Offset(b.Height + 10, 0);

                byte[] dadosImg = this.GetImageContent(this.cip.ID, piece.faceA, piece.faceB);
                MemoryStream ms = new MemoryStream(dadosImg);
                Image img = Image.FromStream(ms);
                b.BackgroundImage = this.ResizeImage(img, b.Size);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.ImageAlign = ContentAlignment.MiddleRight;
                b.TextAlign = ContentAlignment.MiddleLeft;                
                Controls.Add(b);
            }
        }
    }
}
