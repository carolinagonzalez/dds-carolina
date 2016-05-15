using System;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class PuntoDeInteres
    {
        public string callePrincipal { get; set; }
        public string entreCalles { get; set; }
        public string palabraClave { get; set; }
        public int rangoCercania { get; set; }

        //Creo coleccion
        public List<string> posibilidades;

        public Coordenada coordenada { get; set; }

        public Boolean valida(string posibilidad)
        {
            foreach (string unaPosibilidad in this.posibilidades)
            {
                if (unaPosibilidad == posibilidad) return true;
            }
            return false;
        }

    }
}