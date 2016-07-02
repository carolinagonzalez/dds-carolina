
﻿using System.Data.Entity.Spatial;
﻿using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;



namespace TPDDSGrupo44.Models
{
    public class LocalComercial : PuntoDeInteres
    {
        public Rubro rubro { get; set; }
        public new string nombreDelPOI { get; set; }
        public new DbGeography coordenada { get; set; }

        // Constructor
        public LocalComercial(string nombre, DbGeography unaCoordenada, Rubro rubro)
        : base(nombre, unaCoordenada)
        {
            this.rubro = rubro;
            nombreDelPOI = nombre;
            coordenada = unaCoordenada;
            palabraClave = nombre;
            palabrasRelacionadas.Add(rubro.nombre);
        }


        public LocalComercial() { }

        //Sobrecarga
        public LocalComercial(string nombreRubro, int radioCercania, DbGeography unaCoordenada, Rubro rubro, DateTime dateRubro, string direccion, int piso, char dto)
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




        List<string> listaDeLocales = new List<string> { "Kiosco 123", "Libreria abc" };



        public List<string> listaLocalesComerciales { get; set; }


        struct tipoLocal
        {


            public string nombreRubro;
            public string nombreLocalComercial;
            public int radioCercania;
            //public GeoCoordinate unaCoordenada;
            //public Rubro rubro;
            //public DateTime dateRubro;
            public string direccion;
            public int piso;
            public char dto;

        }



      //  List<string> listaDeLocales = new List<string> { "Bufette Campus", "Libreria Mario", "Coto" };

        List<string> listaDeRubros = new List<string> { "Escolar", "Textil", "Automotor" };


        /* Alta - POI Local Comercial */

        public void agregarPOILocalComercialT(string nombreRubro, string nombreLocalComercial, int radioCercania, DbGeography unaCoordenada, Rubro rubro, DateTime dateRubro, string direccion, int piso, char dto)
        {

            if (!noExistePOI(nombreRubro) && !noExistePOI(nombreLocalComercial) && !noExistePOI(direccion))
            {
                List<string> listaFiltradaDeLocales = new List<string>(listaDeLocales.Where(x => x == nombreLocalComercial.ToString()).ToList());

                List<string> listaFiltradaDeRubro = new List<string>(listaDeRubros.Where(x => x == rubro.ToString()).ToList());

                
                if (listaFiltradaDeRubro.ToString().Length == 0) //El Rubro no existe => Lo puedo agregar como POI
                {
                    if (listaFiltradaDeLocales.ToString().Length == 0)
                    {
                   
                    //Creo las paradas de esta linea
                    List<String> rubrosDeEsteLocalComercial = new List<String>();

                    //Doy de Alta el nuevo Rubro
                    rubrosDeEsteLocalComercial.Add(nombreRubro);

                    //Agrego nombre del rubro y el resto de sus datos
                    List<tipoLocal> listado = new List<tipoLocal>();
                    //listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mi pequeño pony", radioCercania = 22, new GeoCoordinate(-34.81725, -58.4476116), Rubro jugueteria, DateTime dateRubro, "Av Rivadavia 1234", 1, A });

                    listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mi pequeño pony", radioCercania = 2, direccion = "Av Rivadavia 1234", piso = 1, dto = 'A' });

                    listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mario", radioCercania = 2, direccion = "Av Alvarez Jonte 4355", piso = 1, dto = 'B' });
                    listado.Add(new tipoLocal { nombreRubro = "Libreria", nombreLocalComercial = "San roman", radioCercania = 44, direccion = "Alvear 55", piso = 1, dto = 'B' });

                    }
                    else if (listaFiltradaDeLocales.ToString().Length > 0) //ya existe el local comercial
                    {


                        //Agrego nombre del rubro y el resto de sus datos
                        List<tipoLocal> listado = new List<tipoLocal>();
                        //listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mi pequeño pony", radioCercania = 22, new GeoCoordinate(-34.81725, -58.4476116), Rubro jugueteria, DateTime dateRubro, "Av Rivadavia 1234", 1, A });

                        listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mi pequeño pony", radioCercania = 2, direccion = "Av Rivadavia 1234", piso = 1, dto = 'A' });

                        listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mario", radioCercania = 2, direccion = "Av Alvarez Jonte 4355", piso = 1, dto = 'B' });
                        listado.Add(new tipoLocal { nombreRubro = "Libreria", nombreLocalComercial = "San roman", radioCercania = 44, direccion = "Alvear 55", piso = 1, dto = 'B' });

                    }
                
                    else
                    {
                        throw new ArgumentException("No se puede realizar la Alta este punto de interés. ¡Vuelva a intentarlo!");
                    }

                }
                else if (listaFiltradaDeRubro.ToString().Length > 0) //Ya existe el rubro
                {
                    //Si el local ya existe, lo agrego al rubro
                    //Agrego nombre del rubro y el resto de sus datos
                    List<tipoLocal> listado = new List<tipoLocal>();
                    //listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mi pequeño pony", radioCercania = 22, new GeoCoordinate(-34.81725, -58.4476116), Rubro jugueteria, DateTime dateRubro, "Av Rivadavia 1234", 1, A });

                    listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mi pequeño pony", radioCercania = 2, direccion = "Av Rivadavia 1234", piso = 1, dto = 'A' });

                    listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mario", radioCercania = 2, direccion = "Av Alvarez Jonte 4355", piso = 1, dto = 'B' });
                    listado.Add(new tipoLocal { nombreRubro = "Libreria", nombreLocalComercial = "San roman", radioCercania = 44, direccion = "Alvear 55", piso = 1, dto = 'B' });


                }
                else
                {
                    throw new System.ArgumentException("No se puede dar de Alta este punto de interés");
                }

            }
            else
            {
                throw new ArgumentException("No se puede realizar la Alta este punto de interés. ¡Vuelva a intentarlo!");
            }
        }



        /* Baja - POI Local Comercial */
        public void bajarPOILocalComercial(string nombreLocalComercial)
        {

            if (!noExistePOI(nombreLocalComercial))
            {
                List<string> listaFiltrada = new List<string>(listaDeLocales.Where(x => x == nombreLocalComercial).ToList());


                if (listaFiltrada.ToString().Length == 0) //El local comercial no existe
                {
                    throw new System.ArgumentException("No se puede dar de Baja el local comerecial ya que no existe este punto de interés");

                }
                else if (listaFiltrada.ToString().Length > 0)//La linea existe
                {
                    //Doy de baja la parada que se desea borrar
                    listaDeLocales.Remove(nombreLocalComercial);
                }
                else
                {
                    throw new System.ArgumentException("No se puede dar de Baja este punto de interés");
                }

            }
            else
            {
                throw new ArgumentException("No se puede dar de Baja este punto de interés. ¡Vuelva a intentarlo!");
            }
        }



    }
}