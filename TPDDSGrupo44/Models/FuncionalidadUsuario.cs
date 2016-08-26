using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class FuncionalidadUsuario
    {
        string nombre { get; set; }

        public FuncionalidadUsuario ()
        {
        }

        public virtual void cargarPOI() { }

        public virtual void realizarTramite() { }

        public virtual void loguearse() { }
    }
}