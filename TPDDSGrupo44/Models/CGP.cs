﻿using System.Device.Location;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        public string direccion { get; set; }
        public int numero { get; set; }
        public List<Servicio> servicios { get; set; }
        public int zonaDelimitadaPorLaComuna { get; set; }



        // Constructor
        public CGP(string nombre, GeoCoordinate unaCoordenada, int zona)
        : base (nombre, unaCoordenada)
        {
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            zonaDelimitadaPorLaComuna = zona;
            servicios = new List<Servicio>();
        }

        // Cálculo de Cercanía - Dentro de la zona de la Comuna
        public override bool estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.GetDistanceTo(coordenada) / 100) < zonaDelimitadaPorLaComuna; //Cuadras
        }
    }
}