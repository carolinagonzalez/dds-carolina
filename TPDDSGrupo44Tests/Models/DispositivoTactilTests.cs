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
    [TestFixture]
    public class DispositivoTactilTests
    {
        [Test]
        public void estaCercaTest()
        {
            
            DispositivoTactil unDispositivo = new DispositivoTactil(new GeoCoordinate(-34.6597047, -58.4688947));

            ParadaDeColectivo parada = new ParadaDeColectivo("114", new GeoCoordinate(-34.659690, -58.468764));

            ParadaDeColectivo parada2 = new ParadaDeColectivo("36", new GeoCoordinate(-34.662325, -58.473300));

            Assert.IsTrue(unDispositivo.estaCerca(parada));

            Assert.IsFalse(unDispositivo.estaCerca(parada2));
        
        }

       
    }
}