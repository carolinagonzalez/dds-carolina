using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSGrupo44.Models
{
    [Table("FuncionalidadesUsuario")]
    public class FuncionalidadUsuario
    {
       
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public Boolean activo { get; set; }
        public virtual ICollection<Terminal> usuariosTerminales { get; set; }

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