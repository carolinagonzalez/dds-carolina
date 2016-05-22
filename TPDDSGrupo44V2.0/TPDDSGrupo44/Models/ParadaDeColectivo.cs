using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPDDSGrupo44.Models
{
    
    public class ParadaDeColectivo : PuntoDeInteres
    {
        // Creo Constructor
        
        public ParadaDeColectivo(string nombre, Coordenada unaCoordenada, ConsultoCercania unaConsulta)
        : base(nombre, unaCoordenada, unaConsulta)
        {
            this.nombreDelPOI = nombre;
            this.coordenada = unaCoordenada;
            this.consultoCercania = unaConsulta;
        }
        /*
    public ParadaDeColectivo()
    {
        this.posibilidades = new List<String>() { "114", "7", "92" };
    }
    */

        //1.	Un parada de  colectivo se considera cercana si estamos a menos de una cuadra.
        public Boolean estaCerca(Coordenada coordenadaDeDispositivoTactil)
        {
            return this.consultoCercania.obtengoDistancia(coordenadaDeDispositivoTactil, this.coordenada) < 1; //Cuadras
        }


    }
}