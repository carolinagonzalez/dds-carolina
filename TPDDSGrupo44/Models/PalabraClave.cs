using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    [Table("PalabrasClaves")]
    public class PalabraClave
    {
        [Key]
        ////////////////Atributos////////////////
        public int id { get; set; }
        public string  palabra { get; set; }
        public virtual ICollection<PuntoDeInteres> PuntoDeInteres { get; set; }
    }
}