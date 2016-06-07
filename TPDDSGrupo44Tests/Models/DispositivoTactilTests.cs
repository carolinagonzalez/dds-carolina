using NUnit.Framework;
using TPDDSGrupo44;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using TPDDSGrupo44.Models;

namespace TPDDSGrupo44.Tests
{
    [TestFixture()]
    public class DispositivoTactilTests
    {
        [TestCase()]
        public void estaCercaTest()
        {
            DispositivoTactil unDispositivo = new DispositivoTactil(new GeoCoordinate(-34.812811, -58.4516456));

            ParadaDeColectivo parada = new ParadaDeColectivo("114", new GeoCoordinate(-34.81725, -58.4476116));

            Assert.IsTrue(unDispositivo.estaCerca(parada));

        }
    }
}