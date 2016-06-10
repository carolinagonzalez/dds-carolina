using NUnit.Framework;
using TPDDSGrupo44.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

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
            Models.ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", new GeoCoordinate(-34.659690, -58.468764));

            parada.palabraClave = "114";

            puntos.Add(parada);

            Assert.IsTrue(parada.estaDisponible(DateTime.Now));
        }
    }
}