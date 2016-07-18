using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;

namespace TPDDSGrupo44.Models
{
    public class PuntoDeInteres
    {
       
        [Key]
        public int Id { get; set; }

        public string palabraClave { get; set; }
        public string entreCalles { get; set; }


        public List<String> palabrasRelacionadas = new List<String>();

        public List<HorarioAbierto> horarioAbierto = new List<HorarioAbierto>();
        public List<HorarioAbierto> horarioFeriados = new List<HorarioAbierto>();
        private int numLinea;
        private DbGeography unaCoordenada;
        private List<string> unasParadas;
        private string nombreRubro;
        private int radioCercania;
        private Rubro rubro;
        private DateTime dateRubro;
        private string direccion;
        private int piso;
        private char dto;




        /* Getters & setters callePrincipal */
        public string callePrincipal;

        public String getCallePrincipal()
        {
            return callePrincipal;
        }

        public void setCallePrincipal(String callePrincipal)
        {
            if (callePrincipal == null || callePrincipal.Length == 0)
            {
                throw new System.ArgumentException("La calle principal no puede ser nula");
            }
            this.callePrincipal = callePrincipal;
        }


        /* Getters & setters coordenada */
        public DbGeography coordenada;


        public DbGeography getCoordenada()
        {
            return coordenada;
        }

        public void setCoordenada(DbGeography coordenada)
        {
            if (coordenada == null || coordenada.ToString() == "")
            {
                throw new System.ArgumentException("La coordenada ingresada no puede ser nula");
            }
            this.coordenada = coordenada;
        }



        /* Getters & setters nombreDelPOI */
        public string nombreDelPOI;


        public String getNombrePOI()
        {
            return nombreDelPOI;
        }

        public void setNombreDelPOI(String nombreDelPOI)
        {
            if (nombreDelPOI == null || nombreDelPOI.Length == 0)
            {
                throw new System.ArgumentException("La calle principal no puede ser nula");
            }

            this.nombreDelPOI = nombreDelPOI;
        }



        //Constructor vacio
        public PuntoDeInteres() { }

        // Constructor básico
        public PuntoDeInteres(string nombre, DbGeography unaCordenada)
        {
            this.setNombreDelPOI(nombre);
            this.setCoordenada(unaCordenada);

            // nombreDelPOI = nombre;
            // coordenada = unaCordenada;
            palabrasRelacionadas.Add(nombre);
        }

        public PuntoDeInteres(int numLinea, DbGeography unaCoordenada, List<string> unasParadas)
        {
            this.numLinea = numLinea;
            this.unaCoordenada = unaCoordenada;
            this.unasParadas = unasParadas;
        }

        public PuntoDeInteres(string nombreRubro, int radioCercania, DbGeography unaCoordenada, Rubro rubro, DateTime dateRubro, string direccion, int piso, char dto)
        {
            this.nombreRubro = nombreRubro;
            this.radioCercania = radioCercania;
            this.unaCoordenada = unaCoordenada;
            this.rubro = rubro;
            this.dateRubro = dateRubro;
            this.direccion = direccion;
            this.piso = piso;
            this.dto = dto;
        }






//Funcion manhattan
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

        // Cálculo de Cercanía genérico - distancia menor a 5 cuadras
        public virtual bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {

            return (functionManhattan(coordenada, coordenadaDeDispositivoTactil) / 100) < 5;
        }

        // Cálculo de Disponibilidad Horaria genérico
        public virtual bool estaDisponible(DateTime searchTime)
        {
            //busco entre los feriados a ver si hoy es feriado
            HorarioAbierto todaysHours = horarioFeriados.Find(x => x.numeroDeDia == searchTime.Day && x.numeroDeMes == searchTime.Month);

            //si es feriado, verificar si está abierto (pueden hacer horarios diferenciales)
            if (todaysHours != null)
            {
                return todaysHours.horarioValido(searchTime);
            } else
            {
                // si no era feriado, busco si está abierto por día de la semana
                todaysHours = horarioAbierto.Find(x => x.dia == searchTime.DayOfWeek );
                return todaysHours.horarioValido(searchTime);
            }
        }




    }
}