namespace TPDDSGrupo44.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TPDDSGrupo44.Models.BuscAR>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TPDDSGrupo44.Models.BuscAR";
        }

        protected override void Seed(TPDDSGrupo44.Models.BuscAR context)
        {
            //  This method will be called after migrating to the latest version.
            



            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Agrego listas de POIs
            List<Banco> bancos = new List<Banco>();
            List<CGP> cgps = new List<CGP>();
            List<LocalComercial> locales = new List<LocalComercial>();
            //List<ParadaDeColectivo> paradas = new List<ParadaDeColectivo>();


            context.Paradas.AddOrUpdate(
            p => p.palabraClave,   
            new ParadaDeColectivo
            {
                palabraClave = "Mozart 2389",
                coordenada = DbGeography.FromText("POINT(-34.659690 -58.468764)")
            },
            new ParadaDeColectivo
            {
                palabraClave = "Av Escalada 2680",
                coordenada = DbGeography.FromText("POINT(-34.662325 -58.473300)")
            });

            context.SaveChanges();

            


            // Agrego librería ceit
            LocalComercial local = new LocalComercial("Librería CEIT", DbGeography.FromText("POINT(-34.659492 -58.467906)"), new Rubro("librería escolar", 5));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 8, 21));
            local.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            local.horarioFeriados.Add(new HorarioAbierto(1, 1, 0, 0));
            local.horarioFeriados.Add(new HorarioAbierto(9, 7, 10, 16));
            locales.Add(local);

            // agrego puesto de diarios 
            local = new LocalComercial("Kiosco Las Flores", DbGeography.FromText("POINT(-34.634015 -58.482805)"), new Rubro("kiosco de diarios", 5));
            locales.Add(local);

            // Agrego CGP Lugano
            CGP CGP = new CGP("Sede Comunal 8", DbGeography.FromText("POINT(-34.6862397 -58.4606666)"), 50); 
            Servicio servicio = new Servicio("Rentas");
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            CGP.servicios.Add(servicio);
            cgps.Add(CGP);

            // Agrego CGP Floresta
            CGP = new CGP("Sede Comunal 10", DbGeography.FromText("POINT(-34.6318411 -58.4857468)"), 10);
            servicio = new Servicio("Registro Civil");
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 10, 16));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            CGP.servicios.Add(servicio);
            cgps.Add(CGP);

            // Agrego Banco Provincia
            Banco banco = new Banco("Banco Provincia", DbGeography.FromText("POINT(-34.660979 -58.469821)"));
            servicio = new Servicio("Depósitos");
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            servicio.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            banco.servicios.Add(servicio);
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 10, 15));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            banco.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            bancos.Add(banco);

            // Agrego Banco Francés
            banco = new Banco("Banco Francés", DbGeography.FromText("POINT(-34.6579153 -58.4791142)"));
            bancos.Add(banco);




            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Subo bancos a la DB
            foreach (Banco b in bancos)
            {
                var puntoInDataBase = context.Bancos.Where(
                    p =>
                         p.nombreDelPOI == b.nombreDelPOI);
                if (puntoInDataBase == null)
                {
                    context.Bancos.Add(b);
                }
            }
            context.SaveChanges();


            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Subo CGP a la DB
            foreach (CGP c in cgps)
            {
                var puntoInDataBase = context.CGPs.Where(
                    p =>
                         p.nombreDelPOI == c.nombreDelPOI);
                if (puntoInDataBase == null)
                {
                    context.CGPs.Add(c);
                }
            }
            context.SaveChanges();

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Subo Locales a la DB
            foreach (LocalComercial l in locales)
            {
                // agregar el local
                var puntoInDataBase = context.Locales.Where(
                    p =>
                         p.nombreDelPOI == l.nombreDelPOI).SingleOrDefault();
                if (puntoInDataBase == null)
                {
                    context.Locales.Add(l);
                }

                //agregar su rubro
                var rubroInDataBase = context.Rubros.Where(
                    r =>
                         r.nombre == l.rubro.nombre).SingleOrDefault();

                if (rubroInDataBase == null)
                {
                    context.Rubros.Add(l.rubro);
                }
                

            }
            context.SaveChanges();
           

        }
    }
}
