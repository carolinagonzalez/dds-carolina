using System;
using System.Web.Mvc;
using System.Device.Location;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using TPDDSGrupo44.Models;

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
                    ViewBag.SearchText = ViewBag.SearchText + palabraBusqueda + "->" + punto.nombreDelPOI + ",";
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
                    ViewBag.SearchText = ViewBag.SearchText + palabraBusqueda + "->" + punto.nombreDelPOI + ",";
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
                    ViewBag.SearchText = ViewBag.SearchText + palabraBusqueda + "->" + punto.nombreDelPOI + ",";
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
            GeoCoordinate dispositivoTactil = new GeoCoordinate(-34.6597047, -58.4688947);
            ViewBag.Latitud = dispositivoTactil.Latitude.ToString(CultureInfo.InvariantCulture);
            ViewBag.Longitud = dispositivoTactil.Longitude.ToString(CultureInfo.InvariantCulture);
            ViewBag.TextoLugar = "¡Estás acá!";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection search)
        {

            ViewBag.Message = "Buscá puntos de interés, descubrí cuáles están cerca.";

            //%%%%%%%%%%%%%%   DATOS HARDCODEADOS PARA SIMUAR DB

            // Genero lista de POIs
            List<Models.PuntoDeInteres> puntos = new List<Models.PuntoDeInteres>();
            
            // Agrego parada 114
            ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", new GeoCoordinate(-34.659690, -58.468764));
            parada.palabraClave = "114";
            puntos.Add(parada);
            // Agrego Parada 36 - lejana
            parada = new Models.ParadaDeColectivo("Av Escalada 2680", new GeoCoordinate(-34.662325, -58.473300));
            parada.palabraClave = "36";
            puntos.Add(parada);



            // Genero lista de rubros
            List<Models.Rubro> rubros = new List<Models.Rubro>();

            //Agrego Librería escolar
            rubros.Add(new Models.Rubro("librería escolar", 5));
            //Agrego kiosco de diarios
            rubros.Add(new Models.Rubro("kiosco de diarios", 2));

            
            // Agrego librería ceit
            Models.LocalComercial local = new Models.LocalComercial("Librería CEIT", new GeoCoordinate(-34.659492, -58.467906), new Models.Rubro("librería escolar", 5));
            puntos.Add(local);

            // agrego puesto de diarios 
            local = new Models.LocalComercial("Kiosco Las Flores", new GeoCoordinate(-34.634015, -58.482805), new Models.Rubro("kiosco de diarios", 5));
            puntos.Add(local);

            // Agrego CGP Lugano
            CGP CGP = new CGP("Sede Comunal 8", new GeoCoordinate(-34.6862397, -58.4606666), 50);;
            puntos.Add(CGP);

            // Agrego CGP Floresta
            CGP = new CGP("Sede Comunal 10", new GeoCoordinate(-34.6318411, -58.4857468), 10);
            puntos.Add(CGP);

            // Agrego Banco Provincia
            Models.Banco banco = new Models.Banco("Banco Provincia", new GeoCoordinate(-34.660979, -58.469821));
            puntos.Add(banco);

            // Agrego Banco Francés
            banco = new Banco("Banco Francés", new GeoCoordinate(-34.6579153, -58.4791142));
            puntos.Add(banco);

            //Defino ubicación actual (UTN/CAMPUS)
            GeoCoordinate dispositivoTactil = new GeoCoordinate(-34.6597047, -58.4688947);
            ViewBag.Latitud = dispositivoTactil.Latitude;
            ViewBag.Longitud = dispositivoTactil.Longitude;
            ViewBag.TextoLugar = "¡Estás acá!";

            string palabraBusqueda = search["palabraClave"];


            //%%%%%%%%%%%%%%   FIN DE SIMULACION DE DATOS DE DB


            try
            {

                //Si la persona ingresó un número, asumo que busca una parada de bondi
                int linea = 0;
                if (int.TryParse(palabraBusqueda, out linea) && linea > 0) {

                    List<Models.ParadaDeColectivo> paradas = puntos.OfType<Models.ParadaDeColectivo>().ToList();
                    //recorro todas las paradas de la DB para buscar alguna cercana con la palabra clave ingresada
                    foreach (Models.ParadaDeColectivo punto in paradas) {
                        if (punto.estaCerca(dispositivoTactil) && punto.palabraClave == palabraBusqueda ) {
                            ViewBag.SearchText = "¡Hay una parada del " + punto.palabraClave + " cerca!";
                            ViewBag.Latitud = punto.coordenada.Latitude.ToString(CultureInfo.InvariantCulture); 
                            ViewBag.Longitud = punto.coordenada.Longitude.ToString(CultureInfo.InvariantCulture);
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
                else if (rubros.Find(x => x.nombreRubro.Contains(palabraBusqueda.ToLower())) != null) {

                    List<Models.LocalComercial> locales = puntos.OfType<Models.LocalComercial>().ToList();

                    foreach (Models.LocalComercial punto in locales)
                    {
                        if (punto.estaCerca(dispositivoTactil) && punto.rubro.nombreRubro.ToLower().Contains(palabraBusqueda.ToLower()))
                        {
                            ViewBag.SearchText = "¡Hay una local de ese rubro cerca! Visite " + punto.nombreDelPOI;
                            ViewBag.Latitud = punto.coordenada.Latitude.ToString(CultureInfo.InvariantCulture);
                            ViewBag.Longitud = punto.coordenada.Longitude.ToString(CultureInfo.InvariantCulture);
                            ViewBag.TextoLugar = punto.nombreDelPOI;
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
                    Models.PuntoDeInteres punto = puntos.Find(x => x.nombreDelPOI.ToLower().Contains(palabraBusqueda.ToLower()));
                    if (punto != null && punto.estaCerca(dispositivoTactil))
                    {
                        ViewBag.SearchText = "¡Punto encontrado! Visite " + punto.nombreDelPOI;
                        ViewBag.Latitud = punto.coordenada.Latitude.ToString(CultureInfo.InvariantCulture);
                        ViewBag.Longitud = punto.coordenada.Longitude.ToString(CultureInfo.InvariantCulture);
                        ViewBag.TextoLugar = punto.nombreDelPOI;
                        ViewBag.Search = "ok";
                    } else
                    {
                        ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                        ViewBag.Search = "error";
                    }
                    
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Location(FormCollection search)
        {
            ViewBag.Message = "Buscá puntos de interés específicos.";
            //%%%%%%%%%%%%%%   DATOS HARDCODEADOS PARA SIMUAR DB

            // Genero lista de POIs
            List<PuntoDeInteres> puntos = new List<PuntoDeInteres>();

            // Agrego parada 114
            ParadaDeColectivo parada = new ParadaDeColectivo("Monroe 2979", new GeoCoordinate(-34.659690, -58.468764));
            parada.palabraClave = "114";
            puntos.Add(parada);
            // Agrego Parada 114 - lejana
            parada = new ParadaDeColectivo("Mozart 2389", new GeoCoordinate(-34.659690, -58.468764));
            parada.palabraClave = "114";
            puntos.Add(parada);

            // Genero lista de rubros
            List<Models.Rubro> rubros = new List<Models.Rubro>();

            //Agrego Librería escolar
            rubros.Add(new Models.Rubro("librería escolar", 5));
            //Agrego kiosco de diarios
            rubros.Add(new Models.Rubro("kiosco de diarios", 2));

            // Agrego librería ceit
            Models.LocalComercial local = new Models.LocalComercial("Librería CEIT", new GeoCoordinate(-34.659492, -58.467906), new Models.Rubro("librería escolar", 5));
            puntos.Add(local);

            // agrego puesto de diarios 
            local = new Models.LocalComercial("Kiosco Las Flores", new GeoCoordinate(-34.634015, -58.482805), new Models.Rubro("kiosco de diarios", 5));
            puntos.Add(local);

            // agrego puesto de diarios 
            local = new Models.LocalComercial("Kiosco El enano", new GeoCoordinate(-34.634015, -59.482805), new Models.Rubro("kiosco de diarios", 5));
            puntos.Add(local);

            // Agrego CGP Lugano
            CGP CGP = new CGP("Sede Comunal 8", new GeoCoordinate(-34.6862397, -58.4606666), 50); ;
            puntos.Add(CGP);

            // Agrego CGP Floresta
            CGP = new CGP("Sede Comunal 10", new GeoCoordinate(-34.6318411, -58.4857468), 10);
            puntos.Add(CGP);

            // Agrego Banco Provincia
            Models.Banco banco = new Models.Banco("Banco Provincia", new GeoCoordinate(-34.660979, -58.469821));
            puntos.Add(banco);

            // Agrego Banco Francés
            banco = new Banco("Banco Francés", new GeoCoordinate(-34.6579153, -58.4791142));
            puntos.Add(banco);

            string palabraBusqueda = search["palabraClave"];
            DispositivoTactil device = new DispositivoTactil("UTN Campus", new GeoCoordinate(-34.6597047, -58.4688947));
            //%%%%%%%%%%%%%%   FIN DE SIMULACION DE DATOS DE DB



            try
            {
                int linea = 0;

                using (var db = new BuscAR())
                {
                    if (int.TryParse(palabraBusqueda, out linea) && linea > 0)
                    {
                        List<ParadaDeColectivo> paradas = puntos.OfType<ParadaDeColectivo>().ToList();

                        List<ParadaDeColectivo> puntosFiltrados = paradas.Where(x => x.palabraClave == palabraBusqueda).ToList();
                        mostrarLista(puntosFiltrados, palabraBusqueda);

                        Busqueda busqueda = new Busqueda(palabraBusqueda, puntosFiltrados.Count(), DateTime.Today, device);
                        db.Busquedas.Add(busqueda);
                    }
                    else if (rubros.Find(x => x.nombreRubro.Contains(palabraBusqueda.ToLower())) != null)
                    {
                        List<LocalComercial> locales = puntos.OfType<LocalComercial>().ToList();
                        List<LocalComercial> puntosFiltrados = locales.Where(x => x.rubro.nombreRubro.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                        mostrarLista(puntosFiltrados, palabraBusqueda);

                        Busqueda busqueda = new Busqueda(palabraBusqueda, puntosFiltrados.Count(), DateTime.Today, device);
                        db.Busquedas.Add(busqueda);
                    }
                    else
                    {
                        List<PuntoDeInteres> puntosFiltrados = puntos.Where(x => x.nombreDelPOI.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                        mostrarLista(puntosFiltrados, palabraBusqueda);

                        Busqueda busqueda = new Busqueda(palabraBusqueda, puntosFiltrados.Count(), DateTime.Today, device);
                        db.Busquedas.Add(busqueda);
                    }

                    db.SaveChanges();

                }
                
                    return View();

            }
            catch
            {
                return View();
            }

        }

        public ActionResult Availability()
        {
            
            ViewBag.Message = "Buscá horarios de puntos de interés.";

            //Defino ubicación actual (UTN/CAMPUS)
            GeoCoordinate dispositivoTactil = new GeoCoordinate(-34.6597047, -58.4688947);
            ViewBag.Latitude = dispositivoTactil.Latitude.ToString(CultureInfo.InvariantCulture);
            ViewBag.Longitude = dispositivoTactil.Longitude.ToString(CultureInfo.InvariantCulture);
            ViewBag.LocationText = "¡Estás acá!";

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
            Models.ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", new GeoCoordinate(-34.659690, -58.468764));
            parada.palabraClave = "114";
            puntos.Add(parada);
            

            // Agrego librería ceit
            Models.LocalComercial local = new Models.LocalComercial("Librería CEIT", new GeoCoordinate(-34.659492, -58.467906), new Models.Rubro("librería escolar", 5));
            local.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Monday, 8, 21));
            local.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Tuesday, 8, 21));
            local.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Wednesday, 8, 21));
            local.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Thursday, 8, 21));
            local.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Friday, 8, 21));
            local.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Saturday, 8, 21));
            local.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            local.horarioFeriados.Add(new Models.HorarioAbierto(1, 1, 0, 0));
            local.horarioFeriados.Add(new Models.HorarioAbierto(9, 7, 10, 16));
            puntos.Add(local);

            // Agrego CGP Lugano
            CGP CGP = new CGP("Sede Comunal 8", new GeoCoordinate(-34.6862397, -58.4606666), 50);
            Models.Servicio servicio = new Models.Servicio("Rentas");
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            CGP.servicios.Add(servicio);
            puntos.Add(CGP);

            // Agrego CGP Floresta
            CGP = new CGP("Sede Comunal 10", new GeoCoordinate(-34.6318411, -58.4857468), 10);
            servicio = new Models.Servicio("Registro Civil");
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Saturday, 10, 16));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            CGP.servicios.Add(servicio);
            puntos.Add(CGP);

            
            // Agrego Banco provincia
            Models.Banco banco = new Models.Banco("Banco Provincia", new GeoCoordinate(-34.6571851, -58.4776738));
            servicio = new Models.Servicio("Depósitos");
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            servicio.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            banco.servicios.Add(servicio);
            banco.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Monday, 10, 15));
            banco.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Tuesday, 10, 15));
            banco.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Wednesday, 10, 15));
            banco.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Thursday, 10, 15));
            banco.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Friday, 10, 15));
            banco.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            banco.horarioAbierto.Add(new Models.HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
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
                        Models.Servicio foundService = punto.servicios.Find(x => x.nombre.ToLower().Contains(searchWord.ToLower()) && x.estaDisponible(searchTime));
                        if (foundService != null) {
                            availableServices = availableServices + "El servicio " + foundService.nombre + " está disponible en ese horario en " + punto.nombreDelPOI + ".\n";
                        }
                    }

                List<Models.Banco> bancos = puntos.OfType<Models.Banco>().ToList();
                foreach (Models.Banco punto in bancos)
                {
                    Models.Servicio foundService = punto.servicios.Find(x => x.nombre.ToLower().Contains(searchWord.ToLower()) && x.estaDisponible(searchTime));
                    if (foundService != null && punto.estaDisponible(searchTime))
                    {
                        availableServices = "El servicio " + foundService.nombre + " está disponible en ese horario en " + punto.nombreDelPOI + ".\n";
                    }
                }

                List<Models.LocalComercial> locales = puntos.OfType<Models.LocalComercial>().ToList();
                foreach (Models.LocalComercial punto in locales)
                {
                    if (punto.estaDisponible(searchTime) && punto.palabraClave.ToLower().Contains(searchWord.ToLower()))
                    {
                        availableServices = "El local " + punto.nombreDelPOI + " está disponible en ese horario.\n";
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
