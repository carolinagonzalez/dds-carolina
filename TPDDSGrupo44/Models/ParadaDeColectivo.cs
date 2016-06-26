using System;
using System.Device.Location;

using System.Collections.Generic;
using TPDDSGrupo44.Models;
using System.Linq;

namespace TPDDSGrupo44.Models
{

    public class ParadaDeColectivo : PuntoDeInteres
    {
        
        // Constructor
        public ParadaDeColectivo(string nombre, GeoCoordinate unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
        }

        public ParadaDeColectivo(int numLinea, GeoCoordinate unaCoordenada, List<String> unasParadas)
        : base(numLinea, unaCoordenada, unasParadas)
        {
            nombreDelPOI = numLinea.ToString();
            coordenada = unaCoordenada;
            unasParadas = new List<string>();

        }

        public ParadaDeColectivo() : base()
        {
        }

        public int numeroDeLinea;
        public List<String> paradas { get; set; }
        //public List<int> lineas { get; set; }


        public List<string> lineas { get; set; }


        /* Getters */
        public List<String> getParadas()
        {
            return paradas;
        }

        /* Setters */
        public void validarParadas(List<String> paradas)
        {
            if (paradas.Equals(null))
            {
                throw new System.ArgumentException("No se puede ingresar un recorrido nulo");
            }
            this.paradas = paradas;
        }


        /* Getters */
        public int getNumeroDeLinea()
        {
            return numeroDeLinea;
        }

        /* Setters */
        public void validarNumeroDeLinea(int numeroDeLinea)
        {
            if (numeroDeLinea < 0)
            {
                throw new System.ArgumentException("No se puede ingresar un número de línea negativo");
            }
        }



        // Cálculo de Cercanía - Debe estar a menos de una cuadra
        public override bool estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada) / 100) < 1;
        }

        // Cálculo de Disponibilidad Horaria - Siempre está disponible
        public override bool estaDisponible(DateTime searchTime)
        {
            return true;
        }


    }
}