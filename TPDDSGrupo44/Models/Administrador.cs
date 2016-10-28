using System;
namespace TPDDSGrupo44.Models
{
    public class Administrador : Usuario
    {
        public TimeSpan cantSegDemoraA { get; private set; }



        public Administrador() { }

        //Creo Constructor
        public Administrador(String email, string contrasenia, TimeSpan cantSegDemora)
        {
            base.email = email;
            base.contrasenia = contrasenia;
            cantSegDemoraA = cantSegDemora;
        }

        //CLASE Administrador
        public String parametrizarDemoraEnSeg(TimeSpan cantSegDemora)
        {
            TimeSpan intervalo = new TimeSpan(2, 14, 18); // Displays "02:14:18".
            return intervalo.ToString();
        }


    }
}