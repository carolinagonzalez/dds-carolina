
﻿using System.Data.Entity.Spatial;
﻿using System;
using System.Collections.Generic;
using System.Device.Location;

>>>>>>> origin/master

namespace TPDDSGrupo44.Models
{
    public class LocalComercial : PuntoDeInteres
    {
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


        //Sobrecarga
        public LocalComercial(string nombreRubro, int radioCercania, GeoCoordinate unaCoordenada, Rubro rubro, DateTime dateRubro, string direccion, int piso, char dto)
        : base(nombreRubro, radioCercania, unaCoordenada, rubro, dateRubro, direccion, piso, dto)
        {
            this.rubro = rubro;
            nombreDelPOI = nombreRubro;
            coordenada = unaCoordenada;


        }

        public List<String> localesComerciales { get; set; }


        /* Getters */
        public List<String> getLocales()
        {
            return localesComerciales;
        }

        /* Setters */
        public void validarLocalesComerciales(List<String> localesComerciales)
        {
            if (localesComerciales.Equals(null))
            {
                throw new System.ArgumentException("No se puede ingresar un Local Comercial nulo");
            }
            this.localesComerciales = localesComerciales;
        }


       


        /* Validaciones */
        public Boolean noExistePOI(string POI)
        {
            if (this.getLocales().Equals(null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // Cálculo de Cercanía - Depende del radio de cercanía del rubro
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.Distance(coordenada) / 100) < rubro.radioDeCercania; //Cuadras
        }




    }
}