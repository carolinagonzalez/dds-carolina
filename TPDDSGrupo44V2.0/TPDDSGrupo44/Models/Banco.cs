using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class Banco : PuntoDeInteres
    {

        //Creo Constructor

        public Banco(string nombre, Coordenada unaCoordenada, ConsultoCercania unaConsulta)
        : base(nombre, unaCoordenada, unaConsulta)
        {
            this.nombreDelPOI = nombre;
            this.coordenada = unaCoordenada;
            this.consultoCercania = unaConsulta;
        }

       
        public Boolean estaCerca(Coordenada coordenadaDeDispositivoTactil)
        {
            return base.estaCerca(this.coordenada) ; //Cuadras
        }

    }
}