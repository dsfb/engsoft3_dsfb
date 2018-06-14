using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engsoft3.requisicoes_ws
{
    public class RequisicoesRestWS
    {
        private static string ConstroiString(string url, List<string> list)
        {
            StringBuilder sb = new StringBuilder(url);

            // Loop through List with foreach.
            foreach (string str in list)
            {
                sb.Append("/").Append(str);
            }

            return sb.ToString();
        }

        public static string ObterRequisicao(string url, List<string> list)
        {
            string urlFinal = ConstroiString(url, list);
            return ObterRequisicao(urlFinal);
        }

        public static string ObterRequisicao(string url)
        {
            try
            {
                var request =
                (HttpWebRequest)WebRequest.Create(url);

                var response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Erro ao tentar fazer a requisição: {ex.Message}");
            }
        }

        public static string custodiaRequisicao(string url)
        {
            return custodiaRequisicao(url, new List<string>());
        }

        public static string custodiaRequisicao(string url, List<string> urls)
        {
            int tentativas = 0;
            while (tentativas < 5)
            {
                try
                {
                    //return RequisicoesRestWS.ObterRequisicao("https://agora-vai.herokuapp.com/domino/connect");
                    return RequisicoesRestWS.ObterRequisicao(url, urls);
                }
                catch (System.Exception ex)
                {
                    tentativas++;
                }
            }

            MessageBox.Show("Falha ao conectar-se com o WS!");
            return "";
        }
    }
}
