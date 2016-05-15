using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPDDSGrupo44.Models
{
    
    public class ParadaDeColectivo : PuntoDeInteres
    {
        // Creo Constructor
        public ParadaDeColectivo()
        {
            this.posibilidades = new List<String>() { "114", "7", "92" };
        }
    }
}