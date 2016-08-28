using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using TPDDSGrupo44.Models;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View(recuperarBusquedas());
        }

        public ActionResult SearchPerDay()
        {

            return View(recuperarBusquedas());
        }


        public ActionResult ResultsPerSearch()
        {
            return View(recuperarBusquedas());
        }


        private List<Busqueda> recuperarBusquedas()
        {
            List<Busqueda> busquedas;
            using (var db = new BuscAR())
            {
                busquedas = (from b in db.Busquedas
                             orderby b.Id
                             select b).ToList();
            }

            return busquedas;
        }


        public ActionResult CreateParada()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult CreateParada(FormCollection collection)
        {
            try
            {

                Console.Write(collection["coordenada.Latitude"]);
                DbGeography coordenada = DbGeography.FromText("POINT(" + collection["coordenada.Latitude"] + " " + collection["coordenada.Longitude"] + ")");

                ParadaDeColectivo parada = new ParadaDeColectivo(coordenada, collection["calle"], Convert.ToInt32(collection["numeroAltura"]),
                    Convert.ToInt32(collection["piso"]), Convert.ToInt32(collection["unidad"]), Convert.ToInt32(collection["codigoPostal"]),
                    collection["localidad"], collection["barrio"], collection["provincia"], collection["pais"], collection["entreCalles"],
                    collection["palabraClave"], collection["tipoDePOI"]);

                parada.agregarParada(parada);

                return RedirectToAction("CreateParada");
            }
            catch
            {
                return View();
            }
        }
    }
}