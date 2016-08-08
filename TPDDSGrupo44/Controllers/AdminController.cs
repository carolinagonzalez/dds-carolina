using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TPDDSGrupo44.Models;

namespace TPDDSGrupo44.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
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