namespace TPDDSGrupo44.Models
{
    public class Coordenada
    {
        public double latitud { get; set; }
        public double longitud { get; set; }

        //Creo constructor de la coordenada
        public Coordenada(double latitud, double longitud) {
            this.latitud = latitud;
            this.longitud = longitud;
        }
    }
}