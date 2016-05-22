using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

            //DATOS HARDCODEADOS PARA SIMUAR DB
            List<Models.ParadaDeColectivo> paradas = new List<Models.ParadaDeColectivo>();

            // Agrego parada 114 - cercana
            Models.ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", new Models.Coordenada(-34.659690, -58.468764), new Models.ConsultoCercania());
            parada.palabraClave = "114";
            paradas.Add(parada);

            // Agrego Parada 36 - lejana
            parada = new Models.ParadaDeColectivo("Av Escalada 2680", new Models.Coordenada(-34.662325, -58.473300), new Models.ConsultoCercania());
            parada.palabraClave = "36";
            paradas.Add(parada);

            //Defino ubicación actual
            Models.Coordenada dispositivoTactil = new Models.Coordenada(-34.6597047, -58.4688947);

            //FIN DE SIMULACION DE DATOS DE DB


            try
            {

                foreach (Models.ParadaDeColectivo punto in paradas) // Loop through List with foreach.
                {
                    if (punto.estaCerca(dispositivoTactil) && punto.palabraClave == collection["palabraClave"] )
                    {
                        ViewBag.SearchText = "¡Punto cercano!";
                        ViewBag.Search = "ok";
                        break;
                    }
                    else
                    {
                        ViewBag.SearchText = "Punto lejano o desconocido.";
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
