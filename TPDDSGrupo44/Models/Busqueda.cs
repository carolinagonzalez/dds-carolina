using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSGrupo44.Models
{
    [Table("Busquedas")]
    public class Busqueda
    {
        [Key]
        ////////////////Atributos////////////////
        public int Id { get; set; }
        public string textoBuscado { get; set; }
        public DateTime fecha { get; set; }
        public virtual Terminal usuarioTerminal { get; set; }
        public int duracionDeBusqueda { get; set; }
        public virtual ICollection<PuntoDeInteres> poisEncontrados { get; set; }
        ////////////////Constructor vacio////////////////
        public Busqueda () { }
        
        public Busqueda(string texto, List<PuntoDeInteres> resultados, DateTime fechaBusqueda)
        {
            textoBuscado = texto;
            fecha = fechaBusqueda;
            poisEncontrados = resultados;
        }
    }
}