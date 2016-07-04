﻿using System;
using System.Device.Location;

using System.Collections.Generic;
using TPDDSGrupo44.Models;
using System.Linq;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Models
{

    public class ParadaDeColectivo : PuntoDeInteres
    {
        public new string nombreDelPOI { get; set; }
        public new DbGeography coordenada { get; set; }

        public ParadaDeColectivo() { }

        // Constructor
        public ParadaDeColectivo(string nombre, DbGeography unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            paradas = new List<string>();  // si no ponia esto, el test me tiraba error por intentar hacer algo con una variable no instanciada
            lineas = new List<string>();    // idem anterior
        }

        public ParadaDeColectivo(int numLinea, DbGeography unaCoordenada, List<String> unasParadas)
        : base(numLinea, unaCoordenada, unasParadas)
        {
            nombreDelPOI = numLinea.ToString();
            coordenada = unaCoordenada;
            unasParadas = new List<string>();

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
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.Distance(coordenada) / 100) < 1;
        }

        // Cálculo de Disponibilidad Horaria - Siempre está disponible
        public override bool estaDisponible(DateTime searchTime)
        {
            return true;
        }



        /* Validaciones del Alta */
        public Boolean noExistePOI(string numLinea)  // ese argumento nunca se usa, y el "getNumeroDeLinea" siempre esta nulo, tengo que setearlo manual
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


       public List<string> listaDeLineas = new List<string> { "92", "114", "186" };  // esta publico porque lo usa el test, ameo

        List<string> paradasDeEstaLinea = new List<string> { "Rivadavia 123", "Rio de Janeiro 333", "Mozart 2389" };




        /* Alta - Parada POI Linea */
        public void agregarPOILinea(string nuevaLinea, String paradaAgregada)
        {

            if (!noExistePOI(nuevaLinea) && !noExistePOI(paradaAgregada))//Verifico que la linea ingresada y la parada no sean nula, es decir, que se ingresen
            {

            List<string> listaFiltrada = new List<string>(listaDeLineas.Where(x => x == nuevaLinea).ToList());

            
            if (listaFiltrada.ToString().Length == 0) //La linea no existe
            {
                    //Creo las paradas de esta linea
                    List<String> paradasDeEstaLinea = new List<String>();

                    //La doy de alta
                    lineas.Add(nuevaLinea);
                //Agrego la parada ingresada a la lista de lineas
                paradasDeEstaLinea.Add(paradaAgregada);

            }
            else if (listaFiltrada.ToString().Length > 0)
            {
                    List<string> listaFiltradaParadas = new List<string>(paradasDeEstaLinea.Where(x => x == paradaAgregada).ToList());
                    //Si la parada que se desea agregar no existe
                    if (listaFiltradaParadas.ToString().Length == 0)
                    {
                        //Agrego la parada
                        paradasDeEstaLinea.Add(paradaAgregada);
                    }
                    else
                    {
                        throw new ArgumentException("No se puede dar de alta este punto de interés. ¡Vuelva a intentarlo!");
                    }

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




        /* Baja - Parada POI de una parada de colectivo de una determinada Linea */
        public void bajarPOILinea(string numLinea, string paradaBorrar)
        {

            if (!noExistePOI(numLinea) && !noExistePOI(paradaBorrar))//Verifico que la linea ingresada y la parada no sean nula, es decir, que se ingresen
            {

                List<string> listaFiltrada = new List<string>(listaDeLineas.Where(x => x == numLinea).ToList());

                //Creo las paradas de esta linea
                List<String> paradasDeEstaLinea = new List<String>();
                if (listaFiltrada.ToString().Length == 0) //La linea no existe
                {
                    throw new System.ArgumentException("No se puede dar de Baja la parada ya que no existe este punto de interés");

                }
                else if (listaFiltrada.ToString().Length > 0)//La linea existe
                {
                    //Doy de baja la parada que se desea borrar
                    paradasDeEstaLinea.Remove(paradaBorrar);
                }
                else
                {
                    throw new System.ArgumentException("No se puede dar de Baja este punto de interés. ");
                }
            }
            else
            {
                throw new ArgumentException("No se puede dar de Baja este punto de interés. ¡Vuelva a intentarlo!");
            }

        }


        /* Baja - Parada POI - Elimino completamente la Linea de Colectivo con sus respectivas paradas */
        public void bajarPOILinea(string numLinea)
        {
            if (!noExistePOI(numLinea))//Verifico que la linea ingresada y la parada no sean nula, es decir, que se ingresen
            {
               List<string> listaFiltrada = new List<string>(listaDeLineas.Where(x => x == numLinea).ToList());
                

            if (listaFiltrada.ToString().Length == 0) //La linea no existe
            {
                throw new System.ArgumentException("No se puede dar de Baja este punto de interés ya que no existe");

            }
            else if (listaFiltrada.ToString().Length > 0)
            {
                //Si la linea existe, la doy de Baja
                lineas.Remove(numLinea);

                //Elimino todas sus paradas
                while (paradasDeEstaLinea.ToString().Length > 0)
                {
                    paradasDeEstaLinea.Remove(numLinea);
                }
            }
            else
            {
                throw new System.ArgumentException("No se puede dar de Baja este punto de interés");
            }
            }
            else
            {
                throw new ArgumentException("No se puede dar de Baja este punto de interés. ¡Vuelva a intentarlo!");
            }

        }




        /* Modificar - Parada POI Linea - Modifico para una parada de colectivo para una determinada Linea*/
        public void modificarPOILinea(string numLinea, String paradaExistente, String paradaModificada)//Solo modifico si la linea existe
        {

            if (!noExistePOI(numLinea) && !noExistePOI(paradaExistente) && !noExistePOI(paradaModificada))//Verifico que la linea ingresada no sean nula, es decir, que se ingrese
            {
                List<string> listaFiltrada = new List<string>(listaDeLineas.Where(x => x == numLinea).ToList());

            
            if (listaFiltrada.ToString().Length == 0) //La linea no existe
            {
                throw new System.ArgumentException("No se puede Modificar este punto de interés");

            }
            else if (listaFiltrada.ToString().Length > 0)
            {

               List<string> listaFiltradaParadas = new List<string>(paradasDeEstaLinea.Where(x => x == paradaExistente).ToList());

                
                if (listaFiltradaParadas.ToString().Length <= 0) //La parada no existe
                {
                    throw new System.ArgumentException("No se puede Modificar este punto de interés ya que no existe la parada que desea modificar");

                }
                else
                {
                    //MODIFICACIÓN DE LA NUEVA PARADA:

                    //Elimino la parada anterior
                    paradasDeEstaLinea.Remove(paradaExistente);
                    //Agrego la parada nueva
                    paradasDeEstaLinea.Add(paradaModificada);
                        //hola, soy un comentario
                        paradas.Add(paradaModificada);
                }

            }
            else
            {
                throw new System.ArgumentException("No se puede Modificar este punto de interés");
            }

            }
            else
            {
                throw new ArgumentException("No se puede Modificar este punto de interés. ¡Vuelva a intentarlo!");
            }
        }



        /* Modificar - Parada POI Linea - Modifico una Línea de Colectivo*/
        public void modificarPOILinea(string numLineaExistente, String numLineaModificada)//Solo modifico si la linea existe
        {

            if (!noExistePOI(numLineaExistente) && !noExistePOI(numLineaModificada))//Verifico que la linea ingresada no sean nula, es decir, que se ingrese
            {
                List<string> listaFiltrada = new List<string>(listaDeLineas.Where(x => x == numLineaExistente).ToList());


                if (listaFiltrada.ToString().Length == 0) //La linea no existe
                {
                    throw new System.ArgumentException("No se puede Modificar este punto de interés");

                }
                else if (listaFiltrada.ToString().Length > 0)
                {

                    List<string> listaFiltradaLineas = new List<string>(listaDeLineas.Where(x => x == numLineaModificada).ToList());


                    if (listaFiltradaLineas.ToString().Length <= 0) //La línea no existe
                    {
                        throw new System.ArgumentException("No se puede Modificar este punto de interés ya que no existe la parada que desea modificar");

                    }
                    else
                    {
                        //MODIFICACIÓN DE LA NUEVA LÍNEA:

                        //Elimino la linea anterior
                        listaDeLineas.Remove(numLineaExistente);
                        //Agrego la linea nueva
                        listaDeLineas.Add(numLineaModificada);
                        //hola, soy un comentario
                        lineas.Add(numLineaModificada);
                    }

                }
                else
                {
                    throw new System.ArgumentException("No se puede Modificar este punto de interés");
                }

            }
            else
            {
                throw new ArgumentException("No se puede Modificar este punto de interés. ¡Vuelva a intentarlo!");
            }
        }

    }
}