using NUnit.Framework;
using TPDDSGrupo44.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Models.ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", new GeoCoordinate(-34.659690, -58.468764));

            parada.palabraClave = "114";

            Assert.IsTrue(parada.estaDisponible(DateTime.Now));

            
        }
    }
}