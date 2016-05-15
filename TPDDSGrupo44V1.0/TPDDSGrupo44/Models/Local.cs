using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class Local : PuntoDeInteres
    {
        public DateTime horario { get; set; }
        public string rubro { get; set; }
        public string direccion { get; set; }
        public string callePrincipal { get; set; }
        public string entreCalles { get; set; }
        public int numero { get; set; }
        public int piso { get; set; } //Se refiere a piso = 8 ?
        public char dpto { get; set; }//Se refiere a o dto = A ??
        
    }
}