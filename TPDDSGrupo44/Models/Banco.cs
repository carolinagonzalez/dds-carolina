using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace TPDDSGrupo44.Models
{

    [Table("Bancos")]
    public class Banco : PuntoDeInteres
    {
        ////////////////Atributos////////////////
        public virtual ICollection<Servicio> servicios { get; set; }

        ////////////////Constructor vacio///////////////
        public Banco()
        {
            servicios = new List<Servicio>();
        }

    
        ////////////////Constructor JSON (usado para generar bancos a partir del JSON que tiene poca data)////////////////
        public Banco(string nombre, DbGeography unaCoordenada, List<string> serviciosJSON) :base(nombre, unaCoordenada)
        {
            nombreDePOI = nombre;
            coordenada = unaCoordenada;
            servicios = new List<Servicio>();
            horarioAbierto = new List<HorarioAbierto>();
            horarioFeriado = new List<HorarioAbierto>();

            foreach (string servicio in serviciosJSON)
            {
                Servicio serv = new Servicio(servicio);
                servicios.Add(serv);
            }

        }
        ////////////////Constructor generico////////////////
        public Banco(DbGeography unaCoordenada, string calle, int numeroAltura, int piso, int unidad,
           int codigoPostal, string localidad, string barrio, string provincia, string pais, string entreCalles, List<string> palabrasClave
           ,string nombreDePOI, List<HorarioAbierto> horarioAbierto, List<HorarioAbierto> horarioFeriado, List<Servicio> servicios)

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
            this.servicios = servicios;
        }

      
        ////////////////Cálculo de Cercanía genérico - distancia menor a 5 cuadras////////////////
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (functionManhattan(coordenada, coordenadaDeDispositivoTactil) / 100) < 5;
        }



        //--------------- ABM BANCO --------------------
        public void agregarBanco(Banco banco)
        {
            using (var db = new BuscAR())
            {
                db.puntosInteres.Add(banco);
                db.SaveChanges();
            }
        }

        public void eliminarBanco(int id)
        {
            using (var db = new BuscAR())
            {

                Banco banco = (Banco) db.puntosInteres.Where(p => p.id == id).Single();

                db.puntosInteres.Remove(banco);
                db.SaveChanges();
            }


        }

        public void actualizar(string calle, int numeroAltura, int piso, int unidad,
           int codigoPostal, string localidad, string barrio, string provincia, string pais, string entreCalles, string nombreDePOI,
           List<string> palabrasClave, List<HorarioAbierto> horarioAbierto, List<HorarioAbierto> horarioFeriado, List<Servicio> servicios)
        {
            base.numeroAltura = numeroAltura;
            base.piso = piso;
            base.unidad = unidad;
            base.codigoPostal = codigoPostal;
            base.localidad = localidad;
            base.barrio = barrio;
            base.provincia = provincia;
            base.pais = pais;
            base.entreCalles = entreCalles;
            base.nombreDePOI = nombreDePOI;
            base.palabrasClave = palabrasClave;
            base.horarioAbierto = horarioAbierto;
            base.horarioFeriado = horarioFeriado;
            this.servicios = servicios;
        }


    }
}
