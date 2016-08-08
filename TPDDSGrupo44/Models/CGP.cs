using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        ////////////////Atributos////////////////
        public new int id { get; set; }
        public new DbGeography coordenada { get; set; }
        public new string calle { get; set; }
        public new int numeroAltura { get; set; }
        public new int piso { get; set; }
        public new int unidad { get; set; }
        public new int codigoPostal { get; set; }
        public new string localidad { get; set; }
        public new string barrio { get; set; }
        public new string provincia { get; set; }
        public new string pais { get; set; }
        public new string entreCalles { get; set; }
        public new string palabraClave { get; set; }
        public new string tipoDePOID { get; set; }
        public new List<HorarioAbierto> horarioAbierto { get; set; }
        public new List<HorarioAbierto> horarioFeriado { get; set; }
        public int numeroDeComuna { get; set; }
        public List<ServicioCGP> servicios { get; set; }
        public int zonaDelimitadaPorLaComuna { get; set; }

        ////////////////Constructor Vacio////////////////
        public CGP() { }

        ////////////////Constructor Viejo(Usado en controlador////////////////
        public CGP(string nombre, DbGeography unaCoordenada, int zona)
        : base (nombre, unaCoordenada)
        {
            palabraClave = nombre;
            coordenada = unaCoordenada;
            zonaDelimitadaPorLaComuna = zona;
            servicios = new List<ServicioCGP>();
        }



        ////////////////Cálculo de Cercanía - Dentro de la zona de la Comuna////////////////
        public override bool estaCerca(DbGeography coordenadaDeDispositivoTactil)
        {
            return (coordenadaDeDispositivoTactil.Distance(coordenada) / 100) < zonaDelimitadaPorLaComuna; //Cuadras
        }
    }
}