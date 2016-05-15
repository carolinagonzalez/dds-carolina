using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class Coordenada
    {
        public double latitud { get; set; }
        public double longitud { get; set; }

        //Agrego metodo para calcular la distancia
        public const double EarthRadius = 6371;
        public static double GetDistance(double lat1, double long1, double lat2, double long2)
        {
            double distance = 0;
            double Lat = (lat2 - lat1) * (Math.PI / 180);
            double Lon = (long2 - long1) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;

            
            return distance;

        }


        //Calculo la distancia a partir de una coordenada
        public double distanciaA(Coordenada coordenada)
        {
            return GetDistance(coordenada.latitud, coordenada.longitud, this.latitud, this.longitud);

        }
    }
}