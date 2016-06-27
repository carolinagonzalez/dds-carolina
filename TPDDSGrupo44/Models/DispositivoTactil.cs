using System;
using System.Collections.Generic;
using TPDDSGrupo44.Models;
using System.Device.Location;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44
{
    public class DispositivoTactil
    {
        [Key]
        public int Id { get; set; }

        public DbGeography coordenada { get; set; }
        public string nombre { get; set; }
        public int comuna { get; set; } 

        //Creo coleccion
        public List<PuntoDeInteres> ListaPuntosDeInteres;


        // Creo Constructor
        public DispositivoTactil(string nombreDelPunto, DbGeography unaCoordenada)
        {
            nombre = nombreDelPunto;
            coordenada = unaCoordenada;
        }

        //1
        public bool estaCerca(PuntoDeInteres unPuntoDeInteres) {
            return unPuntoDeInteres.estaCerca(coordenada);

        }

        public List<PuntoDeInteres> listaDePtos = new List<PuntoDeInteres>();

        public List<PuntoDeInteres> palabraClave(string clave)
        {
            List<PuntoDeInteres> filteredList = listaDePtos.Where(x => x.palabraClave == clave).ToList();
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
    }
}