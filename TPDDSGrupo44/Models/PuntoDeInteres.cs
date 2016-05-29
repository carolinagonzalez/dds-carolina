using System;
using System.Device.Location;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class PuntoDeInteres
    {
        public string callePrincipal { get; set; }
        public string entreCalles { get; set; }
        public string palabraClave { get; set; }
        public GeoCoordinate coordenada { get; set; }
        public string nombreDelPOI { get; set; }

        public List<String> palabrasRelacionadas = new List<String>();

        public List<HorarioAbierto> horarioAbierto = new List<HorarioAbierto>();
        public List<HorarioAbierto> horarioFeriados = new List<HorarioAbierto>();


        // Constructor básico
        public PuntoDeInteres(string nombre, GeoCoordinate unaCordenada) {
            nombreDelPOI = nombre;
            coordenada = unaCordenada;
            palabrasRelacionadas.Add(nombre);
        }


        // Cálculo de Cercanía genérico - distancia menor a 5 cuadras
        public bool estaCerca(GeoCoordinate coordenadaDeDispositivoTactil) {
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada)/100) < 5;
        }

        // Cálculo de Disponibilidad Horaria genérico
        public bool estaDisponible(DateTime searchTime)
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