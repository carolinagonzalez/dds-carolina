using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPDDSGrupo44.Models
{
    
    public class ParadaDeColectivo : PuntoDeInteres
    {
        public const double EarthRadius = 6371;
        public static double GetDistance(Coordenada point1, Coordenada point2)
        {
            double distance = 0;
            double Lat = (point2.latitud - point1.latitud) * (Math.PI / 180);
            double Lon = (point2.longitud - point1.longitud) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(point1.latitud * (Math.PI / 180)) * Math.Cos(point2.latitud * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;

            System.Console.WriteLine("Hello, World!");
            return distance;
        
        }

        public Boolean estaCerca(Coordenada unaCordenada)
        {

            return GetDistance(this.coordenada, unaCordenada) < 1;
        } 
    }
}