using System;
using System.Collections.Generic;
using TPDDSGrupo44.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44
{
    public class DispositivoTactil
    {
        [Key]
        ////////////////Atributos////////////////
        public int Id { get; set; }

        public DbGeography coordenada { get; set; }
        public string nombre { get; set; }
        public int comuna { get; set; } 

        //Creo coleccion
        public List<PuntoDeInteres> ListaPuntosDeInteres;

        ////////////////Constructor vacio////////////////
        public DispositivoTactil() { }

        ////////////////Creo Constructor////////////////
        public DispositivoTactil(string nombreDelPunto, DbGeography unaCoordenada)
        {
            nombre = nombreDelPunto;
            coordenada = unaCoordenada;
        }

        //1
        public bool estaCerca(PuntoDeInteres unPuntoDeInteres) {
            return unPuntoDeInteres.estaCerca(coordenada);

        }


        public List<PuntoDeInteres> palabraClave(string clave)
        {
            List<PuntoDeInteres> filteredList = ListaPuntosDeInteres.Where(x => x.palabraClave == clave).ToList();
            return filteredList;
        }

        public bool colleccionConDatos(List<PuntoDeInteres> lista)
        {
            if (lista.Count > 0)
            {
                foreach (PuntoDeInteres alista in lista)
                {
                    Console.WriteLine(alista);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //2
        /*
        public Boolean estaDisponible(PuntoDeInteres unPuntoDeInteres)
        {
            return unPuntoDeInteres.estaDisponible(this.coordenada);

        }
        */


        public void agregarPoid(PuntoDeInteres poid)
        {
            ListaPuntosDeInteres.Add(poid);
        }

        public void eliminarPoid(PuntoDeInteres poid)
        {
            ListaPuntosDeInteres.Remove(poid);

        }







    }
}