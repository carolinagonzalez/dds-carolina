﻿using System;
using System.Device.Location;

namespace TPDDSGrupo44.Models
{
    public class LocalComercial : PuntoDeInteres
    {
        public DateTime horario { get; set; }
        
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
            this.nombreDelPOI = nombre;
            this.coordenada = unaCoordenada;
            this.consultoCercania = new ConsultoCercania();
            this.palabrasRelacionadas.Add(rubro.nombreRubro);
        }

        /*
    public LocalComercial()
    {

        this.posibilidades = new List<String>() { "Kiosco", "Libreria Escolar" };
    }*/

        public new Boolean estaCerca(GeoCoordinate coordenadaDeDispositivoTactil)
        {
            return this.consultoCercania.obtengoDistancia(coordenadaDeDispositivoTactil, this.coordenada) < this.rubro.radioDeCercania; //Cuadras
        }




    }
}