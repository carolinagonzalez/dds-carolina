using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using TPDDSGrupo44.Models;

namespace TPDDSGrupo44.Controllers.Tests
{
    [TestFixture()]
    public class HomeControllerTests
    {
        [Test()]
        public void AvailabilityTest()
        {
            // Genero lista de puntos
            List<Models.PuntoDeInteres> puntos = new List<Models.PuntoDeInteres>();

            // Agrego parada 114
            ParadaDeColectivo parada = new ParadaDeColectivo("Mozart 2389", DbGeography.FromText("POINT(-34.659690 -58.468764)"));

            parada.palabraClave = "114";

            puntos.Add(parada);

            Assert.IsTrue(parada.estaDisponible(DateTime.Now));
        }
    }
}