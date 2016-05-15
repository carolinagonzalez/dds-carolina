using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        public DateTime horario { get; set; } //Como se declara el tipo horario ?
        public string direccion { get; set; }
        public string callePrincipal { get; set; }
        public string entreCalles { get; set; }
        public int numero { get; set; }
        public string tipoServicio { get; set; }
    }
}