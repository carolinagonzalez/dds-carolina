using System.Web.Mvc;
using System.Device.Location;
using System.Collections.Generic;

namespace TPDDSGrupo44.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Buscá puntos de interés, descubrí cuáles están cerca.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {

            ViewBag.Message = "Buscá puntos de interés, descubrí cuáles están cerca.";

            //%%%%%%%%%%%%%%   DATOS HARDCODEADOS PARA SIMUAR DB

            // Genero lista de paradas
            List<Models.ParadaDeColectivo> paradas = new List<Models.ParadaDeColectivo>();

            // Agrego parada 114
            Models.ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", new GeoCoordinate(-34.659690, -58.468764));
            parada.palabraClave = "114";
            paradas.Add(parada);
            // Agrego Parada 36 - lejana
            parada = new Models.ParadaDeColectivo("Av Escalada 2680", new GeoCoordinate(-34.662325, -58.473300));
            parada.palabraClave = "36";
            paradas.Add(parada);


            // Genero lista de rubros
            List<Models.Rubro> rubros = new List<Models.Rubro>();

            //Agrego Librería escolar
            rubros.Add(new Models.Rubro("librería escolar", 5));
            //Agrego kiosco de diarios
            rubros.Add(new Models.Rubro("kiosco de diarios", 2));


            // Genero lista de locales
            List<Models.LocalComercial> locales = new List<Models.LocalComercial>();

            // Agrego librería ceit
            Models.LocalComercial local = new Models.LocalComercial("Librería CEIT", new GeoCoordinate(-34.659492, -58.467906), new Models.Rubro("librería escolar", 5));
            locales.Add(local);

            // agrego puesto de diarios 
            local = new Models.LocalComercial("Kiosco Las Flores", new GeoCoordinate(-34.634015, -58.482805), new Models.Rubro("kiosco de diarios", 5));
            locales.Add(local);


            // Genero lista de CGPs
            List<Models.CGP> CGPs = new List<Models.CGP>();

            // Agrego CGP Lugano
            Models.CGP CGP = new Models.CGP("Sede Comunal 8", new GeoCoordinate(-34.6862397, -58.4606666), 8);
            CGPs.Add(CGP);

            // Agrego CGP Floresta
            CGP = new Models.CGP("Sede Comunal 10", new GeoCoordinate(-34.6318411, -58.4857468), 10);
            CGPs.Add(CGP);


            //Defino ubicación actual (UTN/CAMPUS)
            GeoCoordinate dispositivoTactil = new GeoCoordinate(-34.6597047, -58.4688947);

            string palabraBusqueda = collection["palabraClave"];

            //%%%%%%%%%%%%%%   FIN DE SIMULACION DE DATOS DE DB


            try
            {

                //Si la persona ingresó un número, asumo que busca una parada de bondi
                int linea = 0;
                if (int.TryParse(palabraBusqueda, out linea) && linea > 0) { 

                    //recorro todas las paradas de la DB para buscar alguna cercana con la palabra clave ingresada
                    foreach (Models.ParadaDeColectivo punto in paradas) {
                        if (punto.estaCerca(dispositivoTactil) && punto.palabraClave == palabraBusqueda ) {
                            ViewBag.SearchText = "¡Hay una parada del " + punto.palabraClave + " cerca!";
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

                    foreach (Models.LocalComercial punto in locales)
                    {
                        if (punto.estaCerca(dispositivoTactil) && punto.rubro.nombreRubro.Contains(palabraBusqueda.ToLower()))
                        {
                            ViewBag.SearchText = "¡Hay una local de ese rubro cerca! Visite " + punto.nombreDelPOI;
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
                } else if (locales.Find(x => x.nombreDelPOI.ToLower().Contains(palabraBusqueda.ToLower())) != null)
                {

                    Models.LocalComercial punto = locales.Find(x => x.nombreDelPOI.ToLower().Contains(palabraBusqueda.ToLower()));

                    if (punto.estaCerca(dispositivoTactil))
                    {
                        ViewBag.SearchText = "¡Un local cerca tiene ese nombre! Visite " + punto.nombreDelPOI;
                        ViewBag.Search = "ok";
                    }
                    else
                    {
                        ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                        ViewBag.Search = "error";
                    }
                    // Si la palabra ingresada no era parada ni rubro ni local, la busco como CGP
                }
                else if (CGPs.Find(x => x.nombreDelPOI.ToLower().Contains(palabraBusqueda.ToLower())) != null)
                {

                    Models.CGP punto = CGPs.Find(x => x.nombreDelPOI.ToLower().Contains(palabraBusqueda.ToLower()));

                    if (punto.estaCerca(dispositivoTactil))
                    {
                        ViewBag.SearchText = "Hay un CGP cercano. Visite " + punto.nombreDelPOI;
                        ViewBag.Search = "ok";
                    }
                    else
                    {
                        ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                        ViewBag.Search = "error";
                    }
                }
                else
                {
                    ViewBag.SearchText = "No encontramos ningún punto de interés con esa clave en las cercanías.";
                    ViewBag.Search = "error";
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Punto()
        {
            ViewBag.Message = "Buscá puntos de interés específicos.";

            return View();
        }

        public ActionResult Horarios()
        {
            
            ViewBag.Message = "Buscá horarios de puntos de interés.";
            return View();
        }
    }
}
