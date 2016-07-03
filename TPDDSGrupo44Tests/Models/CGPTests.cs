using NUnit.Framework;
using System;
using System.Data.Entity.Spatial;
namespace TPDDSGrupo44.Models.Tests
{
    [TestFixture()]
     public class CGPTests
     {
         [Test()]
         public void estaDisponibleCGPTest()
 {
             CGP CGP = new CGP("Sede Comunal 8", DbGeography.FromText("POINT(-34.6862397 -58.4606666)"), 50);
             Servicio servicio = new Servicio("Rentas");
             servicio.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Monday, 8, 18));
             servicio.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Tuesday, 8, 18));
             servicio.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Wednesday, 8, 18));
             servicio.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Thursday, 8, 18));
             servicio.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Friday, 8, 18));
             servicio.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Saturday, 0, 0));
             servicio.horarioAbierto.Add(new HorarioAbierto(DayOfWeek.Sunday, 0, 0));
             CGP.servicios.Add(servicio);
 
             Assert.IsTrue(CGP.estaDisponible(new DateTime(2016, 06, 15, 12, 00, 00)));
 
             Assert.IsFalse(CGP.estaDisponible(new DateTime(2016, 06, 19, 00, 00, 00)));
         }
     }
 } 