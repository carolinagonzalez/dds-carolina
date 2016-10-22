using System;

namespace TPDDSGrupo44.Models
{
    public class FuncionalidadUsuario
    {
       
        public int id { get; set; }
        public string nombre { get; set; }
        public Boolean activo { get; set; }

        public FuncionalidadUsuario() { }

        public FuncionalidadUsuario(string nombre)
        {
            this.nombre = nombre;
        }


        public virtual void cargarPOI() { }

        public virtual void realizarTramite() { }

        public virtual void loguearse() { }
    }
}