using System;
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

        // Creo Constructor

        public LocalComercial(string nombre, GeoCoordinate unaCoordenada, Rubro rubro)
        : base(nombre, unaCoordenada)
        {
            this.rubro = rubro;
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            palabraClave = nombre;
            palabrasRelacionadas.Add(rubro.nombreRubro);
        }

        /*
    public LocalComercial()
    {

        this.posibilidades = new List<String>() { "Kiosco", "Libreria Escolar" };
    }*/

        public new bool estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada) / 100) < rubro.radioDeCercania; //Cuadras
        }




    }
}