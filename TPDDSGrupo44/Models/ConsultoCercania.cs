using System.Device.Location;

namespace TPDDSGrupo44.Models
{
    public class ConsultoCercania
    {
        //Agrego metodo para calcular la distancia

        public double obtengoDistancia(GeoCoordinate coordenada1, GeoCoordinate coordenada2)
        {

            double distance = coordenada1.GetDistanceTo(coordenada2) / 100;


            return distance;

        }

        //constructor

        public ConsultoCercania() { }
    }
}