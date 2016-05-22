using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class CGP : PuntoDeInteres
    {
        public DateTime horario { get; set; } //Como se declara el tipo horario ?
        public string direccion { get; set; }
        public int numero { get; set; }
        public string tipoServicio { get; set; }
        public int zonaDelimitadaPorLaComuna { get; set; }

        // Creo Constructor

        public CGP(string nombre, Coordenada unaCoordenada, ConsultoCercania unaConsulta,int zona)
        : base(nombre, unaCoordenada, unaConsulta)
        {
            this.nombreDelPOI = nombre;
            this.coordenada = unaCoordenada;
            this.consultoCercania = unaConsulta;
            this.zonaDelimitadaPorLaComuna = zona;
        }
        /*
        public CGP()
        {
            this.posibilidades = new List<String>() { "Atencion al publico", "Rentas", "Registro Civil", "Multas" };

        }
        */

        //2.	Los CGP cumplen la condición de cercanía, si su coordenada está dentro de la zona delimitada por la comuna.
        public Boolean estaCerca(Coordenada coordenadaDeDispositivoTactil )
        {
            return this.consultoCercania.obtengoDistancia(coordenadaDeDispositivoTactil, this.coordenada) < this.zonaDelimitadaPorLaComuna; //Cuadras
        }
    }
}