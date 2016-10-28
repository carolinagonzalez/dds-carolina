using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace TPDDSGrupo44.Models
{
    [Table("CGPS")]
    public class CGP : PuntoDeInteres
    {
        ////////////////Atributos////////////////
     
        public int numeroDeComuna { get; set; }
        public virtual ICollection<Servicio> servicios { get; set; }
        public int zonaDelimitadaPorLaComuna { get; set; }

        ////////////////Constructor Vacio////////////////
        public CGP(){
            servicios = new List<Servicio>();
        }

        //public CGP() : base(){}

        /*  ////////////////Constructor Viejo(Usado en controlador////////////////
          public CGP(string nombre, DbGeography unaCoordenada, int zona)
          : base (nombre, unaCoordenada)
          {
              nombreDePOI = nombre;
              coordenada = unaCoordenada;
              zonaDelimitadaPorLaComuna = zona;
              servicios = new List<Servicio>();
          }*/

/*  Ver bien 
       ////////////////Constructor JSON (usado para generar cgp a partir del JSON que tiene poca data)////////////////
        public CGP(int comuna, string zonas, string director, string domicilio, string telefono, List<string> serviciosJSON) : base()
        {
            servicios = new List<Servicio>();
            horarioAbierto = new List<HorarioAbierto>();
            horarioFeriado = new List<HorarioAbierto>();

            foreach (string servicio in serviciosJSON)
            {
                Servicio serv = new Servicio(servicio);
                servicios.Add(serv);
            }
        }

        public CGP(int comuna, string director, string domicilio, List<string> servicios1, string telefono, string zonas)
        {
            this.comuna = comuna;
            this.director = director;
            this.domicilio = domicilio;
            this.servicios1 = servicios1;
            this.telefono = telefono;
            this.zonas = zonas;
        }
        */

        ////////////////Constructor generico////////////////
        public CGP(DbGeography unaCoordenada, string calle, int numeroAltura, int piso, int unidad,
        int codigoPostal, string localidad, string barrio, string provincia, string pais, string entreCalles, List<string> palabrasClave,
        string nombreDePOI, int numeroDeComuna, List<Servicio> servicios, int zonaDelimitadaPorLaComuna,
        List<HorarioAbierto> horarioAbierto, List<HorarioAbierto> horarioFeriado)
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
            base.horarioAbierto = horarioAbierto;
            base.horarioFeriado = horarioFeriado;
            this.numeroDeComuna = numeroDeComuna;
            this.servicios = servicios;
            this.zonaDelimitadaPorLaComuna = zonaDelimitadaPorLaComuna;
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
                db.puntosInteres.Add(cgp);
                db.SaveChanges();
            }
        }

        public void eliminarCGP(int id)
        {
            using (var db = new BuscAR())
            {

                CGP cgp = (CGP) db.puntosInteres.Where(p => p.id == id).Single();

                db.puntosInteres.Remove(cgp);
                db.SaveChanges();
            }


        }

        public void actualizar(string calle, int numeroAltura, int piso, int unidad,
           int codigoPostal, string localidad, string barrio, string provincia, string pais, string entreCalles, List<string> palabrasClave,
           string nombreDePOI, int numeroDeComuna, List<Servicio> servicios, int zonaDelimitadaPorLaComuna,
           List<HorarioAbierto> horarioAbierto, List<HorarioAbierto> horarioFeriado)
        {
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
            this.palabrasClave = palabrasClave;
            this.nombreDePOI = nombreDePOI;
            this.numeroDeComuna = numeroDeComuna;
            this.horarioAbierto = horarioAbierto;
            this.horarioFeriado = horarioFeriado;
            this.servicios = servicios;
            this.zonaDelimitadaPorLaComuna = zonaDelimitadaPorLaComuna;
        }


    

    }
}