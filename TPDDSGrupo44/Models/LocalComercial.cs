using System.Data.Entity.Spatial;
using System.Device.Location;

namespace TPDDSGrupo44.Models
{
    public class LocalComercial : PuntoDeInteres
    {
        
        public string direccion { get; set; }
        public int numero { get; set; }
        public int piso { get; set; } //Se refiere a piso = 8 ?
        public char dpto { get; set; }//Se refiere a o dto = A ??

        public Rubro rubro { get; set; }

        // Constructor
        public LocalComercial(string nombre, DbGeography unaCoordenada, Rubro rubro)
        : base(nombre, unaCoordenada)
        {
            this.rubro = rubro;
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            palabraClave = nombre;
            palabrasRelacionadas.Add(rubro.nombreRubro);
        }
        
        // Cálculo de Cercanía - Depende del radio de cercanía del rubro
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.Distance(coordenada) / 100) < rubro.radioDeCercania; //Cuadras
        }




    }
}