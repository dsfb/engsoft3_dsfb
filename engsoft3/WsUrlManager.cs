using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engsoft3
{
    public class WsUrlManager
    {
        /*
         https://agora-vai.herokuapp.com/domino/connect
         http://localhost:10000/DominoWebService/domino/connect
         */
        /*
         public const string address = "https://agora-vai.herokuapp.com";
         public const string port = "";
         */
        public const string address = "http://localhost";
        public const string port = "10000";
        public const string preSufixo = "/DominoWebService/domino";

        public static string GetUrl(string sufixo)
        {
            StringBuilder sb = new StringBuilder(address);
            if (port.Length > 0)
            {
                sb.Append(":").Append(port);
            }
            sb.Append(preSufixo);
            if (!sufixo.StartsWith("/"))
            {
                sb.Append("/");
            }

            sb.Append(sufixo);

             return sb.ToString();
        }
    }
}
