using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPDDSGrupo44.Models
{
    public class ConfiguracionDeAcciones
    {
        [Key]
        public int configID { get; set; }

        public string nombreAccion { get; set; }

        public List<string> config { get; set; }
    }
}