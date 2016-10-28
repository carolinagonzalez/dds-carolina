
using System.Data.Entity.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSGrupo44.Models
{
    [Table("LocalesComercial")]
    public class LocalComercial : PuntoDeInteres
    {

        ////////////////Atributos////////////////

        public virtual Rubro rubro { get; set; }

        public new string nombreFantasia { get; set; }


        ////////////////Constructor vacio////////////////
        public LocalComercial() { }


        ////////////////Constructor Viejo(Usado en controlador////////////////
        public LocalComercial(string nombre, DbGeography unaCoordenada, Rubro rubro)
        :base (nombre, unaCoordenada)
        {
            this.rubro = rubro;
            coordenada = unaCoordenada;
            nombreDePOI = nombre;
        }

        public LocalComercial(DbGeography unaCoordenada, string calle, int numeroAltura, int piso, int unidad,
           int codigoPostal, string localidad, string barrio, string provincia, string pais, string entreCalles, List<string> palabrasClave,
           string nombreDePOI, List<HorarioAbierto> horarioAbierto, List<HorarioAbierto> horarioFeriados,
           Rubro rubro, string nombreFantasia)
        {

            base.coordenada = unaCoordenada;
            base.calle = calle;
            base.numeroAltura = numeroAltura;
            base.piso = piso;
            base.unidad = unidad;
            base.codigoPostal = codigoPostal;
            base.localidad = localidad;
            base.barrio = barrio;
            base.provincia = provincia;
            base.pais = pais;
            base.entreCalles = entreCalles;
            base.palabrasClave = palabrasClave;
            base.nombreDePOI = nombreDePOI;
            base.horarioAbierto = horarioAbierto;
            base.horarioFeriado = horarioFeriados;
            this.rubro = rubro;
            this.nombreFantasia = nombreFantasia;

        }


        //E4 - JM - Constructor para actualización asincrónica
        public LocalComercial (string nombre, List<string> palabras)
        {
            nombreDePOI = nombre;
            palabrasClave = palabras;
        }


        

        ////////////////Cálculo de Cercanía - Depende del radio de cercanía del rubro////////////////
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (functionManhattan(coordenada, coordenadaDeDispositivoTactil) / 100) < rubro.radioDeCercania; //Cuadras
        }


        //////////////// ABM Local Comercial ////////////////
        public void agregarLocComercial(LocalComercial localComercial)
        {
            using (var db = new BuscAR())
            {
                db.puntosInteres.Add(localComercial);
                db.SaveChanges();
            }
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

        List<string> listaDePalabrasClaves = new List<string> { "Escolar", "Textil", "Automotor" };

        List<string> listaDeRubros = new List<string> { "Escolar", "Textil", "Automotor" };


        /* Alta - POI Local Comercial */
        /*Este proceso debe actualizar la lista de locales comerciales y
         *  la lista de palabras clave de asociadas a cada uno. */



        //public void proceso4ActualizarPOILocalComercial(string nombreDeFantasia, List<string> palabrasClaves)
        public void proceso4ActualizarPOILocalComercial(string nombreDeFantasia, string nombreDePOI)
        {
            if (!noExistePOI(nombreDeFantasia) && !noExistePOI(nombreDePOI))
            {
                List<string> listaFiltradaDeLocales = new List<string>(listaDeLocales.Where(x => x == nombreDeFantasia.ToString()).ToList());

               List<string> listaFiltradaDePalabrasClaves = new List<string>(listaDePalabrasClaves.Where(x => x == rubro.ToString()).ToList());


                if (listaFiltradaDeLocales.ToString().Length == 0) //El local no existe => Lo puedo agregar como POI
                {
                    if (listaDePalabrasClaves.ToString().Length == 0)
                    {

                        //Creo las paradas de esta linea
                        List<String> rubrosDeEsteLocalComercial = new List<String>();

                        //Doy de Alta el nuevo Rubro
                        rubrosDeEsteLocalComercial.Add(nombreDeFantasia);

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
               // else if (listaFiltradaDeRubro.ToString().Length > 0) //Ya existe el rubro
                {
                    //Si el local ya existe, lo agrego al rubro
                    //Agrego nombre del rubro y el resto de sus datos
                    List<tipoLocal> listado = new List<tipoLocal>();
                    //listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mi pequeño pony", radioCercania = 22, new GeoCoordinate(-34.81725, -58.4476116), Rubro jugueteria, DateTime dateRubro, "Av Rivadavia 1234", 1, A });

                    listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mi pequeño pony", radioCercania = 2, direccion = "Av Rivadavia 1234", piso = 1, dto = 'A' });

                    listado.Add(new tipoLocal { nombreRubro = "Jugueteria", nombreLocalComercial = "Mario", radioCercania = 2, direccion = "Av Alvarez Jonte 4355", piso = 1, dto = 'B' });
                    listado.Add(new tipoLocal { nombreRubro = "Libreria", nombreLocalComercial = "San roman", radioCercania = 44, direccion = "Alvear 55", piso = 1, dto = 'B' });


                }
                //else
                {
                    throw new System.ArgumentException("No se puede dar de Alta este punto de interés");
                }

            }
            else
            {
                throw new ArgumentException("No se puede realizar la Alta este punto de interés. ¡Vuelva a intentarlo!");
            }
        }






        //Alta Local Comercial
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