using System;
using System.Runtime.Serialization;

namespace TPDDSGrupo44.Models
{
    [DataContract] 
    public class UsuarioTramite
    {
        ////////////////Atributos////////////////
        public int dni { get; set; }
        public string contrasenia { get; set; }
        [DataMember]
        public string nombre { get; set; }
        public Rol rolUsuario { get; set; }


        public UsuarioTramite(string nombre) {
            this.nombre = nombre;
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
