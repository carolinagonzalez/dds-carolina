namespace TPDDSGrupo44.Models
{
    public class Rubro
    {
        public string nombreRubro { get; set; }
        public int radioDeCercania { get; set; }



        //Creo Constructor
        public Rubro(string nombre, int radio)
        {
            nombreRubro = nombre;
            radioDeCercania = radio;
        }
    }


   

}