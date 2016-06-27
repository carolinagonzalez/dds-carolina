using System.Device.Location;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Models
{
    public class Banco : PuntoDeInteres
    {
        public List<Servicio> servicios { get; set; }

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
