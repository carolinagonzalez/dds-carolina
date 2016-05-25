using System;

namespace TPDDSGrupo44.Models
{
    public class HorarioAbierto
    {
      
        public DayOfWeek dia { get; set; }
<<<<<<< HEAD
        public int numeroDeMes { get; set; }  //Agrego atributo
=======
>>>>>>> origin/master
        public int horarioInicio { get; set; }
        public int horarioFin { get; set; }


        //Creo Constructor del HorarioAbierto
<<<<<<< HEAD
        public HorarioAbierto(DayOfWeek dia, int numeroDeMes, int horarioInicio, int horarioFin)
        {
            this.dia = dia;
            this.numeroDeMes = numeroDeMes;
=======
        public HorarioAbierto(DayOfWeek dia, int horarioInicio, int horarioFin)
        {
            this.dia = dia;
>>>>>>> origin/master
            this.horarioInicio = horarioInicio;
            this.horarioFin = horarioFin;
        }

<<<<<<< HEAD
        public Boolean horarioValido(DateTime fecha) {
            DateTime dateValue = new DateTime(fecha.Year, fecha.Month, fecha.Day);
            int numeroDeDia = ((int)dateValue.DayOfWeek);
            if ((fecha.DayOfWeek == this.dia) && (fecha.Hour >= this.horarioInicio) && (fecha.Hour < this.horarioFin) && (fecha.Month == this.numeroDeMes)) //Contemplo dia, rango en el que horario abre y cierra
            {
                //Feriados

                if ((numeroDeDia == 1) && (numeroDeMes == 1))
                {
                    return false; //Año Nuevo
                }
                if (((numeroDeDia == 8) || (numeroDeDia == 9)) && (numeroDeMes == 2))
                {
                    return false; //Carnaval
                }
                if (((numeroDeDia == 24) || (numeroDeDia == 25)) && (numeroDeMes == 3))
                {
                    return false; //Dia de la Memoria y Viernes Santo
                }
                if ((numeroDeDia == 2) && (numeroDeMes == 4))
                {
                    return false; //Malvinas
                }
                if (((numeroDeDia == 1) || (numeroDeDia == 25)) && (numeroDeMes == 5))
                {
                    return false; //Dia del Trabajador y Revolución de Mayo
                }
                if ((numeroDeDia == 20) && (numeroDeMes == 6))
                {
                    return false; //Dia de la Bandera
                }
                if (((numeroDeDia == 8) || (numeroDeDia == 9)) && (numeroDeMes == 7))
                {
                    return false; //Feriado Puente y Dia de la Independencia
                }
                if (((numeroDeDia == 8) || (numeroDeDia == 9) || (numeroDeDia == 25)) && (numeroDeMes == 12))
                {
                    return false; //Dia de la Virgen, Feriado Puente y Navidad
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                return false;
            }
        }

=======
>>>>>>> origin/master
    }
}
