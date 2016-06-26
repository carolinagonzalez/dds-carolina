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

        public string numeroDeLinea;
        public List<String> paradas { get; set; }
   

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
        public string getNumeroDeLinea()
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



        /* Validaciones del Alta */
        public Boolean noExisteLinea(string numLinea)
        {
            if (this.getNumeroDeLinea().Equals(null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        List<string> listaDeLineas = new List<string> { "92", "114", "186" };


        /* Alta - Parada POI Linea */
        public void agregarPOILinea(string nuevaLinea, String paradaAgregada)
        {

            if (!noExisteLinea(nuevaLinea))//Verifico que la linea ingresada no sea nula, es decir, que se ingrese una linea
            {

            List<string> listaFiltrada = new List<string>(listaDeLineas.Where(x => x == nuevaLinea).ToList());

            //Creo las paradas de esta linea
            List<String> paradasDeEstaLinea = new List<String>();
            if (listaFiltrada.ToString().Length == 0) //La linea no existe
            {
                //La doy de alta
                lineas.Add(nuevaLinea);
                   
                //Agrego la parada ingresada a la lista de lineas
                paradasDeEstaLinea.Add(paradaAgregada);

            }
            else if (listaFiltrada.ToString().Length > 0)
            {
                //Si la linea ya existe, agrego la parada
                paradasDeEstaLinea.Add(paradaAgregada);
            }
            else
            {
                throw new System.ArgumentException("No se puede dar de alta este punto de interés");
            }
          }
          else
          {
                throw new ArgumentException("No se puede dar de alta este punto de interés. ¡Vuelva a intentarlo!");
            }

        }



    }
}