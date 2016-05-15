using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class LocalComercial : PuntoDeInteres
    {
        public DateTime horario { get; set; }
        public string rubro { get; set; }
        public string direccion { get; set; }
        //public string callePrincipal { get; set; } //Se hereda de la clase padre POI
        //public string entreCalles { get; set; } //Se hereda de la clase padre POI
        public int numero { get; set; }
        public int piso { get; set; } //Se refiere a piso = 8 ?
        public char dpto { get; set; }//Se refiere a o dto = A ??


        // Creo Constructor
        public LocalComercial()
        {
            this.posibilidades = new List<String>() { "Kiosco", "Libreria Escolar" };
        }

    }
}