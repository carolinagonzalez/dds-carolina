using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace TPDDSGrupo44.Models



/* Otra url, y del json Parseado  obtener el banco , sus coordenadas.. (con respecto a JsonBanks) 
 * consultar sobre cómo se maneja el jsonParseado... habria que utilizar el httpRequest?
 * cambio la url */
{
   public class GetJsonBanks : Controller
   //public class GetJsonBanks
    {
        private static List<JsonBank> getJsonData(string bank, string service)
        //protected void Page_Load(object sender, EventArgs e)
        {

            string url = "http://trimatek.org/Consultas/banco?banco=" + bank + "&servicio=" + service;

            //string url = "http://private-96b476-ddsutn.apiary-mock.com/banks?banco=banco&servicio=servicio"; 
            // Por si no funciona la url..(caida) string jsonString = "[{'banco':'Galicia','x':9999.0,'y':9999.0,'sucursal':'Flores','gerente':'Roberto Gomez','servicios':['Plazo Fijo','Acciones','Cobros','Pagos']},{'banco':'Santander Rio','x':1234.0,'y':1234.0,'sucursal':'Almagro','gerente':'Lorenzo','servicios':['Moneda extranjera','Cobros','Pagos']}]";
            //string url = "http://trimatek.org/Consultas/banco";

            var jsonString = string.Empty;

            var client = new WebClient();
            jsonString = client.DownloadString(url);



            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<JsonBank> listBanks = (List<JsonBank>)javaScriptSerializer.Deserialize(jsonString, typeof(List<JsonBank>));

            foreach (JsonBank banco in listBanks)
            {
                
                //Response.Write("banco" + banco.banco + "<br>");
                //Response.Write("x" + banco.x + "<br>");
                //Response.Write("y" + banco.y + "<br>");
                //Response.Write("sucursal" + banco.sucursal + "<br>");
                //Response.Write("gerente" + banco.gerente + "<br>");
                //Response.Write("servicios" + banco.servicios + "<br>");


            }

            return listBanks;
        }

        public static void showBanks(string bank, string service)
        {
            List<JsonBank> jsonData = getJsonData(bank,service);
            //jsonData = JsonBank.Bank.banco.get()

            if (jsonData.Count > 0)
            {
                foreach (JsonBank something in jsonData)
                {
                    //ViewBag.SearchText = something.banco + " -> " + address; // address seria la direccion del lugar, que se genera con las coord.
                    //ViewBag.SearchText = something.banco + " -> " + address;
                    // ViewBag.Search = "Ok";
                }
            }
            else
            {
                //ViewBag.SearchText = "No se ha encontrado el banco/servicio especificado.";  //me marca los ViewBag en rojo, no se porque
                //ViewBag.Search = "Error";
            }

        }

        /*  
         *  ///                      JSON SERIALIZE
         *  
         *  
         *  protected void Page_Load(object sender, EventArgs e) {
              JsonBank bank1 = new JsonBank
              {
                  banco = "Banco de la Plaza",
                  x = -35.9338322,
                  y = 72.348353,
                  sucursal = "Avellaneda",
                  gerente = "Javier Loeschbor",
                  servicios = [ "cobro cheques", "depositos", "extracciones", "transferencias", "creditos" ]
              };

              JsonBank bank2 = new JsonBank
              {
                  banco = "Banco de la Plaza",
                  x = -35.9345681,
                  y = 72.344546,
                  sucursal = "Caballito",
                  gerente = "Fabian Fantaguzzi",
                  servicios = ["depositos", "extracciones", "transferencias", "seguros"]
              };


              List<JsonBank> listBank = new List<JsonBank>();
              listBank.Add(bank1);
              listBank.Add(bank2);

              JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
              string jsonString = javaScriptSerializer.Serialize(listBank);

              Response.Write(jsonString);

          }
          
        /////                    JSON DESERIALIZE
        
          protected void Page_Load(object sender, EventArgs e) {

            string jsonString = "[{\"banco\":\"Banco de la Plaza\",\"x\": -35.9338322,\"y\": 72.348353,\"sucursal\": \"Avellaneda\",\"gerente\": \"Javier Loeschbor\",\"servicios\": [ \"cobro cheques\", \"depositos\", \"extracciones\", \"transferencias\", \"creditos\" ]},{ \"banco\": \"Banco de la Plaza\",\"x\": -35.9345681,\"y\": 72.344546,\"sucursal\": \"Caballito\",\"gerente\": \"Fabian Fantaguzzi\",\"servicios\": [ \"depositos\", \"extracciones\", \"transferencias\", \"seguros\" ]}";

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<JsonBank> listBanks= (List<JsonBank>)javaScriptSerializer.Deserialize(jsonString, typeof(List<JsonBank>));

            foreach (JsonBank bank in listBanks) {
                Response.Write("banco" + bank.banco+"<br>");
                Response.Write("x" + bank.x + "<br>");
                Response.Write("y" + bank.y + "<br>");
                Response.Write("sucursal" + bank.sucursal + "<br>");
                Response.Write("gerente" + bank.gerente + "<br>");
                Response.Write("servicios" + bank.servicios + "<br>");


            }
          }*/
         
    }
}






