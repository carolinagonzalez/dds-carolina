using System;
using System.Collections.Generic;
using TPDDSGrupo44.Models;

namespace TPDDSGrupo44
{
    public class DispositivoTactil
    {

        // public int coordenada { get; set; }
        public Coordenada coordenada { get; set; }
        public string puntoInteres { get; set; }
        public int comuna { get; set; } //se refiere al numero de comuna?
        public string consultas { get; set; }

        //Creo coleccion
        public List<PuntoDeInteres> ListaPuntosDeInteres;


        // Creo Constructor
        public DispositivoTactil(Coordenada unaCoordenada)
        {
            this.coordenada = unaCoordenada;
        }

        public Boolean estaCerca(PuntoDeInteres unPuntoDeInteres) {
            return unPuntoDeInteres.estaCerca(this.coordenada);

        }

    }
}