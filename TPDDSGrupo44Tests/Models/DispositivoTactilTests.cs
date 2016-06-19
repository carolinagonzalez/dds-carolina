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
        public void estaCercaParadaTest()
        {
            
            DispositivoTactil unDispositivo = new DispositivoTactil(new GeoCoordinate(-34.6597047, -58.4688947));

            ParadaDeColectivo parada = new ParadaDeColectivo("114", new GeoCoordinate(-34.659690, -58.468764));

            ParadaDeColectivo parada2 = new ParadaDeColectivo("36", new GeoCoordinate(-34.662325, -58.473300));

            Assert.IsTrue(unDispositivo.estaCerca(parada));

            Assert.IsFalse(unDispositivo.estaCerca(parada2));
        
        }


        [Test]
        public void estaCercaLocalTest()
        {
            DispositivoTactil unDispositivo = new DispositivoTactil(new GeoCoordinate(-34.6597047, -58.4688947));

            List<Rubro> rubros = new List<Rubro>();

            rubros.Add(new Rubro("librería escolar", 5));

            rubros.Add(new Rubro("kiosco de diarios", 2));

            LocalComercial local = new LocalComercial("Librería CEIT", new GeoCoordinate(-34.659492, -58.467906), new Rubro("librería escolar", 5));

            LocalComercial otroLocal = new LocalComercial("Kiosco Las Flores", new GeoCoordinate(-34.634015, -58.482805), new Rubro("kiosco de diarios", 5));

            Assert.IsTrue(unDispositivo.estaCerca(local));

            Assert.IsFalse(unDispositivo.estaCerca(otroLocal));

        }

        [Test]
        public void estaCercaCGPTest()
        {
            DispositivoTactil unDispositivo = new DispositivoTactil(new GeoCoordinate(-34.6597047, -58.4688947));

            // Agrego CGP Lugano
            CGP CGP = new CGP("Sede Comunal 8", new GeoCoordinate(-34.6862397, -58.4606666), 50); ;
           

            // Agrego CGP Floresta
            CGP otroCGP = new CGP("Sede Comunal 10", new GeoCoordinate(-34.6318411, -58.4857468), 10);

            Assert.IsTrue(unDispositivo.estaCerca(CGP));

            Assert.IsFalse(unDispositivo.estaCerca(otroCGP));


        }

        [Test]
        public void estaCercaBancoTest()
        {
            DispositivoTactil unDispositivo = new DispositivoTactil(new GeoCoordinate(-34.6597047, -58.4688947));

            // Agrego Banco Provincia
            Banco banco = new Banco("Banco Provincia", new GeoCoordinate(-34.660979, -58.469821));
            

            // Agrego Banco Francés
            Banco otroBanco = new Banco("Banco Francés", new GeoCoordinate(-34.6579153, -58.4791142));

            Assert.IsTrue(unDispositivo.estaCerca(banco));

            Assert.IsFalse(unDispositivo.estaCerca(otroBanco));




        }




    }
}