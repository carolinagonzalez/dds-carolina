using NUnit.Framework;
using System;
using System.Data.Entity.Spatial;
using System.Collections.Generic;

namespace TPDDSGrupo44.Models.Tests
{
    [TestFixture()]
    public class ParadaDeColectivoTests
    {
        [Test()]
        public void estaDisponibleTest()
        {
            // Agrego parada 114
            Models.ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", DbGeography.FromText("POINT(-34.659690 -58.468764)"));

            parada.palabraClave = "114";

            Assert.IsTrue(parada.estaDisponible(DateTime.Now));
        }


        [Test()]
        public void agregarPoidParadaTest()
        {
            DispositivoTactil dispositivo = new DispositivoTactil();
            List<PuntoDeInteres> lista=new List<PuntoDeInteres> ();
            dispositivo.ListaPuntosDeInteres = lista;
            PuntoDeInteres poid = new ParadaDeColectivo("Mozart 2389", DbGeography.FromText("POINT(-34.659690 -58.468764)"));
            poid.palabraClave = "114";
            dispositivo.agregarPoid(poid);

            Assert.IsNotEmpty(lista);

        }

        [Test()]
        public void eliminarPoidParadaTest()
        {
            DispositivoTactil dispositivo = new DispositivoTactil();
            List<PuntoDeInteres> lista = new List<PuntoDeInteres>();
            dispositivo.ListaPuntosDeInteres = lista;
            PuntoDeInteres poid = new ParadaDeColectivo("Mozart 2389", DbGeography.FromText("POINT(-34.659690 -58.468764)"));
            poid.palabraClave = "114";
            dispositivo.agregarPoid(poid);
            dispositivo.eliminarPoid(poid);

            Assert.IsEmpty(lista);
        }


        [Test()]
        public void modificarParadaTest()
        {
            ParadaDeColectivo parada = new ParadaDeColectivo("Mozart 2389", DbGeography.FromText("POINT(-34.659690 -58.468764)"));
            ParadaDeColectivo parada2 = new ParadaDeColectivo("Saraza 4202", DbGeography.FromText("POINT(-34.660905 -58.467805)"));
            parada.numeroDeLinea = "114";
            parada2.numeroDeLinea = "114";

/*            parada.agregarPOILinea("114", "Mozart 2389");
            parada2.agregarPOILinea("114", "Saraza 4202");*/  // si uso esto, tira errores extraños donde no debe..además es chamuyo

            parada.modificarPOILinea("114", "Mozart 2389", "Saraza 4202");

            Assert.IsTrue(parada.paradas.Contains("Saraza 4202"));
        }

        [Test()]
        public void modificarLineaTest()
        {
            ParadaDeColectivo poid = new ParadaDeColectivo("Mozart 2389", DbGeography.FromText("POINT(-34.659690 -58.468764)"));
            poid.numeroDeLinea = "114";

            poid.modificarPOILinea("114", "115");

            Assert.IsTrue(poid.listaDeLineas.Contains("115"));

        }
    }
}