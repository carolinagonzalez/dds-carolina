using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TPDDSGrupo44.Models
{
    public class Busqueda
    {
        [Key]
        ////////////////Atributos////////////////
        public int Id { get; set; }
        public string textoBuscado { get; set; }
        public DateTime fecha { get; set; }
        public DispositivoTactil terminal { get; set; }
        public int duracionDeBusqueda { get; set; }
        public Usuario usuario { get; set; }
        public List<PuntoDeInteres> poisEncontrados { get; set; }

        ////////////////Constructor vacio////////////////
        public Busqueda () { }
        
        public Busqueda(string texto, List<PuntoDeInteres> resultados, DateTime fechaBusqueda, DispositivoTactil terminalBusqueda)
        {
            textoBuscado = texto;
            fecha = fechaBusqueda;
            terminal = terminalBusqueda;
            poisEncontrados = resultados;
        }
    }
}