using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using TPDDSGrupo44.Models;
using TPDDSGrupo44.ViewModels;

namespace TPDDSGrupo44.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
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
                    DispositivoTactil dispositivoTactil = db.Terminales.Where(i => i.nombre == "UTN FRBA Lugano").Single();

                    //Si la persona ingresó un número, asumo que busca una parada de bondi
                    int linea = 0;
                    if (int.TryParse(palabraBusqueda, out linea) && linea > 0)
                    {

                        List<ParadaDeColectivo> resultadosBusqueda = db.Paradas.Where(b => b.palabraClave == palabraBusqueda).ToList();
                        foreach (ParadaDeColectivo punto in resultadosBusqueda)
                        {

                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.paradasEncontradas.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = "Parada del " + punto.palabraClave;

                                ViewBag.Search = "ok";
                                break;
                            }
                            else
                            {
                                modeloVista.puntosEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }

                        }

                    }

                    //Si la persona ingresó una palabra, me fijo si es un rubro
                    if (db.Rubros.Where(b => b.nombre.Contains(palabraBusqueda.ToLower())).ToList().Count() > 0)
                    {

                        List<LocalComercial> resultadosBusqueda = db.Locales.Where(b => b.rubro.nombre.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                        foreach (LocalComercial punto in resultadosBusqueda)
                        {
                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.puntosEncontradosCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.Search = "ok";
                                break;
                            }
                            else
                            {
                                modeloVista.puntosEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }
                        }

                        // Si la palabra ingresada no era parada ni rubro, la busco como local
                    }

                    List<LocalComercial> resultadosBusquedaLocales = db.Locales.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                    if (resultadosBusquedaLocales.Count() > 0)
                    {
                        foreach (LocalComercial punto in resultadosBusquedaLocales)
                        {
                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.puntosEncontradosCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = punto.palabraClave;
                                ViewBag.Search = "ok";
                                break;
                            }
                            else
                            {
                                modeloVista.puntosEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }
                        }
                    }

                    List<Banco> resultadosBusquedaBancos = db.Bancos.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                    if (resultadosBusquedaBancos.Count() > 0)
                    {
                        foreach (Banco punto in resultadosBusquedaBancos)
                        {
                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.puntosEncontradosCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = punto.palabraClave;
                                ViewBag.Search = "ok";
                                break;
                            }
                            else
                            {
                                modeloVista.puntosEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }
                        }
                    }
                    List<CGP> resultadosBusquedaCGP = db.CGPs.Where(b => b.palabraClave.ToLower().Contains(palabraBusqueda.ToLower())).ToList();
                    if (resultadosBusquedaCGP.Count() > 0)
                    {
                        foreach (CGP punto in resultadosBusquedaCGP)
                        {
                            if (punto.estaCerca(dispositivoTactil.coordenada))
                            {
                                modeloVista.puntosEncontradosCerca.Add(punto);
                                ViewBag.Latitud = punto.coordenada.Latitude.ToString();
                                ViewBag.Longitud = punto.coordenada.Longitude.ToString();
                                ViewBag.TextoLugar = punto.palabraClave;
                                ViewBag.Search = "ok";
                                break;
                            }
                            else
                            {
                                modeloVista.puntosEncontrados.Add(punto);
                                ViewBag.Search = "ok";
                            }
                        }
                    }

                    return View(modeloVista);
                }

            }
            catch
            {
                return View();
            }
        }
    }
}