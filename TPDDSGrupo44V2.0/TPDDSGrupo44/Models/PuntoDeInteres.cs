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
       
        public string nombreDelPOI { get; set; }

        public ConsultoCercania consultoCercania { get; set; }

        public List<String> palabrasRelacionadas = new List<String>();
 

        //Creo constructor
        public PuntoDeInteres(string nombre, Coordenada unaCordenada, ConsultoCercania unaConsulta) {
            this.nombreDelPOI = nombre;
            this.coordenada = unaCordenada;
            this.consultoCercania = unaConsulta;
            this.palabrasRelacionadas.Add(nombre);
        }

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


        //Esta cerca POI generico que sea menor a 5 cuadras
        public Boolean estaCerca(Coordenada coordenadaDeDispositivoTactil) {
            return this.consultoCercania.obtengoDistancia(coordenadaDeDispositivoTactil, this.coordenada) < 5; //Cuadras
        }

       

    }
}