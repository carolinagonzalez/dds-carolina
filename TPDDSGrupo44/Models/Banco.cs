﻿using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;

namespace TPDDSGrupo44.Models
{
    public class Banco : PuntoDeInteres
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
        public virtual List<ServicioBanco> servicios { get; set; }

        ////////////////Constructor vacio////////////////
        public Banco() { }

        ////////////////Constructor Viejo(Usado en controlador////////////////
        public Banco(string nombre, DbGeography unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            palabraClave = nombre;
            coordenada = unaCoordenada;
            servicios = new List<ServicioBanco>();
        }
        ////////////////Constructor generico////////////////
        public Banco(DbGeography unaCoordenada, string calle, int numeroAltura, int piso, int unidad,
           int codigoPostal, string localidad, string barrio, string provincia, string pais, string entreCalles, string palabraClave,
           string tipoDePOI)

        /* agregar mas adelante 
         *  List<HorarioAbierto> horarioAbierto, List<HorarioAbierto> horarioFeriado, List<ServicioBanco> servicios
         * */

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
           /* this.horarioAbierto = horarioAbierto;
            this.horarioFeriado = horarioFeriado;
            this.servicios = servicios;*/
        
        }
         
        //--------------- ABM BANCO --------------------
        public void agregarBanco(Banco banco)
        {
            using (var db = new BuscAR())
            {
                db.Bancos.Add(banco);
                db.SaveChanges();
            }
        }

        public void eliminarBanco(int id)
        {
            using (var db = new BuscAR())
            {

                Banco banco = db.Bancos.Where(p => p.id == id).Single();

                db.Bancos.Remove(banco);
                db.SaveChanges();
            }


        }

    }
}
