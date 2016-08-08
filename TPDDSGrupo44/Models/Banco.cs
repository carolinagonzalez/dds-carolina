using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Models
{
    public class Banco : PuntoDeInteres
    {
       
        public new int id { get; set; }

        public List<ServicioBanco> servicios { get; set; }
        public string nombreDelPOI { get; set; }
        public new DbGeography coordenada { get; set; }


        public Banco() { }

        // Constructor
        public Banco(string nombre, DbGeography unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            palabraClave = nombre;
            servicios = new List<ServicioBanco>();
        }
        

    }
}
