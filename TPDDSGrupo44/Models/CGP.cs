using System;
using System.Device.Location;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        public string direccion { get; set; }
        public int numero { get; set; }
        public List<Servicio> servicios { get; set; }
        public int zonaDelimitadaPorLaComuna { get; set; }

        // Creo Constructor

        public CGP(string nombre, GeoCoordinate unaCoordenada, int zona)
        : base(nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            zonaDelimitadaPorLaComuna = zona;
            servicios = new List<Servicio>();
        }
        /*
        public CGP()
        {
            this.posibilidades = new List<String>() { "Atencion al publico", "Rentas", "Registro Civil", "Multas" };

        }
        */

        //2.	Los CGP cumplen la condición de cercanía, si su coordenada está dentro de la zona delimitada por la comuna.
        public new bool estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada) / 100) < zonaDelimitadaPorLaComuna; //Cuadras
        }
    }
}