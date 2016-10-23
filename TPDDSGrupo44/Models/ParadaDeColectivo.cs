﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;

namespace TPDDSGrupo44.Models
{

    public class ParadaDeColectivo : PuntoDeInteres
    {
        
        public new string lineaDeColectivo { get; set; }
        
        ////////////////Constructor vacio////////////////
        public ParadaDeColectivo() { }

        ////////////////Constructor generico////////////////
        public ParadaDeColectivo(DbGeography unaCoordenada, string calle, int numeroAltura, int piso, int unidad,
           int codigoPostal, string localidad, string barrio, string provincia, string pais, string entreCalles, List<string> palabrasClave,
           string nombreDePOI,string tipoDePOI, string lineaDeColectivo)
        {
            
            base.coordenada = unaCoordenada;
            base.calle = calle;
            base.numeroAltura = numeroAltura;
            base.piso = piso;
            base.unidad = unidad;
            base.codigoPostal = codigoPostal;
            base.localidad = localidad;
            base.barrio = barrio;
            base.provincia = provincia;
            base.pais = pais;
            base.entreCalles = entreCalles;
            base.palabrasClave = palabrasClave;
            base.nombreDePOI = nombreDePOI;
            base.tipoDePOI = tipoDePOI;
            this.lineaDeColectivo = lineaDeColectivo;
        }





        ////////////////Constructor Viejo(Usado en controlador////////////////
        public ParadaDeColectivo(string nombre, DbGeography unaCoordenada):base(nombre, unaCoordenada)
        {
            this.nombreDePOI = nombre;
            this.coordenada = unaCoordenada;
        }

       

        ////////////////Cálculo de Cercanía genérico - distancia menor a 1 cuadras////////////////
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (functionManhattan(coordenada, coordenadaDeDispositivoTactil) / 100) < 1;
        }

        ////////////////Cálculo de Disponibilidad Horaria - Siempre está disponible////////////////
        public override bool estaDisponible(DateTime searchTime)
        {
            return true;
        }


        public void agregarParada(ParadaDeColectivo parada)
        {
            using (var db = new BuscAR())
            {
                db.Paradas.Add(parada);
                db.SaveChanges();
            }
        }

        public void eliminarParada(int id)
        {
            using (var db = new BuscAR())
            {

                ParadaDeColectivo parada = db.Paradas.Where(p => p.id == id).Single();

                db.Paradas.Remove(parada);
                db.SaveChanges();
            }


        }


        public void actualizar(string calle, int numeroAltura, int codigoPostal, string localidad, string barrio, string provincia, string pais,
            string entreCalles, List<string> palabrasClave, string nombreDePOI)
        {
            this.calle = calle;
            this.numeroAltura = numeroAltura;
            this.codigoPostal = codigoPostal;
            this.localidad = localidad;
            this.barrio = barrio;
            this.provincia = provincia;
            this.pais = pais;
            this.entreCalles = entreCalles;
            this.palabrasClave = palabrasClave;
            this.nombreDePOI = nombreDePOI;
        }



    }
}
