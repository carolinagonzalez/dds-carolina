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
            using (BuscAR db = new BuscAR())
            {
                return View(db.Usuarios.ToList());
            }
            
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario cuenta)
        {
            if (ModelState.IsValid)
            {

                Session["IdUsuario"] = cuenta.id.ToString();
                Session["Email"] = cuenta.email.ToString();
                return RedirectToAction("Login");
                /* using (BuscAR db = new BuscAR())
                  {
                      db.cuentaDeUsuario.Add(cuenta);
                      db.SaveChanges();
                  }
                  ModelState.Clear();
                  ViewBag.Message = cuenta.Nombre + " " + cuenta.Apellido + "Usuario Registrado Correctamente.";*/
            }
            return View();
        }


        /* Login */

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Terminal usuario)
        {
            using (BuscAR db = new BuscAR())
            {
                //var usu = db.cuentaDeUsuario.Single(us => us.Dni == usuario.Dni && us.Contrasenia == usuario.Contrasenia);
                var usu = usuario;

                if (usu != null)
                {
                    Session["IdUsuario"] = usu.id.ToString();
                    Session["EMAIl"] = usu.email.ToString();
                    return RedirectToAction("Logueado");
                }
                else
                {
                    ModelState.AddModelError("","El Usuario o Contraseña son incorrectos");
                }
               
            }
            return View();


        }

        public ActionResult Logueado()
        {
            if (Session["IdUsuario"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}