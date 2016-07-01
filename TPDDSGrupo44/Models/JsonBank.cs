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
            public string Banco { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public string Sucursal { get; set; }
            public string Gerente { get; set; }
            public List<string> Servicios { get; set; }
        }
    }
}