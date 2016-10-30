using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSGrupo44.Models
{
    [Table("Rubros")]
    public class Rubro
    {
        [Key]
        ////////////////Atributos////////////////
        public int Id { get; set; }

        public string nombre { get; set; }
        public int radioDeCercania { get; set; }

        ////////////////Constructor vacio////////////////
        public Rubro() { }

        ////////////////Creo Constructor////////////////
        public Rubro(string nombreR, int radio)
        {
            nombre = nombreR;
            radioDeCercania = radio;
        }

        public virtual ICollection<LocalComercial> localesComerciales { get; set; }
    }


   

}