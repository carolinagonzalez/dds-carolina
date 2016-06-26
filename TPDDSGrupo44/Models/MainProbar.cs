using System;
using System.Device.Location;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models
{

    public class MainProbar
        {
        static void Main(string[] args)
        {
            //Creo lo que ingresa el usuario


            //Declaro dispositivo tactil
            DispositivoTactil dispositivoTactil = new DispositivoTactil("UTN FRBA Campus", new GeoCoordinate(-34.812811, -58.4516456));

            Banco banco = new Banco("HSBC", new GeoCoordinate(-34.81725, -58.4476116));


            CGP cgp = new CGP("nombre", new GeoCoordinate(-34.81725, -58.4476116), 34);

            LocalComercial localComercial = new LocalComercial("localComercial", new GeoCoordinate(-34.81725, -58.4476116), new Rubro("libreria",34));

            //ParadaDeColectivo parada=new ParadaDeColectivo("114", new GeoCoordinate(-34.81725, -58.4476116));

            List<String> paradasDeEstaLinea = new List<String>();

            // Parada unaParada = new Parada(numeroDeLinea, unaCoordenada, paradasAgregadas);
            paradasDeEstaLinea.Add("Mozart 300");
            paradasDeEstaLinea.Add("Mozart 100");
            ParadaDeColectivo unaParada = new ParadaDeColectivo(114, new GeoCoordinate(-34.81725, -58.4476116), paradasDeEstaLinea);

            //  unaParada.agregarPOILinea(7, "maipu 999");



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
            //Console.WriteLine(dispositivoTactil.estaCerca(parada));



        }

    }

}  
