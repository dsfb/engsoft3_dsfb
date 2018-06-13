using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engsoft3
{
    class TileDataCreator
    {
        public TileData createTileData(string fileName)
        {
            string filePath = Path.Combine(Utils.get_img_dir(), fileName);
            TileData td = new TileData(filePath);
            string str = fileName.Substring(0, fileName.LastIndexOf("."));
            string[] tokens = str.Split('p');
            MessageBox.Show("Você tem: " + tokens[0] + " e " + tokens[1] + "!");

            return td;
        }

    }
}
