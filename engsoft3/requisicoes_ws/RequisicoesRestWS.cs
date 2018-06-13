using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace engsoft3.requisicoes_ws
{
    public class RequisicoesRestWS
    {
        public static string BuildString(string url, List<string> list)
        {
            StringBuilder sb = new StringBuilder(url);

            // Loop through List with foreach.
            foreach (string str in list)
            {
                sb.Append(str);
            }

            return sb.ToString();
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
    }
}
