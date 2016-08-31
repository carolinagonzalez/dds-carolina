﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        ////////////////Atributos////////////////
        public new int id { get; set; }
        public new DbGeography coordenada { get; set; }
        public new string calle { get; set; }
        public new int numeroAltura { get; set; }
        public new int piso { get; set; }
        public new int unidad { get; set; }
        public new int codigoPostal { get; set; }
        public new string localidad { get; set; }
        public new string barrio { get; set; }
        public new string provincia { get; set; }
        public new string pais { get; set; }
        public new string entreCalles { get; set; }
        public new string palabraClave { get; set; }
        public new string tipoDePOI { get; set; }
        public virtual new List<HorarioAbierto> horarioAbierto { get; set; }
        public virtual new List<HorarioAbierto> horarioFeriado { get; set; }
        public int numeroDeComuna { get; set; }
        public virtual List<ServicioCGP> servicios { get; set; }
        public int zonaDelimitadaPorLaComuna { get; set; }

        ////////////////Constructor Vacio////////////////
        public CGP() {
            servicios = new List<ServicioCGP>();
        }

        ////////////////Constructor Viejo(Usado en controlador////////////////
        public CGP(string nombre, DbGeography unaCoordenada, int zona)
        : base (nombre, unaCoordenada)
        {
            palabraClave = nombre;
            coordenada = unaCoordenada;
            zonaDelimitadaPorLaComuna = zona;
            servicios = new List<ServicioCGP>();
        }


        ////////////////Constructor generico////////////////
        public CGP(DbGeography unaCoordenada, string calle, int numeroAltura, int piso, int unidad,
           int codigoPostal, string localidad, string barrio, string provincia, string pais, string entreCalles, string palabraClave,
           string tipoDePOI, int numeroDeComuna)
            /* agregar mas adelante
             * , List<HorarioAbierto> horarioAbierto, List<HorarioAbierto> horarioFeriado, int numeroDeComuna,
           List<ServicioCGP> servicios, int zonaDelimitadaPorLaComuna*/
        {
            this.coordenada = unaCoordenada;
            this.calle = calle;
            this.numeroAltura = numeroAltura;
            this.piso = piso;
            this.unidad = unidad;
            this.codigoPostal = codigoPostal;
            this.localidad = localidad;
            this.barrio = barrio;
            this.provincia = provincia;
            this.pais = pais;
            this.entreCalles = entreCalles;
            this.palabraClave = palabraClave;
            this.tipoDePOI = tipoDePOI;
            // TODO
            this.numeroDeComuna = numeroDeComuna;
            /*
            this.horarioAbierto = horarioAbierto;
            this.horarioFeriado = horarioFeriado;
            this.servicios = servicios;
            this.zonaDelimitadaPorLaComuna = zonaDelimitadaPorLaComuna;*/

        }


    ////////////////Funcion manhattan////////////////
    private static double functionManhattan(DbGeography coordenadaDeDispositivoTactil, DbGeography coordenada)
        {
            double lat1InDegrees = (double)coordenadaDeDispositivoTactil.Latitude;
            double long1InDegrees = (double)coordenadaDeDispositivoTactil.Longitude;

            double lat2InDegrees = (double)coordenada.Latitude;
            double long2InDegrees = (double)coordenada.Longitude;

            double lats = (double)Math.Abs(lat1InDegrees - lat2InDegrees);
            double lngs = (double)Math.Abs(long1InDegrees - long2InDegrees);

            //grados a metros
            double latm = lats * 60 * 1852;
            double lngm = (lngs * Math.Cos((double)lat1InDegrees * Math.PI / 180)) * 60 * 1852;
            double distInMeters = Math.Sqrt(Math.Pow(latm, 2) + Math.Pow(lngm, 2));
            return distInMeters;

        }

        ////////////////Cálculo de Cercanía genérico - distancia menor a 5 cuadras////////////////
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (functionManhattan(coordenada, coordenadaDeDispositivoTactil) / 100) < zonaDelimitadaPorLaComuna;
        }


        // -------------------- ABM CGP --------------------------
        public void agregarCGP(CGP cgp)
        {
            using (var db = new BuscAR())
            {
                db.CGPs.Add(cgp);
                db.SaveChanges();
            }
        }

        public void eliminarCGP(int id)
        {
            using (var db = new BuscAR())
            {

                CGP cgp = db.CGPs.Where(p => p.id == id).Single();

                db.CGPs.Remove(cgp);
                db.SaveChanges();
            }


        }

    }
}