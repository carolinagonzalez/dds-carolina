using System;
using System.Collections.Generic;

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