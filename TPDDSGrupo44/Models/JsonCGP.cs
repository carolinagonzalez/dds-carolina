using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
	public class CentroDTO
	{
        public int nroComuna { get; set; }
        public string zonas{ get; set; }
        public string nombreDirector { get; set; }
        public string domicilio { get; set; }
        public string telefono{ get; set; }
        public List<string> serviciosDTO{ get; set; } //VER
        public int nroDiaDeLaSemana{ get; set; } //cambiar nombre
        public int horarioDesde{ get; set; }
        public int minutosDesde { get; set; }
        public int horarioHasta { get; set; }
        public int minutosHasta { get; set; }


    }
}