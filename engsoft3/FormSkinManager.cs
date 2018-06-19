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
    public partial class FormSkinManager : Form
    {
        private static byte[] selected_img_fundo_tab = null;
        private static byte[] saved_img_fundo_tab = null;
        private static int id_conj_img_pecas = -1;

        public static byte[] GetSavedImgFundoTab()
        {
            if (saved_img_fundo_tab == null)
            {
                using (var db = new dominoeng3Entities())
                {
                    var query = from u in db.img_fundo_tab
                                select u;

                    if (query.Count() > 0)
                    {
                        var first = query.First();
                        return first.conteudo_arquivo;
                    }
                }
            }

            return saved_img_fundo_tab;
        }

        public static void LoadMe()
        {
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.img_fundo_tab
                            select u;

                if (query.Count() > 0)
                {
                    var first = query.First();
                    FormSkinManager.selected_img_fundo_tab = first.conteudo_arquivo;
                }
            }
        }

        public FormSkinManager()
        {
            InitializeComponent();
        }

        private void LoadTabuleiroImage(byte[] contents)
        {
            MemoryStream ms = new MemoryStream(contents);
            pictureBoxFundoTab.Image = Image.FromStream(ms);
            pictureBoxFundoTab.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void LoadTileImage(byte[] contents)
        {
            MemoryStream ms = new MemoryStream(contents);
            pictureBoxSkinPeca.Image = Image.FromStream(ms);
            pictureBoxSkinPeca.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void PopulateComboBoxFundoTab(List<FundoTabuleiroComboBox> dataSource)
        {
            //Setup data binding
            this.cbBFundoTab.DataSource = dataSource;
            this.cbBFundoTab.DisplayMember = "Name";
            this.cbBFundoTab.ValueMember = "Value";

            // make it readonly
            this.cbBFundoTab.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void PopulateComboBoxSkinPecas(List<SkinPecaComboBox> dataSource)
        {
            //Setup data binding
            this.cbBSkinPeca.DataSource = dataSource;
            this.cbBSkinPeca.DisplayMember = "Name";
            this.cbBSkinPeca.ValueMember = "Value";

            // make it readonly
            this.cbBSkinPeca.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FormSkinManager_Load(object sender, EventArgs e)
        {
            FormSkinManager.LoadMe();
            using (var db = new dominoeng3Entities())
            {
                var query = from u in db.img_fundo_tab
                            select u;

                List<FundoTabuleiroComboBox> lista = new List<FundoTabuleiroComboBox>();
                foreach (var result in query)
                {
                    FundoTabuleiroComboBox f = new FundoTabuleiroComboBox();
                    f.Name = result.nome_fundo;
                    f.Value = result.ID.ToString();
                    lista.Add(f);
                }

                this.PopulateComboBoxFundoTab(lista);

                var query_pecas = from u in db.conj_img_pecas
                        select u;

                List<SkinPecaComboBox> lista_pecas = new List<SkinPecaComboBox>();
                foreach (var result in query_pecas)
                {
                    SkinPecaComboBox s = new SkinPecaComboBox();
                    s.Name = result.nome_conjunto;
                    s.Value = result.ID.ToString();
                    lista_pecas.Add(s);
                }

                this.PopulateComboBoxSkinPecas(lista_pecas);
            }
        }

        private void cbBFundoTab_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(((ComboBox)sender).SelectedValue);
                using (var db = new dominoeng3Entities())
                {
                    var query = from u in db.img_fundo_tab
                                where u.ID == id
                                select u;

                    if (query.Count() > 0)
                    {
                        var first = query.First();
                        FormSkinManager.selected_img_fundo_tab = first.conteudo_arquivo;
                        LoadTabuleiroImage(FormSkinManager.selected_img_fundo_tab);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (FormSkinManager.selected_img_fundo_tab != null)
            {
                saved_img_fundo_tab = FormSkinManager.selected_img_fundo_tab;
            }
            else
            {
                using (var db = new dominoeng3Entities())
                {
                    var query = from u in db.img_fundo_tab
                                select u;

                    if (query.Count() > 0)
                    {
                        var first = query.First();
                        saved_img_fundo_tab = first.conteudo_arquivo;
                    }
                }
            }

            try
            {
                id_conj_img_pecas = Convert.ToInt32(cbBSkinPeca.SelectedValue);
                MessageBox.Show("Skins salvas com sucesso!");
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível salvar a skin da peça de dominó!");
            }
        }

        private void cbBSkinPeca_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(((ComboBox)sender).SelectedValue);
                using (var db = new dominoeng3Entities())
                {
                    var query = from u in db.img_peca
                                where u.id_conjunto_pecas == id &&
                                    u.peca_num_abaixo == 0 && u.peca_num_cima == 0
                                select u;

                    if (query.Count() > 0)
                    {
                        var first = query.First();
                        LoadTileImage(first.conteudo_arquivo);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
