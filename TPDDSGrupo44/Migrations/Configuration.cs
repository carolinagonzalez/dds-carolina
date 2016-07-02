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
            List<ParadaDeColectivo> paradas = new List<ParadaDeColectivo>();
 

            // Agrego parada 114
            ParadaDeColectivo parada = new Models.ParadaDeColectivo("Mozart 2389", DbGeography.FromText("POINT(-34.659690 -58.468764)"));
            parada.palabraClave = "114";
            paradas.Add(parada);
            // Agrego Parada 36 - lejana
            parada = new Models.ParadaDeColectivo("Av Escalada 2680", DbGeography.FromText("POINT(-34.662325 -58.473300)"));
            parada.palabraClave = "36";
            paradas.Add(parada);

            // Agrego librería ceit
            Models.LocalComercial local = new Models.LocalComercial("Librería CEIT", DbGeography.FromText("POINT(-34.659492 -58.467906)"), new Models.Rubro("librería escolar", 5));
            locales.Add(local);

            // agrego puesto de diarios 
            local = new Models.LocalComercial("Kiosco Las Flores", DbGeography.FromText("POINT(-34.634015 -58.482805)"), new Models.Rubro("kiosco de diarios", 5));
            locales.Add(local);

            // Agrego CGP Lugano
            CGP CGP = new CGP("Sede Comunal 8", DbGeography.FromText("POINT(-34.6862397 -58.4606666)"), 50); ;
            cgps.Add(CGP);

            // Agrego CGP Floresta
            CGP = new CGP("Sede Comunal 10", DbGeography.FromText("POINT(-34.6318411 -58.4857468)"), 10);
            cgps.Add(CGP);

            // Agrego Banco Provincia
            Models.Banco banco = new Models.Banco("Banco Provincia", DbGeography.FromText("POINT(-34.660979 -58.469821)"));
            bancos.Add(banco);

            // Agrego Banco Francés
            banco = new Banco("Banco Francés", DbGeography.FromText("POINT(-34.6579153 -58.4791142)"));
            bancos.Add(banco);




            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Subo bancos a la DB
            foreach (Banco b in bancos)
            {
                var puntoInDataBase = context.Bancos.Where(
                    p =>
                         p.Id == b.Id).SingleOrDefault();
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
                         p.Id == c.Id).SingleOrDefault();
                if (puntoInDataBase == null)
                {
                    context.CGPs.Add(c);
                }
            }
            context.SaveChanges();

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Subo Locales a la DB
            foreach (LocalComercial l in locales)
            {
                var puntoInDataBase = context.Locales.Where(
                    p =>
                         p.Id == l.Id).SingleOrDefault();

                var rubroInDataBase = context.Rubros.Where(
                    r =>
                         r.Id == l.rubro.Id).SingleOrDefault();
                if (puntoInDataBase == null)
                {
                    context.Locales.Add(l);
                }

                if (rubroInDataBase == null)
                {
                    context.Rubros.Add(l.rubro);
                }
            }
            context.SaveChanges();

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Subo Paradas a la DB
            foreach (ParadaDeColectivo c in paradas)
            {
                var puntoInDataBase = context.Paradas.Where(
                    p =>
                         p.Id == c.Id).SingleOrDefault();
                if (puntoInDataBase == null)
                {
                    context.Paradas.Add(c);
                }
            }
            context.SaveChanges();

        }
    }
}
