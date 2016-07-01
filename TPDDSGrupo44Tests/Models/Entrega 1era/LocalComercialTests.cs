using NUnit.Framework;
using System;
using System.Data.Entity.Spatial;
using System.Device.Location;


namespace TPDDSGrupo44.Models.Tests
{
    [TestFixture()]
    public class LocalComercialTests
    {
        [Test()]
        public void estaDisponibleLocalTest()
        {
            // Agrego librería ceit
            LocalComercial local = new LocalComercial("Librería CEIT", DbGeography.FromText("POINT(-34.659492 -58.467906)"), new Models.Rubro("librería escolar", 5));

            local.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Monday, 8, 21));

            local.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Tuesday, 8, 21));

            local.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Wednesday, 8, 21));

            local.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Thursday, 8, 21));

            local.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Friday, 8, 21));

            local.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Saturday, 8, 21));

            local.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Sunday, 0, 0));

            local.horarioFeriados.Add(new HorarioAbierto(1, 1, 0, 0));

            local.horarioFeriados.Add(new HorarioAbierto(9, 7, 10, 16));

            Assert.IsTrue(local.estaDisponible(new DateTime(2016, 4, 18, 17, 00, 00)));

            Assert.IsFalse(local.estaDisponible(new DateTime(2016, 6, 19, 00, 00, 00)));
        }
    }
}