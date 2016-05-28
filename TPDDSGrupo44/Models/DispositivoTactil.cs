using System;
using System.Collections.Generic;
using TPDDSGrupo44.Models;
using System.Device.Location;

namespace TPDDSGrupo44
{
    public class DispositivoTactil
    {

        // public int coordenada { get; set; }
        public GeoCoordinate coordenada { get; set; }
        public string puntoInteres { get; set; }
        public int comuna { get; set; } //se refiere al numero de comuna?
        public string consultas { get; set; }

        //Creo coleccion
        public List<PuntoDeInteres> ListaPuntosDeInteres;


        // Creo Constructor
        public DispositivoTactil(GeoCoordinate unaCoordenada)
        {
            this.coordenada = unaCoordenada;
        }

        //1
        public Boolean estaCerca(PuntoDeInteres unPuntoDeInteres) {
            return unPuntoDeInteres.estaCerca(this.coordenada);

        }


        //2
        /*
        public Boolean estaDisponible(PuntoDeInteres unPuntoDeInteres)
        {
            return unPuntoDeInteres.estaDisponible(this.coordenada);

        }
        */
    }
}