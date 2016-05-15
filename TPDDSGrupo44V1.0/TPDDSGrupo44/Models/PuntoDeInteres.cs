using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class PuntoDeInteres
    {
        public string callePrincipal { get; set; }
        public string entreCalles { get; set; }
        public string palabraClave { get; set; }
        public int rangoCercania { get; set; }

        public Coordenada coordenada { get; set; }
    }
}