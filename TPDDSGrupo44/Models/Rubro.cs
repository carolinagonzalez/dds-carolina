using System.ComponentModel.DataAnnotations;

namespace TPDDSGrupo44.Models
{
    public class Rubro
    {
        [Key]
        public int Id { get; set; }

        public string nombreRubro { get; set; }
        public int radioDeCercania { get; set; }

        public Rubro() { }

        //Creo Constructor
        public Rubro(string nombre, int radio)
        {
            nombreRubro = nombre;
            radioDeCercania = radio;
        }
    }


   

}