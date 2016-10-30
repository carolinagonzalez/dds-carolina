using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TPDDSGrupo44.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }
        public string nombre { get; set; }


        public Usuario() { }
        public Usuario(string nombre)
        {
            this.nombre = nombre;
        }

        public Usuario(string email, string nombre, string contrasenia) {
            this.email = email;
            this.nombre = nombre;
            this.contrasenia = contrasenia;
        }

        
    }
}
