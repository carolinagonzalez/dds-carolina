using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

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
        public new List<HorarioAbierto> horarioAbierto { get; set; }
        public new List<HorarioAbierto> horarioFeriado { get; set; }
        public List<ServicioBanco> servicios { get; set; }

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
        





    }
}
