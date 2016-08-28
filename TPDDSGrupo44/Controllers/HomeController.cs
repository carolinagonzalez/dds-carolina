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
