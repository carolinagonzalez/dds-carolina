using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TPDDSGrupo44.Models;

namespace TPDDSGrupo44.Controllers
{
    public class POIsController : ApiController
    {
        int manejoError = 1;
        PuntoDeInteres[] listaPoisBaja = new PuntoDeInteres[] {
            new PuntoDeInteres { id=1,fechaBaja= DateTime.Parse("2015-05-01T07:34:42-5:00") },
            new PuntoDeInteres { id=2,fechaBaja= DateTime.Parse("2014-05-01T07:34:42-5:00") },
            new PuntoDeInteres { id=3,fechaBaja= DateTime.Parse("2008-05-01T07:34:42-5:00") }
        };


        PuntoDeInteres[] listaPois = new PuntoDeInteres[] {
            new PuntoDeInteres { id=1, nombreDePOI =  "Victoria Impala", calle = "Fco. de Beiró 4801", tipoDePOI = "paradaDeColectivo", lineaDeColectivo = "7 Ramal Samore"},
            new PuntoDeInteres { id=2, nombreDePOI = "J Perez Cotillón", calle = "Av. Alvarez Jonte  5232 1º" , tipoDePOI = "localComercial", rubro = "Cotillon"},
            new PuntoDeInteres { id=3, nombreDePOI = "CGP 6", calle = "Patricias Argentinas 277", tipoDePOI = "cgp" },
            new PuntoDeInteres { id=4, nombreDePOI = "Banco Nacion", calle = "Maipu 277", tipoDePOI = "banco", barrio = "Retiro" }
        };
               

        List<LogAction> logs = new List<LogAction>();

        [Route("api/POIs/baja")]
        public IEnumerable<PuntoDeInteres> GetBajas()
        {
            //Hacer peticion a la base de datos y traer todos los pois
            return this.listaPoisBaja;
        }




        [Route("api/POIs/")]
        public IEnumerable<PuntoDeInteres> Get()
        {
            //Hacer peticion a la base de datos y traer todos los pois
            return this.listaPois;
        }

     
            
        [Route("api/POIs/busqueda/{poi}")]
        public IEnumerable<PuntoDeInteres> Get(string poi)
        {
            //Hacer peticion a la base de datos y traer todos los pois
            return this.listaPois;
        }

       
        // GET: api/POIs/5
        public PuntoDeInteres Get(int id)
        {
            PuntoDeInteres poiBuscado = null;

            /*
            foreach (var POI in this.listaPois)
            {
                if (POI.id == id)
                {
                    poiBuscado = POI;
                };
            }

            if (poiBuscado != null)
            {

                logs.Add(new LogAction { id = (logs.ToString().Length) + 1, fechaInicio = poiBuscado.fechaBaja, fechaFin = DateTime.Now, procesoEjecutado = "2 - Baja de POIs", nombreUsuario = "abc", result = "Ok", mensajeDeError = "" });
                return poiBuscado;
            }
            else
            {
                switch (manejoError) {
                    case 1:
                        //Se envía un mail al Usuario avisando el fallo.
                        EnvioDeMails mail = new EnvioDeMails();
                        mail.enviarMail(new TimeSpan(DateTime.Now.Millisecond), 1);
                         break;
                    case 2:
                        //Se reintenta n veces el proceso. Si se ejecuta n veces en forma errónea queda en estado “error”.
                        break;
                    case 3:
                        //No se realiza ninguna acción.
                        break;

                };
                logs.Add(new LogAction { id = (logs.ToString().Length) + 1, fechaInicio = DateTime.Now, fechaFin = DateTime.Now, procesoEjecutado = "2 - Baja de POIs", nombreUsuario = "abc", result = "Error", mensajeDeError = "Critical Exception" });

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An error occurred, please try again or contact the administrator."),
                    ReasonPhrase = "Critical Exception"
                });
            }
            */

            foreach (var POI in this.listaPois)
            {
                if (POI.id == id)
                {
                    poiBuscado = POI;
                };
            }
            

            return poiBuscado;
        }

    
        // PUT: api/POIs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/POIs/5
        public PuntoDeInteres Delete(int id)
        {
            PuntoDeInteres poiEliminado = null;
            foreach (var POI in this.listaPois)
            {
                if (POI.id == id)
                {
                    POI.fechaBaja = DateTime.Now;
                    poiEliminado = POI;
                };
            }

            if (poiEliminado != null)
            {

                logs.Add(new LogAction { id = (logs.ToString().Length) +1, fechaInicio = poiEliminado.fechaBaja, fechaFin = DateTime.Now, procesoEjecutado = "2 - Baja de POIs", nombreUsuario = "abc", result = "Ok", mensajeDeError = "" });
                return poiEliminado;
            }
            else
            {
                logs.Add(new LogAction { id = (logs.ToString().Length) + 1, fechaInicio = DateTime.Now, fechaFin = DateTime.Now, procesoEjecutado = "2 - Baja de POIs", nombreUsuario = "abc", result = "Error", mensajeDeError = "Critical Exception" });

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An error occurred, please try again or contact the administrator."),
                    ReasonPhrase = "Critical Exception"
                });
            }
            

        }
    }
}
