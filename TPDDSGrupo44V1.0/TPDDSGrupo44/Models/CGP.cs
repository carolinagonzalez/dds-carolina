using System;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        public DateTime horario { get; set; } //Como se declara el tipo horario ?
        public string direccion { get; set; }
        //public string callePrincipal { get; set; } //Se hereda de la clase padre POI
        //public string entreCalles { get; set; } //Se hereda de la clase padre POI
        public int numero { get; set; }
        public string tipoServicio { get; set; }

        // Creo Constructor
        public CGP()
        {
            this.posibilidades = new List<String>() { "Atencion al publico", "Rentas", "Registro Civil", "Multas" };

        }
    }
}