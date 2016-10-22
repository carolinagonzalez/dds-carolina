using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TPDDSGrupo44.Models
{

    public class Usuario
    {

        public int id { get; set; }
        ////////////////Atributos////////////////
        public string dni { get; set; }
        public string contrasenia { get; set; }
        public string nombre { get; set; }
        public Rol rolUsuario { get; set; }


        public Usuario() { }
        public Usuario(string nombre)
        {
            this.nombre = nombre;
        }

        public Usuario(string dni, string nombre, string contrasenia) {
            this.dni = dni;
            this.nombre = nombre;
            this.contrasenia = contrasenia;
        }

        public Boolean existeAcciones(int idAccion)
        {
            Boolean exist = false;
            foreach (var accion in this.rolUsuario.funcionalidades)
            {
                if (accion.id == idAccion)
                {
                    exist = true;
                }
            }

            return exist;

        }
    }
}
