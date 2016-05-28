using System;
using System.Device.Location;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class PuntoDeInteres
    {
        public string callePrincipal { get; set; }
        public string entreCalles { get; set; }
        public string palabraClave { get; set; }
       
        public string nombreDelPOI { get; set; }

        public List<String> palabrasRelacionadas = new List<String>();
 

        //Creo constructor
        public PuntoDeInteres(string nombre, GeoCoordinate unaCordenada) {
            nombreDelPOI = nombre;
            coordenada = unaCordenada;
            palabrasRelacionadas.Add(nombre);
        }

        //Creo coleccion
        public List<string> posibilidades;

        public GeoCoordinate coordenada { get; set; }

        public Boolean valida(string posibilidad)
        {
            foreach (string unaPosibilidad in posibilidades)
            {
                if (unaPosibilidad == posibilidad) return true;
            }
            return false;
        }


        //Esta cerca POI generico que sea menor a 5 cuadras
        public Boolean estaCerca(GeoCoordinate coordenadaDeDispositivoTactil) {
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada)/100) < 5; //Cuadras
        }

       

    }
}