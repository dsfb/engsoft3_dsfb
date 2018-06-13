using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engsoft3
{
    class TileDataStorage
    {
        private Dictionary<string, TileData> storage_dic;
        private string[] file_names = Utils.get_file_names();

        private TileDataStorage()
        {
            TileDataCreator tdc = new TileDataCreator();
            storage_dic = new Dictionary<string, TileData>();
            foreach(string file_name in file_names)
            {
                storage_dic[file_name] = tdc.createTileData(file_name);
            }
        }

        private static readonly TileDataStorage _singleton = new TileDataStorage();

        public static TileDataStorage GetTileDataStorage()
        {
            return _singleton;
        }

        public static TileData GetTileData(string file_name)
        {
            return GetTileDataStorage().storage_dic[file_name];
        }

        public static string[] GetFileNames()
        {
            return GetTileDataStorage().file_names;
        }
    }
}
