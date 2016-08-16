using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace TPDDSGrupo44.Models

{
    public class GetJsonCGP : Controller
    //public class GetJsonBanks
    {
        //private static List<JsonCGP> getJsonData(string zona) depende lo que quiera buscar
        //protected void Page_Load(object sender, EventArgs e)
        private static List<JsonCGP> getJsonData()
        {

            //string url = "http://trimatek.org/Consultas/centro?zona=" + zona;
            string url = "http://trimatek.org/Consultas/centro";

            var jsonString = string.Empty;

            var client = new WebClient();
            jsonString = client.DownloadString(url);

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<JsonCGP> listCGP = (List<JsonCGP>)javaScriptSerializer.Deserialize(jsonString, typeof(List<JsonCGP>));

            foreach (JsonCGP cgp in listCGP)
            {
                //Response.Write("comuna" + cgp.comuna + "<br>");
                //Response.Write("zona" + cgp.zonas + "<br>");
                //Response.Write("director" + cgp.director + "<br>");
                //Response.Write("domicilio" + cgp.domicilio + "<br>");
                //Response.Write("servicios" + cgp.servicios + "<br>");
                //Response.Write("telefono" + cgp.telefono + "<br>");
            }


            return listCGP;
        }

        //public static void showCGP(string cgp)
        public static void showCGP()
        {
            List<JsonCGP> jsonData = getJsonData();
            //jsonData = JsonBank.Bank.banco.get()
           

            if (jsonData.Count > 0)
            {
                foreach (JsonCGP something in jsonData)
                {
                    //ViewBag.SearchText = something.banco + " -> " + address; // address seria la direccion del lugar, que se genera con las coord.
                    //ViewBag.SearchText = something.banco + " -> " + address;
                    // ViewBag.Search = "Ok";
                }
            }
            else
            {
                //ViewBag.SearchText = "No se ha encontrado el cgp/servicio especificado.";  //me marca los ViewBag en rojo, no se porque
                //ViewBag.Search = "Error";
            }

        }
    }
}






