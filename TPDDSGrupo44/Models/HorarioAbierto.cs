using System;

namespace TPDDSGrupo44.Models
{
    public class HorarioAbierto
    {
      
        public DayOfWeek dia { get; set; }
        public int horarioInicio { get; set; }
        public int horarioFin { get; set; }


        //Creo Constructor del HorarioAbierto
        public HorarioAbierto(DayOfWeek dia, int horarioInicio, int horarioFin)
        {
            this.dia = dia;
            this.horarioInicio = horarioInicio;
            this.horarioFin = horarioFin;
        }

    }
}
