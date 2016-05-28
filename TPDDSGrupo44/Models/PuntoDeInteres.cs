﻿using System;
using System.Device.Location;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class PuntoDeInteres
    {
        public string callePrincipal { get; set; }
        public string entreCalles { get; set; }
        public string palabraClave { get; set; }
       
        public string nombreDelPOI { get; set; }

        public List<String> palabrasRelacionadas = new List<String>();

        public List<HorarioAbierto> horarioAbierto = new List<HorarioAbierto>();
        public List<HorarioAbierto> horarioFeriados = new List<HorarioAbierto>();


        //Creo constructor
        public PuntoDeInteres(string nombre, GeoCoordinate unaCordenada) {
            nombreDelPOI = nombre;
            coordenada = unaCordenada;
            palabrasRelacionadas.Add(nombre);
        }

        //Creo coleccion
        public List<string> posibilidades;

        public GeoCoordinate coordenada { get; set; }

        public Boolean valida(string posibilidad)
        {
            foreach (string unaPosibilidad in posibilidades)
            {
                if (unaPosibilidad == posibilidad) return true;
            }
            return false;
        }


        //Esta cerca POI generico que sea menor a 5 cuadras
        public Boolean estaCerca(GeoCoordinate coordenadaDeDispositivoTactil) {
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada)/100) < 5; //Cuadras
        }

        public Boolean estaDisponible()
        {
            DateTime today = DateTime.Today;

            //busco entre los feriados a ver si hoy es feriado
            HorarioAbierto todaysHours = horarioFeriados.Find(x => x.numeroDeDia == today.Day && x.numeroDeMes == today.Month);

            //si es feriado, verificar si está abierto (pueden hacer horarios diferenciales)
            if (todaysHours != null)
            {
                return todaysHours.horarioValido();
            } else
            {
                // si no era feriado, busco si está abierto por día de la semana
                todaysHours = horarioAbierto.Find(x => x.dia == today.DayOfWeek );
                return todaysHours.horarioValido();
            }
        }

    }
}