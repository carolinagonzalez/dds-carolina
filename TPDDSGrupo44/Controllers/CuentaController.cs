using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPDDSGrupo44.Models;
//using MvcLoginRegistration.Models;

namespace TPDDSGrupo44.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public Action Registrar(CuentaDeUsuario cuenta)
        {
            if (ModelState.IsValid)
            {
                using (POIDbContext db = new POIDbContext())
                {
                    db.cuentaDeUsuario.Add(cuenta);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = cuenta.Nombre + " " + cuenta.Apellido + "Usuario Registrado Correctamente.";
            }
            return ViewBag.Message;
        }             
    }
}