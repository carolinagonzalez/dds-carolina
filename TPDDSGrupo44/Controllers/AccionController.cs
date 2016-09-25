using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using TPDDSGrupo44.Models;

namespace TPDDSGrupo44.Controllers
{
    public class AccionController : Controller
    {
        // GET: Accion
        public ActionResult Index()
        {
            using (BuscAR db = new BuscAR())
            {
                return View(db.configuracionDeAcciones.ToList());

            }
        }


        public ActionResult Configurar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Configurar(ConfiguracionDeAcciones accion)
        {
            if (ModelState.IsValid)
            {
                using (BuscAR db = new BuscAR())
                {
                    db.configuracionDeAcciones.Add(accion);
                    db.SaveChanges();
                }

                ModelState.Clear();

                ViewBag.Message = accion.nombreAccion + "Fue configurada correctamente";
            }
            return View();
        }

    }
}