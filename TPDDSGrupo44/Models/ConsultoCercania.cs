using System;

namespace TPDDSGrupo44.Models
{
    public class ConsultoCercania
    {
        //Agrego metodo para calcular la distancia
        public const double EarthRadius = 6371;
        public double obtengoDistancia(Coordenada coordenada1, Coordenada coordenada2)
        {
            double lat1 = coordenada1.latitud;
            double long1 = coordenada1.longitud;

            double lat2 = coordenada2.latitud;
            double long2 = coordenada2.longitud;


            double distance = 0;
            double Lat = (lat2 - lat1) * (Math.PI / 180);
            double Lon = (long2 - long1) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;


            return distance;

        }

        //constructor

        public ConsultoCercania() { }
    }
}