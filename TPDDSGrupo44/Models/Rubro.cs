using System.ComponentModel.DataAnnotations;

namespace TPDDSGrupo44.Models
{
    public class Rubro
    {
        [Key]
        public int Id { get; set; }

        public string nombre { get; set; }
        public int radioDeCercania { get; set; }

        public Rubro() { }

        //Creo Constructor
        public Rubro(string nombreR, int radio)
        {
            nombre = nombreR;
            radioDeCercania = radio;
        }
    }


   

}