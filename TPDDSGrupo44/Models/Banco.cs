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
            this.nombreDelPOI = nombre;
            this.coordenada = unaCoordenada;
            this.consultoCercania = new ConsultoCercania();
        }


        public new Boolean estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return base.estaCerca(this.coordenada); //Cuadras
        }

    }
}