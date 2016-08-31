using System.Collections.Generic;
using System;

namespace TPDDSGrupo44.Models
{
    public class UsuarioTramite
    {
        ////////////////Atributos////////////////
        public int id { get; set; }
        public List<Accion> acciones { get; set; }
        public int dni { get; set; }
        public string contrasenia { get; set; }

        public Boolean existeAcciones(int idAccion)
        {
            Boolean exist = false;
            foreach (var accion in this.acciones)
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