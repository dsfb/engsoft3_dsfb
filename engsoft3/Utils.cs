using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engsoft3
{
    class Utils
    {
        private static string exe_dir_path = AppDomain.CurrentDomain.BaseDirectory;

        public static string get_img_dir()
        {
            string img_dir = exe_dir_path;
            string dir_name = "dominopecas";

            img_dir = System.IO.Path.Combine(img_dir, dir_name);
            
            return img_dir;
        }

        public static string[] get_file_names()
        {
            var files = Directory.GetFiles(Utils.get_img_dir(), "*.png");
            var file_names = new string[files.Length];
            int i = 0;
            foreach (string file in files)
            {
                file_names[i++] = Utils.get_file_name(file);
            }

            return file_names;
        }

        public static string get_file_name(string file_path)
        {
            return Path.GetFileName(file_path);
        }
    }
}
