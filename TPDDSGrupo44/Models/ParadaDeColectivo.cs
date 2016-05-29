using System.Device.Location;

namespace TPDDSGrupo44.Models
{

    public class ParadaDeColectivo : PuntoDeInteres
    {
        // Creo Constructor
        
        public ParadaDeColectivo(string nombre, GeoCoordinate unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
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
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada) / 100) < 1; //Cuadras
        }

        //2.1.    El servicio de transporte de Colectivos está disponible a toda hora

        public new bool estaDisponible()
        {
            return true;
        }

    }
}