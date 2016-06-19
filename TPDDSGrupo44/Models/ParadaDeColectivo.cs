using System;
using System.Device.Location;

namespace TPDDSGrupo44.Models
{

    public class ParadaDeColectivo : PuntoDeInteres
    {
        
        // Constructor
        public ParadaDeColectivo(string nombre, GeoCoordinate unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
        }
        

        // Cálculo de Cercanía - Debe estar a menos de una cuadra
        public override bool estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada) / 100) < 1;
        }

        // Cálculo de Disponibilidad Horaria - Siempre está disponible
        public override bool estaDisponible(DateTime searchTime)
        {
            return true;
        }


    }
}