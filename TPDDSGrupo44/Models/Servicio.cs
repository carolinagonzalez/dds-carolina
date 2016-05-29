using System;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class Servicio
    {

        public string nombre { get; set; }
        public List<HorarioAbierto> horarioAbierto { get; set; }
        public List<HorarioAbierto> horarioFeriados { get; set; }

        // Constructor
        public Servicio(string nombreDelServicio)
        {
            nombre = nombreDelServicio;
            horarioAbierto = new List<HorarioAbierto>();
            horarioFeriados = new List<HorarioAbierto>();
        }

        public bool estaDisponible(DateTime searchTime)
        {
            //busco entre los feriados a ver si hoy es feriado
            HorarioAbierto todaysHours = horarioFeriados.Find(x => x.numeroDeDia == searchTime.Day && x.numeroDeMes == searchTime.Month);

            //si es feriado, verificar si está abierto (pueden hacer horarios diferenciales)
            if (todaysHours != null)
            {
                return todaysHours.horarioValido(searchTime);
            }
            else
            {
                // si no era feriado, busco si está abierto por día de la semana
                todaysHours = horarioAbierto.Find(x => x.dia == searchTime.DayOfWeek);
                return todaysHours.horarioValido(searchTime);
            }
        }

    }


}
