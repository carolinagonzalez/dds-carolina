using System.Web.Mvc;
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

            //%%%%%%%%%%%%%%   DATOS HARDCODEADOS PARA SIMUAR DB

            // Genero lista de paradas
            List<Models.ParadaDeColectivo> paradas = new List<Models.ParadaDeColectivo>();

            // Agrego parada 114
            Models.ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", new Models.Coordenada(-34.659690, -58.468764), new Models.ConsultoCercania());
            parada.palabraClave = "114";
            paradas.Add(parada);
            // Agrego Parada 36 - lejana
            parada = new Models.ParadaDeColectivo("Av Escalada 2680", new Models.Coordenada(-34.662325, -58.473300), new Models.ConsultoCercania());
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
            Models.LocalComercial local = new Models.LocalComercial("Librería CEIT", new Models.Coordenada(-34.659492, -58.467906), new Models.ConsultoCercania(), new Models.Rubro("librería escolar", 5));
            locales.Add(local);

            // agrego puesto de diarios 
            local = new Models.LocalComercial("Kiosco Las Flores", new Models.Coordenada(-34.634015, -58.482805), new Models.ConsultoCercania(), new Models.Rubro("kiosco de diarios", 5));
            locales.Add(local);


            //Defino ubicación actual
            Models.Coordenada dispositivoTactil = new Models.Coordenada(-34.6597047, -58.4688947);

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
                            ViewBag.SearchText = "¡Hay una parada cerca!";
                            ViewBag.Search = "ok";
                           break;
                        }
                        else
                        {
                            ViewBag.SearchText = "No hay una parada de esa línea cerca.";
                            ViewBag.Search = "error";
                        }
                    }


                    //Si la persona ingresó una palabra, me fijo si es un rubro
                }
                else if (rubros.Find(x => x.nombreRubro.Contains(palabraBusqueda.ToLower())) != null) {

                    foreach (Models.LocalComercial punto in locales)
                    {
                        if (punto.estaCerca(dispositivoTactil) && punto.rubro.nombreRubro == palabraBusqueda)
                        {
                            ViewBag.SearchText = "¡Hay una local de ese rubro cerca! Visite " + punto.nombreDelPOI;
                            ViewBag.Search = "ok";
                            break;
                        } else
                        {
                            ViewBag.SearchText = "No hay una local de ese rubro cerca.";
                            ViewBag.Search = "error";
                        }
                    }

                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Buscá horarios de puntos de interés.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Buscá puntos de interés específicos.";

            return View();
        }
    }
}
