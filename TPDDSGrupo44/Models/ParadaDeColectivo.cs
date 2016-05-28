using System;
using System.Device.Location;

namespace TPDDSGrupo44.Models
{

    public class ParadaDeColectivo : PuntoDeInteres
    {
        // Creo Constructor
        
        public ParadaDeColectivo(string nombre, GeoCoordinate unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            this.nombreDelPOI = nombre;
            this.coordenada = unaCoordenada;
            this.consultoCercania = new ConsultoCercania();
        }
        /*
    public ParadaDeColectivo()
    {
        this.posibilidades = new List<String>() { "114", "7", "92" };
    }
    */

        //1.	Un parada de  colectivo se considera cercana si estamos a menos de una cuadra.
        public new bool estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return this.consultoCercania.obtengoDistancia(coordenadaDeDispositivoTactil, this.coordenada) < 1; //Cuadras
        }

        //2.1.    El servicio de transporte de Colectivos está disponible a toda hora

        public Boolean estaDisponible()
        {
            return true;
        }

    }
}