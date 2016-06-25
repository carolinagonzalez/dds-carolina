using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class jsonparseo
    {

        //System.Web.Script.Serialization.JavaScriptSerializer;

        public class ListaBanco
        {

            public List<Banco> data { get; set; }
        }

        public class Banco
        {
            public string banco { get; set; }
            public double x { get; set; }
            public double y { get; set; }
            public string sucursal { get; set; }
            public string gerente { get; set; }
            public List<string> servicios { get; set; }
        }
     
        //ListaBanco bancos = new JavaScriptSerializer().Deserialize<ListaBanco>(json);

      
    }
}





