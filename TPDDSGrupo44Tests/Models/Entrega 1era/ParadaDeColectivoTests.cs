using NUnit.Framework;
using System;
using System.Data.Entity.Spatial;
using System.Device.Location;

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
    }
}