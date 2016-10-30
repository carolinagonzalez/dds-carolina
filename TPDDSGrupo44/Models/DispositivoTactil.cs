using System;
using System.Collections.Generic;
using TPDDSGrupo44.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSGrupo44
{
    [Table("DispositivosTactiles")]
    public class DispositivoTactil
    {
        [Key]
        ////////////////Atributos////////////////
        public int Id { get; set; }
        public DbGeography coordenada { get; set; }
        public string nombre { get; set; }
        public int comuna { get; set; } 
        public virtual Terminal usuarioTerminal  { get; set; }
    ////////////////Constructor vacio////////////////
        public DispositivoTactil() { }

        ////////////////Creo Constructor////////////////
        public DispositivoTactil(string nombreDelPunto, DbGeography unaCoordenada)
        {
            nombre = nombreDelPunto;
            coordenada = unaCoordenada;
        }
        

    }
}