using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

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
            try
            {
                Models.ParadaDeColectivo punto = new Models.ParadaDeColectivo();

                punto.palabraClave = collection["palabraClave"];

                if ( punto.valida(punto.palabraClave) )
                {
                    ViewBag.Search = "Punto encontrado";
                    return View();
                }
                else
                {
                    ViewBag.Search = "Punto no encontrado";
                    return View();
                }
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
