using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
	public class CentroDTO
	{
        public int comuna { get; set; }
        public string zonas { get; set; }
        public string director { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public List<object> servicios { get; set; }
       // nroDiaDeLaSemana - horarioDesde - minutosDesde - horarioHasta - minutosHasta 
    }
}