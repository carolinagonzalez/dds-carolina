using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Models
{
    public class Banco : PuntoDeInteres
    {
        public List<ServicioBanco> servicios { get; set; }

        public Banco() { }

        [Key]
        public new int Id { get; set; }
        public new string nombreDelPOI { get; set; }
        public new DbGeography coordenada { get; set; }

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
