using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;

namespace TPDDSGrupo44.Models
{
    public class GetJsonBanks
    {
        public class Bank
        {
            public string banco { get; set; }
            public double x { get; set; }
            public double y { get; set; }
            public string sucursal { get; set; }
            public string gerente { get; set; }
            public List<string> servicios { get; set; }
        }


        public List<Bank> requestBanks(string banco, string servicio)
        {
            string jsonData = getJsonData(banco, servicio);

            List<Bank> banks = JsonConvert.DeserializeObject<List<Bank>>(jsonData);
            return banks;
        }


        private string getJsonData(string banco, string servicio)
        {
            string url = "http://trimatek.org/Consultas/banco?banco=" + banco + "&servicio=" + servicio;
            var jsonString = string.Empty;
            var client = new WebClient();

            jsonString = client.DownloadString(url);

            return jsonString;
        }

    }
}





