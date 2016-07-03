using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Models
{
    public class Banco : PuntoDeInteres
    {
        public List<Servicio> servicios { get; set; }

        public Banco() { }

        public new string nombreDelPOI { get; set; }
        public new DbGeography coordenada { get; set; }

        // Constructor
        public Banco(string nombre, DbGeography unaCoordenada)
        : base(nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            palabraClave = nombre;
            servicios = new List<Servicio>();
        }
        

    }
}
