using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSGrupo44.Models
{

    [Table("Terminales")]
    public class Terminal : Usuario
    {
        public virtual ICollection<FuncionalidadUsuario> funcionalidades { get; set; }
        public virtual ICollection<Busqueda> busquedas { get; set; }
        public virtual ICollection<DispositivoTactil> dispositivoTactil { get; set; }
        public new Boolean activa { get; set; }

        public Terminal() {
            funcionalidades = new List<FuncionalidadUsuario>();
        }

        public Terminal(string nombre) : base(nombre)
        {
            funcionalidades = new List<FuncionalidadUsuario>();
        }

        public Boolean existeAcciones(int idAccion)
        {
            Boolean exist = false;
            foreach (var accion in this.funcionalidades)
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