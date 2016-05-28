using System;
using System.Device.Location;

namespace TPDDSGrupo44.Models
{
    public class Banco : PuntoDeInteres
    {

        //Creo Constructor

        public Banco(string nombre, GeoCoordinate unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
        }


        public new bool estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return base.estaCerca(coordenada); //Cuadras
        }

    }
}