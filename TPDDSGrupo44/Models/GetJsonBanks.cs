using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Globalization;
using System.Web.Mvc;

namespace TPDDSGrupo44.Models
{
    public class GetJsonBanks : Controller
    {
        private static List<JsonBank> getJsonData(string bank, string service)
        {
            string url = "http://trimatek.org/Consultas/banco?banco=" + bank + "&servicio=" + service;
            var jsonString = string.Empty;

            var client = new WebClient();  //hay 2 formas de hacer esto: esta, y otra con la clase HttpWebRequest que permite configurar mas cosas
            jsonString = client.DownloadString(url);

            List<JsonBank> banks = JsonConvert.DeserializeObject<List<JsonBank>>(jsonString);
            return banks;
        }

        // no se como se llamaría a esta función, y como convertir las coordenadas dadas en un calle

        public static void showBanks(string bank, string service)
        {
            List<JsonBank> jsonData = getJsonData(bank, service);

            if (jsonData.Count > 0)
            {
                foreach(JsonBank something in jsonData) // esto lo copie del home controller digamos
                {
                    ViewBag.SearchText = something.nombre + " -> " + address; // address seria la direccion del lugar, que se genera con las coord.
                    ViewBag.Search = "Ok";
                }
            }
            else
            {
                ViewBag.SearchText = "No se ha encontrado el banco/servicio especificado.";  //me marca los ViewBag en rojo, no se porque
                ViewBag.Search = "Error";
            }

        }

    }
}