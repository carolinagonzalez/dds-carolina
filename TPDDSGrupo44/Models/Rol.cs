using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TPDDSGrupo44.Models
{
    public class Rol
    {
        [Key]
        public new int id { get; set; }

        public string nombre { get; set; }
        public List<FuncionalidadUsuario> funcionalidades { get; set; }

        public Rol (){ }

        public Rol (string nombreRol)
        {
            this.nombre = nombreRol;
            this.funcionalidades = new List<FuncionalidadUsuario>();
        }

        public Rol(string nombreRol, List<FuncionalidadUsuario> funcionalidades )
        {
            this.nombre = nombreRol;
            this.funcionalidades = funcionalidades;
        }

    }
}