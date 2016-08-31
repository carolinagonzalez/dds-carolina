using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class Rol
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Accion> funcionalidades { get; set; }
    }
}