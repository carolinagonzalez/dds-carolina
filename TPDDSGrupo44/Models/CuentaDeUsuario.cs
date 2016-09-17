using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPDDSGrupo44.Models
{
    public class CuentaDeUsuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "(*)Ingrese su Nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "(*)Ingrese su Apellido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "(*)Ingrese su DNI.")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "(*)Ingrese su Email.")]
       // [RegularExpression(@"^([\w-\.]+)@(())"))] --> Agregar expresión regular para el email
        public string Email { get; set; }

        [Required(ErrorMessage = "(*)Ingrese su Nombre de Usuario.")]
        public string NombreDeUsuario { get; set; }

        [Required(ErrorMessage = "(*)Ingrese su Contraseña.")]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "(*)Vuelva a ingresar su Contraseña.")]
        [DataType(DataType.Password)]
        public string ConfirmarContrasenia { get; set; }



    }
}