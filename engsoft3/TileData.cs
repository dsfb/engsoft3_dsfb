using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engsoft3
{
    class TileData
    {
        private string nome_arq;
        private int[] numeros;

        public TileData(string nome_arq)
        {
            NomeArquivo = nome_arq;

        }

        public string NomeArquivo
        {
            get
            {
                return this.nome_arq;
            }

            set
            {
                this.nome_arq = value;
            }
        }

        //public 
    }
}
