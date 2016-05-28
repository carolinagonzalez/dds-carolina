using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class HorarioAbiertoPorServicio : HorarioAbierto
    {
        public string nombreDelServicio { get; set; }

        // Creo Constructor

        public HorarioAbiertoPorServicio(DayOfWeek dia,  int horarioInicio, int horarioFin, string nombreDelServicio)
        : base(dia, horarioInicio, horarioFin)
        {
            this.dia = dia;
            this.numeroDeMes = numeroDeMes;
            this.horarioInicio = horarioInicio;
            this.horarioFin = horarioFin;
            this.nombreDelServicio = nombreDelServicio;
        }

        public Boolean horarioValidoPorServicio(DateTime fecha, String unServicio)
        {
          
            if (unServicio == this.nombreDelServicio)
            {
                if ((fecha.DayOfWeek == this.dia) && (fecha.Hour >= this.horarioInicio) && (fecha.Hour < this.horarioFin) && (fecha.Month == this.numeroDeMes)) //Contemplo dia, rango en el que horario abre y cierra
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}