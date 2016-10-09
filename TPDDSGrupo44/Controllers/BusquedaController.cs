using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TPDDSGrupo44.Models;

namespace TPDDSGrupo44.Controllers
{
    public class BusquedaController : ApiController
    {

        public static List<PuntoDeInteres> puntosDeInteres = new List<PuntoDeInteres>(){
            new PuntoDeInteres { id=1, nombreDePOI =  "Victoria Impala", calle = "Fco. de Beiró 4801"},
            new PuntoDeInteres { id=2, nombreDePOI = "J Perez Cotillón", calle = "Av. Alvarez Jonte  5232 1º" },
            new PuntoDeInteres { id=3, nombreDePOI = "CGP 6", calle = "Patricias Argentinas 277" }
        };
 

        Busqueda[] busquedas = new Busqueda[] {
            new Busqueda {  fecha = DateTime.Parse("2015-06-10T07:34:42-5:00"), usuario = new UsuarioTramite("JPerez"), textoBuscado = "texto buscado 1",  poisEncontrados = puntosDeInteres},
            new Busqueda {  fecha = DateTime.Parse("2015-06-10T07:34:42-5:00"), usuario = new UsuarioTramite("JPerez"), textoBuscado = "texto buscado ",  poisEncontrados = puntosDeInteres},
            new Busqueda {  fecha = DateTime.Parse("2015-06-10T07:34:42-5:00"), usuario = new UsuarioTramite("JPerez"), textoBuscado = "texto buscado ",  poisEncontrados = puntosDeInteres},
            new Busqueda {  fecha = DateTime.Parse("2015-06-10T07:34:42-5:00"), usuario = new UsuarioTramite("JPerez"), textoBuscado = "texto buscado ",  poisEncontrados = puntosDeInteres}
        };


        /* E5 - Servicio Rest - Búsqueda de puntos de interés
          •	Búsqueda de puntos de interés
            o	recibe un criterio o una combinación de ellos,
            o	devuelve la lista de puntos de interés
        */

        // GET: api/Busqueda
        public IEnumerable<Busqueda> Get()
        {
           return this.busquedas;
        }


        /* E5 - Servicio Rest - Historial de consultas realizadas
         •	Historial de consultas realizadas
            o	se pasa el criterio de búsqueda (por rango de fechas / usuario)
            o	devuelve la lista de consultas realizadas
         */

        [Route("api/Busqueda/{fecha1}/{fecha2}/{usuario}")]
        public IEnumerable<Busqueda> get(string fecha1, string fecha2, string usuario)
        {
            
            return this.busquedas;


        }

        // GET: api/Busqueda/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Busqueda
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Busqueda/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Busqueda/5
        public void Delete(int id)
        {
        }
    }
}
