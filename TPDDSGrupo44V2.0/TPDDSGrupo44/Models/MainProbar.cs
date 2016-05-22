using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPDDSGrupo44;

namespace TPDDSGrupo44.Models
{
    
        public class MainProbar
        {
        static void Main(string[] args)
        {
            //Creo lo que ingresa el usuario


            //Declaro dispositivo tactil
            DispositivoTactil dispositivoTactil = new DispositivoTactil(new Coordenada(-34.812811, -58.4516456));

            Banco banco = new Banco("HSBC", new Coordenada(-34.81725, -58.4476116), new ConsultoCercania ());


            CGP cgp = new CGP("nombre", new Coordenada(-34.81725, -58.4476116), new ConsultoCercania(), 34);

            LocalComercial localComercial = new LocalComercial("localComercial", new Coordenada(-34.81725, -58.4476116), new ConsultoCercania(),new Rubro("libreria",34));

            ParadaDeColectivo parada=new ParadaDeColectivo("114", new Coordenada(-34.81725, -58.4476116), new ConsultoCercania());

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(dispositivoTactil.estaCerca(banco));

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(dispositivoTactil.estaCerca(cgp));

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(dispositivoTactil.estaCerca(localComercial));



            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(dispositivoTactil.estaCerca(parada));



        }

    }

}  
