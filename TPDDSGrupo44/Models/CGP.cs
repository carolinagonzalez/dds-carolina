using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        [Key]
        public new int Id { get; set; }
        public new string nombreDelPOI { get; set; }
        public new DbGeography coordenada { get; set; }

        public string direccion { get; set; }
        public int numero { get; set; }
        public List<ServicioCGP> servicios { get; set; }
        public int zonaDelimitadaPorLaComuna { get; set; }

        public CGP() { }

        // Constructor
        public CGP(string nombre, DbGeography unaCoordenada, int zona)
        : base (nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            zonaDelimitadaPorLaComuna = zona;
            servicios = new List<ServicioCGP>();
        }

        // Cálculo de Cercanía - Dentro de la zona de la Comuna
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.Distance(coordenada) / 100) < zonaDelimitadaPorLaComuna; //Cuadras
        }
    }
}