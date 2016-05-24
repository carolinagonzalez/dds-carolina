using System.Device.Location;

namespace TPDDSGrupo44.Models
{
    public class ConsultoCercania
    {
        //Agrego metodo para calcular la distancia
        public const double EarthRadius = 6371;
        public double obtengoDistancia(Coordenada coordenada1, Coordenada coordenada2)
        {
            var sCoord = new GeoCoordinate(coordenada1.latitud, coordenada1.longitud);
            var eCoord = new GeoCoordinate(coordenada2.latitud, coordenada2.longitud);

            double distance = sCoord.GetDistanceTo(eCoord) / 100;


            return distance;

        }

        //constructor

        public ConsultoCercania() { }
    }
}