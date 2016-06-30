using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class JsonBank
    {
        public class Bank
        {
            public string nombre { get; set; }
            public double x { get; set; }
            public double y { get; set; }
            public string sucursal { get; set; }
            public string gerente { get; set; }
            public List<string> servicios { get; set; }
        }
    }
}