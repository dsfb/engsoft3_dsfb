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
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        private int topBody_left = 100;
        private int leftBody_left = 450;
        private int topBody_right = 100;
        private int leftBody_right = 450;
        private List<Button> btnPieces = new List<Button>();
        private int esquerdaState = 0, direitaState = 0;
        private bool esquerdaEqual = false, direitaEqual = false;
        private bool firstEsquerdaState1 = false;
        private bool firstDireitaState1 = false;
        private bool firstEsquerdaState2 = false;
        private bool firstDireitaState2 = false;
        private int lastWidthDireita = 0;
        private int lastWidthEsquerda = 0;
        private System.Timers.Timer aTimer = new System.Timers.Timer();
        private PieceObject lastPiece;
        private bool firstMessage = true;
        private PictureBox lastPictureBox;
        private PieceObject lastPo;
        private string lastValor;
        private Boolean running = false;

        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            int winnerGame = GetWinnerGame();
            ManageWinnerGame(winnerGame);

            ManageLastPiece();

            ManageNumTilesEnemy();
        }

        private void ManageNumTilesEnemy()
        {
            List<string> dadosWs = new List<string>();
            dadosWs.Add(idGame);
            dadosWs.Add(idPlayer);
            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/get-num-tiles-enemy"), dadosWs);

            if (String.IsNullOrEmpty(result))
            {
                ShowMsg("Falha ao obter o número de peças do adversário!");
                return;
            }

            lblPecaAdvers.Text = result;
        }

        private void ManageWinnerGame(int winnerGame)
        {
            if (winnerGame == 3)
            {
                return;
            }
            else if (winnerGame == 1)
            {
                MessageBox.Show("Você ganhou! Parabéns!");
                lblStatus.Text = "Vitória!";
                aTimer.Enabled = false;
                DisableButtons();
            }
            else if (winnerGame == 2)
            {
                MessageBox.Show("Você perdeu! Tente outra vez!");
                lblStatus.Text = "Derrota!";
                aTimer.Enabled = false;
                DisableButtons();
            }
            else if (winnerGame == 0)
            {
                return;
            }
        }

        private void DisableButtons()
        {
            foreach (var b in btnPieces)
            {
                b.Enabled = false;
            }
        }

        private void ShowMsg(string msg)
        {
            if (firstMessage)
            {
                MessageBox.Show(msg);
                firstMessage = false;
            }
        }

        /*
        Retorna 0 se a partida está em andamento,
            1 se você ganhou,
            2 se o adversário ganhou,
            3 se deu erro!
             */
        private int GetWinnerGame()
        {
            List<string> dadosWs = new List<string>();
            dadosWs.Add(idGame);
            dadosWs.Add(idPlayer);
            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/is-winner"), dadosWs);

            if (String.IsNullOrEmpty(result))
            {
                ShowMsg("Falha ao obter o Ganhador, vc!");
                return 3;
            }

            if (Convert.ToBoolean(result))
            {
                dadosWs = new List<string>();
                dadosWs.Add(idGame);
                result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/endgame"), dadosWs);

                if (String.IsNullOrEmpty(result))
                {
                    ShowMsg("Falha ao fechar o Jogo!");
                    return 3;
                }

                if (!Convert.ToBoolean(result))
                {
                    ShowMsg("Não foi possível fechar o jogo!");
                }

                return 1;
            } else
            {
                dadosWs = new List<string>();
                dadosWs.Add(idGame);
                dadosWs.Add(idPlayer);
                result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/is-winner"), dadosWs);

                if (String.IsNullOrEmpty(result))
                {
                    ShowMsg("Falha ao obter o Ganhador, ele(a)!");
                    return 3;
                }

                if (Convert.ToBoolean(result))
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
        }

        private string GetSelectedDirectionComboBoxValue()
        {
            try
            {
                return cbBChoice.SelectedValue.ToString();
            }
            catch (NullReferenceException)
            {
                return "Esquerda";
            }
        }

        private void ManageLastPiece()
        {
            List<string> dadosWs = new List<string>();
            dadosWs.Add(this.idGame);
            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/get-last-played-piece"), dadosWs);

            if (String.IsNullOrEmpty(result))
            {
                ShowMsg("Não foi possível pegar a última peça! Tente novamente, mais tarde!");
                return;
            }

            PieceObject po = JsonConvert.DeserializeObject<PieceObject>(result);

            dadosWs = new List<string>();
            dadosWs.Add(this.idGame);
            result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/get-last-extreme-side"), dadosWs);

            if (String.IsNullOrEmpty(result))
            {
                ShowMsg("Não foi possível pegar o último lado! Tente novamente, mais tarde!");
                return;
            }
            
            this.AddBodyGame(po, result);
        }

        private void AddBodyGame(PieceObject po, String es)
        {
            if (po.Equals(lastPiece))
            {
                return;
            }

            this.DrawTile(po, es);
        }

        public fmdomino(string idGame, string idPlayer, string idOpponent)
        {
            InitializeComponent();
            this.idGame = idGame;
            this.idPlayer = idPlayer;
            this.idOpponent = idOpponent;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
            this.lblStatus.Text = "Andamento!";
            this.Text = "Jogo de Dominó - Seu ID: " + idPlayer;
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
                        if (faceA != -1 || faceB != -1)
                        {
                            ShowMsg("Opa! Não foi possível carregar a imagem desejada! Id_cip: " + id_cip + " ,faces: " + faceA + "-" + faceB);
                        }
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

        private void AddPieceToPlayer(PieceObject piece)
        {
            Point newLoc = new Point(top, left);
            top += 55;
            Button b = new Button();

            dic_but_po[b] = piece;

            b.Size = new Size(30, 40);
            b.Location = newLoc;
            b.Click += (s, ne) => {
                if (CanPlayAlone())
                {
                    PieceObject po = dic_but_po[b];
                    MessageBox.Show("Voce quer jogar a peça: " + po.faceA + "-" + po.faceB);

                    string result;
                    if (extremoA != -1)
                    {
                        string escolha = this.GetSelectedDirectionComboBoxValue();
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
                        string escolha = this.GetSelectedDirectionComboBoxValue();
                        if (String.IsNullOrEmpty(escolha))
                        {
                            escolha = "Esquerda";
                        }

                        this.DrawTile(po, escolha);

                        if (!this.initialized)
                        {
                            this.initialized = true;
                        }

                        Controls.Remove(b);
                        btnPieces.Remove(b);

                        if (btnPieces.Count() > 0)
                        {
                            Button lb = btnPieces.Last();
                            lb.Location = b.Location;
                        }
                    }
                }
                else if (CanPlayBuying())
                {
                    MessageBox.Show("Compre novas peças!");
                }
                else
                {
                    MessageBox.Show("Aguarde a sua vez!");
                }
            };

            if (b.Location.X < 850)
            {
                newLoc.Offset(b.Height + 10, 0);
            }
            else
            {
                newLoc = new Point(150, 350);
                newLoc.Offset(0, b.Height + 25);
            }

            byte[] dadosImg = this.GetImageContent(this.cip.ID, piece.faceA, piece.faceB);
            MemoryStream ms = new MemoryStream(dadosImg);
            Image img = Image.FromStream(ms);
            b.BackgroundImage = this.ResizeImage(img, b.Size);
            b.BackgroundImageLayout = ImageLayout.Stretch;
            b.ImageAlign = ContentAlignment.MiddleRight;
            b.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(b);
            btnPieces.Add(b);
        }

        private Boolean CanPlayAlone()
        {
            List<string> dadosWs = new List<string>();
            dadosWs.Add(this.idGame);
            dadosWs.Add(this.idPlayer);
            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/can-play"), dadosWs);

            if (String.IsNullOrEmpty(result))
            {
                ShowMsg("Não foi possível ver se posso jogar sem comprar peças!");
                return false;
            }

            return Convert.ToBoolean(result);
        }

        private Boolean CanPlayBuying()
        {
            List<string> dadosWs = new List<string>();
            dadosWs.Add(this.idGame);
            dadosWs.Add(this.idPlayer);
            string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/can-play-buying"), dadosWs);

            if (String.IsNullOrEmpty(result))
            {
                ShowMsg("Não foi possível ver se posso jogar comprando peças!");
                return false;
            }

            return Convert.ToBoolean(result);
        }

        private void btnBuyPiece_Click(object sender, EventArgs e)
        {
            if (!CanPlayAlone() && CanPlayBuying())
            {
                List<string> dadosWs = new List<string>();
                dadosWs.Add(this.idGame);
                dadosWs.Add(this.idPlayer);
                string result = RequisicoesRestWS.CustodiaRequisicao(WsUrlManager.GetUrl("/buy"), dadosWs);

                if (String.IsNullOrEmpty(result))
                {
                    ShowMsg("Não foi possível comprar uma nova peça!");
                    return;
                }

                PieceObject po = JsonConvert.DeserializeObject<PieceObject>(result);
                this.AddPieceToPlayer(po);
            } 
            else
            {
                MessageBox.Show("Ação não permitida!");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PieceObject po = lastPo;
            string valor = lastValor;
            bool equal = po.faceA == po.faceB;
            PictureBox pb1 = new PictureBox();

            if (po.faceA == -1 || po.faceB == -1)
            {
                return;
            }

            byte[] dadosImg = this.GetImageContent(this.cip.ID, po.faceA, po.faceB);
            MemoryStream ms = new MemoryStream(dadosImg);
            Image img = Image.FromStream(ms);

            Size size = new Size(46, 86);
            img = ResizeImage(img, size);

            if (!equal)
            {
                img = this.RotateImage90Degrees(img);
            }

            Point newLoc = new Point(leftBody_left, topBody_left);
            pb1.Image = img;
            pb1.Size = img.Size;

            if (!this.initialized)
            {
                pb1.Location = newLoc;
                esquerdaEqual = direitaEqual = equal;
            }
            else
            {

                //string valor = (string)cbBChoice.SelectedItem;

                if (String.IsNullOrEmpty(valor))
                {
                    valor = "Esquerda";
                }

                if (valor.Equals("Esquerda"))
                {
                    // Segue a rota original!
                    if (esquerdaState == 0)
                    {
                        if (!equal)
                        {
                            if (esquerdaEqual)
                            {
                                newLoc.Offset(-img.Width, 17);
                            }
                            else
                            {
                                newLoc.Offset(-img.Width, 0);
                            }
                        }
                        else
                        {
                            newLoc.Offset(-46, -17);
                        }

                        if (newLoc.X < 0)
                        {
                            if (!equal)
                            {
                                img = this.RotateImage90Degrees(img);
                                pb1.Image = img;
                                pb1.Size = img.Size;
                            }

                            if (!equal)
                            {
                                if (esquerdaEqual)
                                {
                                    newLoc.Offset(82, 67);
                                }
                                else
                                {
                                    newLoc.Offset(82, 44);
                                }
                            }
                            else
                            {
                                newLoc.Offset(28, 64);
                            }
                            esquerdaState = 1;
                            firstEsquerdaState1 = true;
                        }
                    }
                    else if (esquerdaState == 1) // Desce
                    {
                        if (!equal || !firstEsquerdaState1)
                        {
                            img = this.RotateImage90Degrees(img);
                            pb1.Image = img;
                            pb1.Size = img.Size;
                        }

                        if (!equal)
                        {
                            if (esquerdaEqual)
                            {
                                if (firstEsquerdaState1 == true)
                                {
                                    newLoc.Offset(-15, 74);
                                }
                                else
                                {
                                    newLoc.Offset(0, 74);
                                }
                            }
                            else
                            {
                                newLoc.Offset(0, 74);
                            }
                        }
                        else
                        {
                            newLoc.Offset(15, 74);
                        }

                        if (newLoc.Y > 75)
                        {
                            newLoc.Offset(0, 10);
                            esquerdaState = 2;
                            firstEsquerdaState2 = true;
                        }

                        if (firstEsquerdaState1 == true)
                        {
                            firstEsquerdaState1 = false;
                        }
                    }
                    else if (esquerdaState == 2) // Segue a rota invertida
                    {
                        if (!equal)
                        {
                            if (firstEsquerdaState2)
                            {
                                if (esquerdaEqual)
                                {
                                    newLoc.Offset(img.Width, 17);
                                }
                                else
                                {
                                    newLoc.Offset(45, 29);
                                }

                                firstEsquerdaState2 = false;
                            }
                            else
                            {
                                if (esquerdaEqual)
                                {
                                    newLoc.Offset(45, 17);
                                }
                                else
                                {
                                    newLoc.Offset(img.Width, 0);
                                }
                            }

                        }
                        else
                        {
                            if (firstEsquerdaState2)
                            {
                                img = this.RotateImage90Degrees(img);
                                pb1.Image = img;
                                pb1.Size = img.Size;
                                newLoc.Offset(55, 40);
                                firstEsquerdaState2 = false;
                                equal = false;
                            }
                            else
                            {
                                newLoc.Offset(84, -16);
                            }
                        }
                    }
                    esquerdaEqual = equal;
                    leftBody_left = newLoc.X;
                    topBody_left = newLoc.Y;
                }
                else if (valor.Equals("Direita"))
                {
                    newLoc = new Point(leftBody_right, topBody_right);
                    // Segue a rota original!
                    if (direitaState == 0)
                    {
                        if (topBody_right == 100 && leftBody_right == 450)
                        {
                            newLoc.Offset(45, 17);
                        }
                        else if (!equal)
                        {
                            if (direitaEqual)
                            {
                                newLoc.Offset(79, 17);
                            }
                            else
                            {
                                newLoc.Offset(img.Width, 0);
                            }
                        }
                        else
                        {
                            newLoc.Offset(85, -17);
                        }

                        if (newLoc.X > 850)
                        {
                            if (!equal)
                            {
                                img = this.RotateImage90Degrees(img);
                                pb1.Image = img;
                                pb1.Size = img.Size;
                            }

                            if (!equal)
                            {
                                if (direitaEqual)
                                {
                                    newLoc.Offset(-82, 67);
                                }
                                else
                                {
                                    newLoc.Offset(-82, 44);
                                }
                            }
                            else
                            {
                                newLoc.Offset(-28, 64);
                            }
                            direitaState = 1;
                        }
                    }
                    else if (direitaState == 1) // Desce
                    {
                        if (!equal || !firstDireitaState1)
                        {
                            img = this.RotateImage90Degrees(img);
                            pb1.Image = img;
                            pb1.Size = img.Size;
                        }

                        if (!equal)
                        {
                            if (direitaEqual)
                            {
                                newLoc.Offset(0, 74);
                            }
                            else
                            {
                                if (firstDireitaState1 == true)
                                {
                                    newLoc.Offset(45, 74);
                                }
                                else
                                {
                                    newLoc.Offset(0, 74);
                                }
                            }
                        }
                        else
                        {
                            newLoc.Offset(0, 74);
                        }

                        if (newLoc.Y > 75)
                        {
                            newLoc.Offset(0, 10);
                            direitaState = 2;
                            firstDireitaState2 = true;
                        }

                        if (firstDireitaState1 == true)
                        {
                            firstDireitaState1 = false;
                        }
                    }
                    else if (direitaState == 2) // Segue a rota invertida
                    {
                        if (!equal)
                        {
                            if (firstDireitaState2)
                            {
                                if (direitaEqual)
                                {
                                    newLoc.Offset(-img.Width, 17);
                                }
                                else
                                {
                                    newLoc.Offset(-85, 29);
                                }

                                firstDireitaState2 = false;
                            }
                            else
                            {
                                if (direitaEqual)
                                {
                                    newLoc.Offset(-85, 17);
                                }
                                else
                                {
                                    newLoc.Offset(-img.Width, 0);
                                }
                            }
                        }
                        else
                        {
                            if (firstDireitaState2)
                            {
                                img = this.RotateImage90Degrees(img);
                                pb1.Image = img;
                                pb1.Size = img.Size;
                                newLoc.Offset(-80, 30);
                                firstEsquerdaState2 = false;
                            }
                            else
                            {
                                newLoc.Offset(-45, -16);
                            }
                        }
                    }
                    direitaEqual = equal;
                    leftBody_right = newLoc.X;
                    topBody_right = newLoc.Y;
                }
                pb1.Location = newLoc;
            }

            this.lastPictureBox = pb1;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (lastPictureBox != null)
            {
                Controls.Add(lastPictureBox);
            }
            this.running = false;
        }

        private void DrawTile(PieceObject po, string valor)
        {
            lastPo = po;
            lastValor = valor;
            while (this.running)
            {
                Thread.Sleep(10);
            }
            backgroundWorker1.RunWorkerAsync();
            this.running = true;
        }

        private void fmdomino_Load(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream(FormSkinManager.GetSavedImgFundoTab());
            this.BackgroundImage = Image.FromStream(ms);

            int id_cjto_img_pecas = FormSkinManager.GetIdConjImgPecas();

            PictureBox.CheckForIllegalCrossThreadCalls = false;

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
                            where u.ID == id_cjto_img_pecas
                            select u;

                if (query.Count() > 0)
                {
                    cip = query.FirstOrDefault();

                }
                else
                {
                    query = from u in db.conj_img_pecas
                            select u;

                    if (query.Count() > 0)
                    {
                        cip = query.FirstOrDefault();

                    }
                    else
                    {
                        MessageBox.Show("Erro! Nenhum conjunto de imagem foi carregado!");
                    }
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
                this.AddPieceToPlayer(piece);
            }
        }
    }
}
