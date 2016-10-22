using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{
    public class Rol
    {
        public new int id { get; set; }
        string nombre { get; set; }
        public List<FuncionalidadUsuario> funcionalidades { get; set; }

        public Rol (){ }

        public Rol (string nombreRol)
        {
            nombre = nombreRol;
            funcionalidades = new List<FuncionalidadUsuario>();
        }

    }
}