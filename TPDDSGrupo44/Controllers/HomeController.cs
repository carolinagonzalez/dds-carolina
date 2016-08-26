using System;
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
                ViewBag.SearchText = new string[listaFiltrada.Count()];
                for (var i = 0; i < listaFiltrada.Count(); i++)
                {
                    ViewBag.SearchText[i] = listaFiltrada[i].palabraClave + " (" + listaFiltrada[i].calle + " " + listaFiltrada[i].numeroAltura + ")";
                }
                ViewBag.Search = "ok";
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
                ViewBag.SearchText = new string[listaFiltrada.Count()];
                for (var i = 0; i < listaFiltrada.Count(); i++)
                {
                    ViewBag.SearchText[i] = listaFiltrada[i].palabraClave + " (" + listaFiltrada[i].calle + " " + listaFiltrada[i].numeroAltura + ")";
                }
                ViewBag.Search = "ok";
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
                ViewBag.SearchText = new string[listaFiltrada.Count()];
                for (var i = 0; i < listaFiltrada.Count(); i++)
                {
                    ViewBag.SearchText[i] = listaFiltrada[i].palabraClave + " (" + listaFiltrada[i].calle + " " + listaFiltrada[i].numeroAltura + ")";
                }
                ViewBag.Search = "ok";
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
                ViewBag.SearchText = new string[listaFiltrada.Count()];
                for (var i = 0; i < listaFiltrada.Count(); i++)
                {
                    ViewBag.SearchText[i] = listaFiltrada[i].palabraClave + " (" + listaFiltrada[i].calle + " " + listaFiltrada[i].numeroAltura + ")";
                }
                ViewBag.Search = "ok";
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
                ViewBag.SearchText = new string[listaFiltrada.Count()];
                for (var i = 0; i < listaFiltrada.Count(); i++)
                {
                    ViewBag.SearchText[i] = listaFiltrada[i].palabraClave + " (" + listaFiltrada[i].calle + " " + listaFiltrada[i].numeroAltura + ")";
                }
                ViewBag.Search = "ok";
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
            ViewBag.SearchText = new string[0];
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


            string searchWord = search["palabraClave"];
            DateTime searchTime = DateTime.ParseExact(search["selectedDate"], "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);

            //%%%%%%%%%%%%%%   FIN DE SIMULACION DE DATOS DE DB

            using (var db = new BuscAR())
            {
                //Si la persona ingresó un número, asumo que busca una parada de bondi
                int linea = 0;
                if (int.TryParse(searchWord, out linea) && linea > 0)
                {

                    //busco la parada en cuestión
                    ParadaDeColectivo punto = db.Paradas.Where(b => b.palabraClave == searchWord).FirstOrDefault();

                    if (punto != null)
                    {
                        if (punto.estaDisponible(searchTime))
                        {
                            ViewBag.SearchText = "La línea " + punto.palabraClave + " está disponible en ese horario";
                            ViewBag.Search = "ok";

                            return View();

                        }
                        else
                        {
                            ViewBag.SearchText = "La línea " + punto.palabraClave + " no está disponible en ese horario";
                            ViewBag.Search = "error";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.SearchText = "No tenemos información sobre una línea de colectivos con número " + searchWord;
                        ViewBag.Search = "error";
                        return View();
                    }


                    //Si la persona ingresó una palabra, me fijo si es un servicio
                }
                else
                {
                    string availableServices = "";
                    // en cada CGP reviso si tienen un servicio que tenga la misma clave y esté disponible
                    List<CGP> foundCGP = db.CGPs.Include("servicios").Include("servicios.horarioAbierto").Include("servicios.horarioFeriados").Where(x => x.servicios.ToList().Count() > 0).ToList();

                    foreach (CGP punto in foundCGP)
                    {
                        List<ServicioCGP> serviciosDelPunto = punto.servicios.ToList();
                        ServicioCGP foundService = serviciosDelPunto.Where(x => x.nombre.ToLower().Contains(searchWord.ToLower()) && x.estaDisponible(searchTime)).FirstOrDefault();
                        if (foundService != null)
                        {
                            availableServices = availableServices + "El servicio " + foundService.nombre + " está disponible en ese horario en " + punto.palabraClave + ".\n";
                        }
                    }


                    foreach (Banco punto in db.Bancos.ToList())
                    {
                        ServicioBanco foundService = punto.servicios.Find(x => x.nombre.ToLower().Contains(searchWord.ToLower()) && x.estaDisponible(searchTime));
                        if (foundService != null && punto.estaDisponible(searchTime))
                        {
                            availableServices = "El servicio " + foundService.nombre + " está disponible en ese horario en " + punto.palabraClave + ".\n";
                        }
                    }
                    
                    foreach (LocalComercial punto in db.Locales.ToList())
                    {
                        if (punto.estaDisponible(searchTime) && punto.palabraClave.ToLower().Contains(searchWord.ToLower()))
                        {
                            availableServices = "El local " + punto.palabraClave + " está disponible en ese horario.\n";
                        }
                    }

                    if (availableServices != "")
                    {
                        ViewBag.SearchText = availableServices;
                        ViewBag.Search = "ok";

                        return View();
                    }
                    else
                    {
                        ViewBag.SearchText = "Ese servicio o local no se encuentra disponible o no existe."; ;
                        ViewBag.Search = "error";

                        return View();
                    }


                }
            }
            
        }
    }
}
