using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;



namespace TPDDSGrupo44.Models



/* Otra url, y del json Parseado  obtener el banco , sus coordenadas.. (con respecto a JsonBanks) 
 * consultar sobre cómo se maneja el jsonParseado... habria que utilizar el httpRequest?
 * cambio la url */
{
    public class GetJsonBanks : Controller
    {
        private static List<JsonBank> getJsonData()
        {
            string url = "http://private-96b476-ddsutn.apiary-mock.com/banks?banco=banco&servicio=servicio";
            var jsonString = string.Empty;

            var client = new WebClient();
            jsonString = client.DownloadString(url);


            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<JsonBank> listBanks = (List<JsonBank>)javaScriptSerializer.Deserialize(jsonString, typeof(List<JsonBank>));
            foreach (JsonBank jsonBank in listBanks) {
                // Response.Write
            }

            List<JsonBank> jsonParseado = JsonConvert.DeserializeObject<List<JsonBank>>(jsonString);
            return jsonParseado;
        }



        public static void showBanks(string bank, string service)
        {
            List<JsonBank> jsonData = getJsonData();
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






