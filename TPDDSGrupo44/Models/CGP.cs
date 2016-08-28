using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        ////////////////Atributos////////////////
        public new int id { get; set; }
        public new DbGeography coordenada { get; set; }
        public new string calle { get; set; }
        public new int numeroAltura { get; set; }
        public new int piso { get; set; }
        public new int unidad { get; set; }
        public new int codigoPostal { get; set; }
        public new string localidad { get; set; }
        public new string barrio { get; set; }
        public new string provincia { get; set; }
        public new string pais { get; set; }
        public new string entreCalles { get; set; }
        public new string palabraClave { get; set; }
        public new string tipoDePOI { get; set; }
        public virtual new List<HorarioAbierto> horarioAbierto { get; set; }
        public virtual new List<HorarioAbierto> horarioFeriado { get; set; }
        public int numeroDeComuna { get; set; }
        public virtual List<ServicioCGP> servicios { get; set; }
        public int zonaDelimitadaPorLaComuna { get; set; }

        ////////////////Constructor Vacio////////////////
        public CGP() {
            servicios = new List<ServicioCGP>();
        }

        ////////////////Constructor Viejo(Usado en controlador////////////////
        public CGP(string nombre, DbGeography unaCoordenada, int zona)
        : base (nombre, unaCoordenada)
        {
            palabraClave = nombre;
            coordenada = unaCoordenada;
            zonaDelimitadaPorLaComuna = zona;
            servicios = new List<ServicioCGP>();
        }


        ////////////////Funcion manhattan////////////////
        private static double functionManhattan(DbGeography coordenadaDeDispositivoTactil, DbGeography coordenada)
        {
            double lat1InDegrees = (double)coordenadaDeDispositivoTactil.Latitude;
            double long1InDegrees = (double)coordenadaDeDispositivoTactil.Longitude;

            double lat2InDegrees = (double)coordenada.Latitude;
            double long2InDegrees = (double)coordenada.Longitude;

            double lats = (double)Math.Abs(lat1InDegrees - lat2InDegrees);
            double lngs = (double)Math.Abs(long1InDegrees - long2InDegrees);

            //grados a metros
            double latm = lats * 60 * 1852;
            double lngm = (lngs * Math.Cos((double)lat1InDegrees * Math.PI / 180)) * 60 * 1852;
            double distInMeters = Math.Sqrt(Math.Pow(latm, 2) + Math.Pow(lngm, 2));
            return distInMeters;

        }

        ////////////////Cálculo de Cercanía genérico - distancia menor a 5 cuadras////////////////
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (functionManhattan(coordenada, coordenadaDeDispositivoTactil) / 100) < zonaDelimitadaPorLaComuna;
        }

    }
}