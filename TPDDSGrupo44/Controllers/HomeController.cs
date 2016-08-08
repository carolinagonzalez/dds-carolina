﻿using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using TPDDSGrupo44.Models;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Controllers
{
    public class HomeController : Controller
    {
        private void mostrarLista(List<ParadaDeColectivo> listaFiltrada, String palabraBusqueda)
        {
            if (listaFiltrada.Count > 0)
            {
                foreach (ParadaDeColectivo punto in listaFiltrada)
                {
                    ViewBag.SearchText = ViewBag.SearchText + palabraBusqueda + "->" + punto.palabraClave + ",";
                    ViewBag.Search = "ok";
                }
            }
            else
            {
                ViewBag.SearchText = "No hay ningun punto de interes con esa palabra clave.";
                ViewBag.Search = "error";
            }
        }

        private void mostrarLista(List<PuntoDeInteres> listaFiltrada, String palabraBusqueda)
        {
            if (listaFiltrada.Count > 0)
            {
                foreach (PuntoDeInteres punto in listaFiltrada)
                {
                    ViewBag.SearchText = ViewBag.SearchText + palabraBusqueda + "->" + punto.palabraClave + ",";
                    ViewBag.Search = "ok";
                }
            }
            else
            {
                ViewBag.SearchText = "No hay ningun punto de interes con esa palabra clave.";
                ViewBag.Search = "error";
            }
        }
        private void mostrarLista(List<LocalComercial> listaFiltrada, String palabraBusqueda)
        {
            if (listaFiltrada.Count > 0)
            {
                foreach (LocalComercial punto in listaFiltrada)
                {
                    ViewBag.SearchText = ViewBag.SearchText + palabraBusqueda + "->" + punto.palabraClave + ",";
                    ViewBag.Search = "ok";
                }
            }
            else
            {
                ViewBag.SearchText = "No hay ningun punto de interes con esa palabra clave.";
                ViewBag.Search = "error";
            }
        }

        private void mostrarLista(List<Banco> listaFiltrada, String palabraBusqueda)
        {
            if (listaFiltrada.Count > 0)
            {
                foreach (Banco punto in listaFiltrada)
                {
                    ViewBag.SearchText = ViewBag.SearchText + palabraBusqueda + "->" + punto.palabraClave + ",";
                    ViewBag.Search = "ok";
                }
            }
            else
            {
                ViewBag.SearchText = "No hay ningun punto de interes con esa palabra clave.";
                ViewBag.Search = "error";
            }
        }

        private void mostrarLista(List<CGP> listaFiltrada, String palabraBusqueda)
        {
            if (listaFiltrada.Count > 0)
            {
                foreach (CGP punto in listaFiltrada)
                {
                    ViewBag.SearchText = ViewBag.SearchText + palabraBusqueda + "->" + punto.palabraClave + ",";
                    ViewBag.Search = "ok";
                }
            }
            else
            {
                ViewBag.SearchText = "No hay ningun punto de interes con esa palabra clave.";
                ViewBag.Search = "error";
            }
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Buscá puntos de interés, descubrí cuáles están cerca.";

            //Defino ubicación actual (UTN/CAMPUS)
            DbGeography dispositivoTactil = DbGeography.FromText("POINT(-34.6597047 -58.4688947)");
            ViewBag.Latitud = dispositivoTactil.Latitude.ToString();
            ViewBag.Longitud = dispositivoTactil.Longitude.ToString();
            ViewBag.TextoLugar = "¡Estás acá!";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection search)
        {

            ViewBag.Message = "Buscá puntos de interés, descubrí cuáles están cerca.";

            //%%%%%%%%%%%%%%   DATOS HARDCODEADOS PARA SIMUAR DB
            
            //Defino ubicación actual (UTN/CAMPUS)
            DbGeography dispositivoTactil = DbGeography.FromText("POINT(-34.6597047 -58.4688947)");
            ViewBag.Latitud = dispositivoTactil.Latitude;
            ViewBag.Longitud = dispositivoTactil.Longitude;
            ViewBag.TextoLugar = "¡Estás acá!";

            string palabraBusqueda = search["palabraClave"];


            //%%%%%%%%%%%%%%   FIN DE SIMULACION DE DATOS DE DB


            try
            {
                using (var db = new BuscAR())
                {
                    //Si la persona ingresó un número, asumo que busca una parada de bondi
                    int linea = 0;
                    if (int.TryParse(palabraBusqueda, out linea) && linea > 0)
                    {

                        List<ParadaDeColectivo> resultadosBusqueda = db.Paradas.Where(b => b.palabraClave == palabraBusqueda).ToList();
                        foreach (ParadaDeColectivo punto in resultadosBusqueda)
                        {
                            if (punto.estaCerca(dispositivoTactil))
                            {
                                ViewBag.SearchText = "¡Hay una parada del " + punto.palabraClave + " cerca!";
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = "Parada del " + punto.palabraClave;

                                ViewBag.Search = "ok";
                                break;
                            }
                            else
                            {
                                ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                                ViewBag.Search = "error";
                            }
                        }


                        //Si la persona ingresó una palabra, me fijo si es un rubro
                    }
                    else if (db.Rubros.Where(b => b.nombre.Contains(palabraBusqueda.ToLower())).ToList().Count() > 0)
                    {

                        List<LocalComercial> resultadosBusqueda = db.Locales.Where(b => b.rubro.nombre.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                        foreach (LocalComercial punto in resultadosBusqueda)
                        {
                            if (punto.estaCerca(dispositivoTactil))
                            {
                                ViewBag.SearchText = "¡Hay un local de ese rubro cerca! Visite " + punto.palabraClave;
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = punto.palabraClave;
                                ViewBag.Search = "ok";
                                break;
                            }
                            else
                            {
                                ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                                ViewBag.Search = "error";
                            }
                        }

                        // Si la palabra ingresada no era parada ni rubro, la busco como local
                    }
                    else
                    {
                        List<LocalComercial> resultadosBusquedaLocales = db.Locales.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                        if (resultadosBusquedaLocales.Count() > 0)
                        {
                            foreach (LocalComercial punto in resultadosBusquedaLocales)
                            {
                                if (punto.estaCerca(dispositivoTactil))
                                {
                                    ViewBag.SearchText = "¡Hay un local con ese nombre cerca! Visite " + punto.palabraClave;
                                    ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                    ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                    ViewBag.TextoLugar = punto.palabraClave;
                                    ViewBag.Search = "ok";
                                    break;
                                }
                                else
                                {
                                    ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                                    ViewBag.Search = "error";
                                }
                            }
                        }
                        else
                        {
                            List<Banco> resultadosBusquedaBancos = db.Bancos.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                            if (resultadosBusquedaBancos.Count() > 0)
                            {
                                foreach (Banco punto in resultadosBusquedaBancos)
                                {
                                    if (punto.estaCerca(dispositivoTactil))
                                    {
                                        ViewBag.SearchText = "¡Hay un banco con ese nombre cerca! Visite " + punto.palabraClave;
                                        ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                        ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                        ViewBag.TextoLugar = punto.palabraClave;
                                        ViewBag.Search = "ok";
                                        break;
                                    }
                                    else
                                    {
                                        ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                                        ViewBag.Search = "error";
                                    }
                                }
                            } else
                            {
                                List<CGP> resultadosBusquedaCGP = db.CGPs.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                                if (resultadosBusquedaCGP.Count() > 0)
                                {
                                    foreach (CGP punto in resultadosBusquedaCGP)
                                    {
                                        if (punto.estaCerca(dispositivoTactil))
                                        {
                                            ViewBag.SearchText = "¡Hay un CGP con ese nombre cerca! Visite " + punto.palabraClave;
                                            ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                            ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                            ViewBag.TextoLugar = punto.palabraClave;
                                            ViewBag.Search = "ok";
                                            break;
                                        }
                                        else
                                        {
                                            ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                                            ViewBag.Search = "error";
                                        }
                                    }
                                }
                            }
                        }

                    }

                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Location () {
            ViewBag.Message = "Buscá puntos de interés específicos.";
            return View();
    }

    [HttpPost]
    public ActionResult Location(FormCollection search)
        {
            ViewBag.Message = "Buscá puntos de interés específicos.";


            //%%%%%%%%%%%%%%   DATOS HARDCODEADOS PARA SIMUAR DB

            // Genero lista de POIs
            List<PuntoDeInteres> puntos = new List<PuntoDeInteres>();
            
            // Genero lista de rubros
            List<Rubro> rubros = new List<Rubro>();
            

            string palabraBusqueda = search["palabraClave"];
            DispositivoTactil device = new DispositivoTactil("UTN Campus", DbGeography.FromText("POINT(-34.6597047 -58.4688947)"));
            //%%%%%%%%%%%%%%   FIN DE SIMULACION DE DATOS DE DB

            using (var db = new BuscAR())
            {

                try
                {
                    int linea = 0;

                
                    if (int.TryParse(palabraBusqueda, out linea) && linea > 0)
                    {

                        List<ParadaDeColectivo> resultadosBusqueda = db.Paradas.Where(b => b.palabraClave == palabraBusqueda).ToList();
                        mostrarLista(resultadosBusqueda, palabraBusqueda);

                        Busqueda busqueda = new Busqueda(palabraBusqueda, resultadosBusqueda.Count(), DateTime.Today, device);
                        db.Busquedas.Add(busqueda);
                    }
                    else if ( db.Rubros.Where(b => b.nombre.ToLower().Contains(palabraBusqueda.ToLower())).ToList().Count() > 0)
                    {
                        List<LocalComercial> locales = puntos.OfType<LocalComercial>().ToList();
                        List<LocalComercial> resultadosBusqueda = db.Locales.Where(x => x.rubro.nombre.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                        mostrarLista(resultadosBusqueda, palabraBusqueda);

                        Busqueda busqueda = new Busqueda(palabraBusqueda, resultadosBusqueda.Count(), DateTime.Today, device);
                        db.Busquedas.Add(busqueda);
                    }
                    else
                    {
                        List<LocalComercial> resultadosBusquedaLocales = db.Locales.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                        if (resultadosBusquedaLocales.Count() > 0)
                        {
                            mostrarLista(resultadosBusquedaLocales, palabraBusqueda);

                            Busqueda busqueda = new Busqueda(palabraBusqueda, resultadosBusquedaLocales.Count(), DateTime.Today, device);
                            db.Busquedas.Add(busqueda);
                        }
                        else
                        {
                            List<Banco> resultadosBusquedaBancos = db.Bancos.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                            if (resultadosBusquedaBancos.Count() > 0)
                            {
                                mostrarLista(resultadosBusquedaBancos, palabraBusqueda);

                                Busqueda busqueda = new Busqueda(palabraBusqueda, resultadosBusquedaBancos.Count(), DateTime.Today, device);
                                db.Busquedas.Add(busqueda);
                            }
                            else
                            {
                                List<CGP> resultadosBusquedaCGP = db.CGPs.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                                if (resultadosBusquedaCGP.Count() > 0)
                                {
                                    mostrarLista(resultadosBusquedaCGP, palabraBusqueda);

                                    Busqueda busqueda = new Busqueda(palabraBusqueda, resultadosBusquedaCGP.Count(), DateTime.Today, device);
                                    db.Busquedas.Add(busqueda);
                                }
                            }
                        }
                        
                    }

                    db.SaveChanges();

                
                    return View();

                }
                catch
                {
                    return View();
                }
            }

        }

        public ActionResult Availability()
        {
            
            ViewBag.Message = "Buscá horarios de puntos de interés.";
            

            return View();
        }

        [HttpPost]
        public ActionResult Availability(FormCollection search)
        {

            ViewBag.Message = "Buscá horarios de puntos de interés.";

            //%%%%%%%%%%%%%%   DATOS HARDCODEADOS PARA SIMUAR DB

            // Genero lista de puntos
            List<Models.PuntoDeInteres> puntos = new List<Models.PuntoDeInteres>();

            // Agrego parada 114
            Models.ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", DbGeography.FromText("POINT(-34.659690 -58.468764)"));
            parada.palabraClave = "114";
            puntos.Add(parada);


            // Agrego librería ceit
            LocalComercial local = new LocalComercial("Librería CEIT", DbGeography.FromText("POINT(-34.659492 -58.467906)"), new Rubro("librería escolar", 5));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            local.horarioFeriado.Add(new HorarioAbierto(1, 1, 0, 0));
            local.horarioFeriado.Add(new HorarioAbierto(9, 7, 10, 16));
            puntos.Add(local);

            // Agrego CGP Lugano
            CGP CGP = new CGP("Sede Comunal 8", DbGeography.FromText("POINT(-34.6862397 -58.4606666)"), 50);
            ServicioCGP servicio = new ServicioCGP("Rentas");
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            CGP.servicios.Add(servicio);
            puntos.Add(CGP);

            // Agrego CGP Floresta
            CGP = new CGP("Sede Comunal 10", DbGeography.FromText("POINT(-34.6318411 -58.4857468)"), 10);
            servicio = new ServicioCGP("Registro Civil");
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 10, 16));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            CGP.servicios.Add(servicio);
            puntos.Add(CGP);


            // Agrego Banco provincia
            Banco banco = new Banco("Banco Provincia", DbGeography.FromText("POINT(-34.6571851 -58.4776738)"));
            ServicioBanco servicioBanco = new ServicioBanco("Depósitos");
            servicioBanco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicioBanco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicioBanco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicioBanco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicioBanco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicioBanco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            servicioBanco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            banco.servicios.Add(servicioBanco);
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            puntos.Add(banco);

            string searchWord = search["palabraClave"];
            DateTime searchTime = DateTime.ParseExact(search["selectedDate"], "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);

            //%%%%%%%%%%%%%%   FIN DE SIMULACION DE DATOS DE DB
            

                //Si la persona ingresó un número, asumo que busca una parada de bondi
                int linea = 0;
                if (int.TryParse(searchWord, out linea) && linea > 0)
                {

                //busco la parada en cuestión
                    List<Models.ParadaDeColectivo> paradas = puntos.OfType<Models.ParadaDeColectivo>().ToList();
                    Models.ParadaDeColectivo punto = paradas.Find(x => x.palabraClave == searchWord);

                    if (punto != null) { 
                        if (punto.estaDisponible(searchTime))
                        {
                            ViewBag.SearchText = "La línea " + punto.palabraClave + " está disponible en ese horario";
                            ViewBag.Search = "ok";

                            return View();

                        } else
                        {
                            ViewBag.SearchText = "La línea " + punto.palabraClave + " no está disponible en ese horario";
                            ViewBag.Search = "error";
                            return View();
                        }
                    } else
                    {
                        ViewBag.SearchText = "No tenemos información sobre una línea de colectivos con número " + searchWord;
                        ViewBag.Search = "error";
                        return View();
                    }


                    //Si la persona ingresó una palabra, me fijo si es un servicio
                }
                else
                {
                List<CGP> CGPs = puntos.OfType<CGP>().ToList();
                string availableServices = "";
                    // en cada CGP reviso si tienen un servicio que tenga la misma clave y esté disponible
                    foreach (CGP punto in CGPs) {
                    Servicio foundService = punto.servicios.Find(x => x.nombre.ToLower().Contains(searchWord.ToLower()) && x.estaDisponible(searchTime));
                        if (foundService != null) {
                            availableServices = availableServices + "El servicio " + foundService.nombre + " está disponible en ese horario en " + punto.palabraClave + ".\n";
                        }
                    }

                List<Banco> bancos = puntos.OfType<Banco>().ToList();
                foreach (Banco punto in bancos)
                {
                    Servicio foundService = punto.servicios.Find(x => x.nombre.ToLower().Contains(searchWord.ToLower()) && x.estaDisponible(searchTime));
                    if (foundService != null && punto.estaDisponible(searchTime))
                    {
                        availableServices = "El servicio " + foundService.nombre + " está disponible en ese horario en " + punto.palabraClave + ".\n";
                    }
                }

                List<LocalComercial> locales = puntos.OfType<LocalComercial>().ToList();
                foreach (LocalComercial punto in locales)
                {
                    if (punto.estaDisponible(searchTime) && punto.palabraClave.ToLower().Contains(searchWord.ToLower()))
                    {
                        availableServices = "El local " + punto.palabraClave + " está disponible en ese horario.\n";
                    }
                }

                if (availableServices != "") {
                        ViewBag.SearchText = availableServices;
                        ViewBag.Search = "ok";

                        return View();
                    } else {
                        ViewBag.SearchText = "Ese servicio o local no se encuentra disponible o no existe."; ;
                        ViewBag.Search = "error";

                        return View();
                    }
                    
                

            }
            
        }

        public ActionResult SearchReports()
        {
            List<Busqueda> busquedas;
            using (var db = new BuscAR())
            {
                busquedas = (from b in db.Busquedas
                            orderby b.Id
                            select b).ToList();
            }

            return View(busquedas);

        }
    }
}
