using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class Acciones
    {
        public int AccionID { get; set; }
        public string AccionNombre { get; set; }

        public static IQueryable<Acciones> GetAcciones()
        {
            return new List<Acciones>
            {
                new Acciones
                {
                    AccionID = 1,
                    AccionNombre = "Generar Log"
                 },
                new Acciones{
                    AccionID = 2,
                    AccionNombre = "Bajar POI"
                }
            }.AsQueryable();
        }
    }
}