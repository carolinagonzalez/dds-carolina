using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using TPDDSGrupo44.Models;
using System.Data.Entity.Spatial;
using TPDDSGrupo44.ViewModels;
using System.Data.Entity;

namespace TPDDSGrupo44.Controllers
{
    public class HomeController : Controller
    {
        List<PuntoDeInteres> resultados = new List<PuntoDeInteres>();
        public ActionResult Index()
        {
            return View();

        }


        //Configuracion de acciones

        public ActionResult AccionList()
        {
            IQueryable acciones = Acciones.GetAcciones();

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(
                            acciones,
                            "AccionID",
                            "AccionNombre"), JsonRequestBehavior.AllowGet
                             );
            }
            return View(acciones);
        }



        [HttpPost]
        public ActionResult Index(FormCollection search)
        {

            ViewBag.Message = "Buscá puntos de interés, descubrí cuáles están cerca.";


            string palabraBusqueda = search["palabraClave"];

            try
            {
                using (var db = new BuscAR())
                {

                    SearchViewModel modeloVista = new SearchViewModel();

                    //Defino ubicación actual (UTN/CAMPUS)
                    DispositivoTactil dispositivoTactil = db.DispositivoTactiles.Where(i => i.nombre == "UTN FRBA Lugano").Single();

                    //Si la persona ingresó un número, asumo que busca una parada de bondi
                    int linea = 0;
                    if (int.TryParse(palabraBusqueda, out linea) && linea > 0)
                    {

                        List<ParadaDeColectivo> resultadosBusqueda = db.puntosInteres.OfType<ParadaDeColectivo>().Where(b => b.nombreDePOI == palabraBusqueda).ToList();
                        
                        foreach (ParadaDeColectivo punto in resultadosBusqueda)
                        {

                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.paradasEncontradasCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = "Parada del " + punto.nombreDePOI;

                                ViewBag.Search = "ok";
                            }
                            else
                            {
                                modeloVista.paradasEncontradas.Add(punto);
                                ViewBag.Search = "ok";
                            }

                        }

                    }

                    //Si la persona ingresó una palabra, me fijo si es un rubro
                    if (db.Rubros.Where(b => b.nombre.Contains(palabraBusqueda.ToLower())).ToList().Count() > 0)
                    {
                        List<LocalComercial> resultadosBusqueda = db.puntosInteres.OfType<LocalComercial>().Include("horarioAbierto").Include("horarioFeriado").ToList().Where(b => b.rubro.nombre.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                        resultados.AddRange(resultadosBusqueda);

                        foreach (LocalComercial punto in resultadosBusqueda)
                        {
                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.localesEncontradosCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Search = "ok";
                            }
                            else
                            {
                                modeloVista.localesEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }
                        }

                        // Si la palabra ingresada no era parada ni rubro, la busco como local
                    }

                    
                    List<LocalComercial> resultadosBusquedaLocales = db.puntosInteres.OfType<LocalComercial>().Include("horarioAbierto").Include("horarioFeriado").Include("rubro").Where(b => b.nombreDePOI.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                    if (resultadosBusquedaLocales.Count() > 0)
                    {
                        resultados.AddRange(resultadosBusquedaLocales);
                        foreach (LocalComercial punto in resultadosBusquedaLocales)
                        {
                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.localesEncontradosCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = punto.nombreDePOI;
                                ViewBag.Search = "ok";
                            } 
                            else
                            {
                                modeloVista.localesEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }
                        }
                    }

                    List<Banco> resultadosBusquedaBancos = db.puntosInteres.OfType<Banco>().Include("horarioAbierto").Include("horarioFeriado").Include("servicios").Include("servicios.horarioAbierto").Include("servicios.horarioFeriados").Where(b => b.nombreDePOI.ToLower().Contains(palabraBusqueda.ToLower())).ToList();

                    GetJsonBanks buscadorDeBancosJSON = new GetJsonBanks();
                    List<Banco> resultadoBusquedaJSONBancos = buscadorDeBancosJSON.getJsonData().FindAll(b => b.nombreDePOI.ToLower().Contains(palabraBusqueda.ToLower()));
                    resultadosBusquedaBancos.AddRange(resultadoBusquedaJSONBancos);

                    if (resultadosBusquedaBancos.Count() > 0)
                    {
                        
                        resultados.AddRange(resultadosBusquedaBancos);
                        foreach (Banco punto in resultadosBusquedaBancos)
                        {
                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.bancosEncontradosCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = punto.nombreDePOI;
                                ViewBag.Search = "ok";
                            }
                            else
                            {
                                modeloVista.bancosEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }
                        }
                    }



                    List<CGP> resultadosBusquedaCGP = db.puntosInteres.OfType<CGP>().Include("horarioAbierto").Include("horarioFeriado").Include("servicios").Include("servicios.horarioAbierto").Include("servicios.horarioFeriados").Where(b => b.nombreDePOI.ToLower().Contains(palabraBusqueda.ToLower())).Cast<CGP>().ToList();

                 /*   GetJsonCGP buscadorDeCGPJSON = new GetJsonCGP();
                    List<Banco> resultadoBusquedaJSONCGP = buscadorDeCGPJSON.getJsonData().FindAll(b => b.nombreDePOI.ToLower().Contains(palabraBusqueda.ToLower()));
                    resultadoBusquedaJSONCGP.AddRange(resultadoBusquedaJSONCGP);*/


                    if (resultadosBusquedaCGP.Count() > 0)
                    {
                        resultados.AddRange(resultadosBusquedaCGP);
                        foreach (CGP punto in resultadosBusquedaCGP)
                        {
                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.cgpsEncontradosCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = punto.nombreDePOI;
                                ViewBag.Search = "ok";
                            }
                            else
                            {
                                modeloVista.cgpsEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }
                        }
                    }

                     
                    if (resultados.Count == 0)
                    {
                        ViewBag.Search = "error";
                        ViewBag.SearchText = "Disculpa, pero no encontramos ningún punto con esa palabra clave.";

                    }
                    else
                    {
                        Busqueda busqueda = new Busqueda(palabraBusqueda, resultados, DateTime.Today);
                        db.Busquedas.Add(busqueda);
                        db.SaveChanges();
                    }

                    return View(modeloVista);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }
    }
}
