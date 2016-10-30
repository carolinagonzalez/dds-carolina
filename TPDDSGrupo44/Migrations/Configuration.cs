namespace TPDDSGrupo44.Migrations
{
    using Models;
    using System.Collections.Generic;
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
            
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Agrego terminales
            context.DispositivoTactiles.AddOrUpdate(d => d.nombre,
            new DispositivoTactil
            {
                nombre = "UTN FRBA Lugano",
                coordenada = DbGeography.FromText("POINT(-34.6597047 -58.4688947)")
            },
            new DispositivoTactil
            {
                nombre = "Teatro Gran Rivadavia",
                coordenada = DbGeography.FromText("POINT(-34.6349293 -58.4853798)")
            });

            context.SaveChanges();
            
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Agrego Roles

            // Funcionalidades
            FuncionalidadUsuario funcionalidad1 = new FuncionalidadUsuario("Funcionalidad 1");
            FuncionalidadUsuario funcionalidad2 = new FuncionalidadUsuario("Funcionalidad 2");
            FuncionalidadUsuario funcionalidad3 = new FuncionalidadUsuario("Funcionalidad 3");
            FuncionalidadUsuario funcionalidad4 = new FuncionalidadUsuario("Funcionalidad 4");

            // Funcionalidades Admin
            List<FuncionalidadUsuario> funcionalidadesAdmin = new List<FuncionalidadUsuario>();
            funcionalidadesAdmin.Add(funcionalidad1);
            funcionalidadesAdmin.Add(funcionalidad2);

            // Funcionalidades Usuario Tramite
            List<FuncionalidadUsuario> funcionalidadesUsuarioTramite = new List<FuncionalidadUsuario>();
            funcionalidadesUsuarioTramite.Add(funcionalidad3);
            funcionalidadesUsuarioTramite.Add(funcionalidad4);

           
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Agrego Usuarios

           context.Usuarios.AddOrUpdate(
            x => x.email,
            new Terminal
            {
                email = "terminal@gmail.com",
                nombre = "caro",
                contrasenia = "1234"
            },
            new Administrador
            {
                email = "terminal2@gmail.com",
                nombre = "admin",
                contrasenia = "admin",
            });

            context.SaveChanges();

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Agrego listas de POIs

            //Paradas
            context.puntosInteres.AddOrUpdate(
            p => p.nombreDePOI,
            new ParadaDeColectivo
            {
                nombreDePOI = "114",
                calle = "Mozart",
                numeroAltura = 2389,
                localidad = "Ciudad Autónoma de Buenos Aires",
                barrio = "Lugano",
                provincia = "Ciudad Autónoma de Buenos Aires",
                pais = "Argentina",
                entreCalles = "Saraza y Dellepiane Sur",
                coordenada = DbGeography.FromText("POINT(-34.659690 -58.468764)"),
                lineaDeColectivo = "114"
            },
            new ParadaDeColectivo
            {
                nombreDePOI = "36",
                calle = "Av Escalada",
                numeroAltura = 2680,
                localidad = "Ciudad Autónoma de Buenos Aires",
                barrio = "Lugano",
                provincia = "Ciudad Autónoma de Buenos Aires",
                pais = "Argentina",
                entreCalles = "Av Derqui y Dellepiane Norte",
                coordenada = DbGeography.FromText("POINT(-34.662325 -58.473300)"),
                lineaDeColectivo = "36"
            });

            context.SaveChanges();

            //Horarios de locales
            List<HorarioAbierto> horarios = new List<HorarioAbierto>();
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 21));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 21));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 21));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 21));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 21));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 8, 21));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));

            List<HorarioAbierto> feriados = new List<HorarioAbierto>();
            feriados.Add(new HorarioAbierto(1, 1, 0, 0));
            feriados.Add(new HorarioAbierto(9, 7, 10, 16));

            Rubro libreria = new Rubro("librería escolar", 5);
            Rubro kioscoDiario = new Rubro("kiosco de diarios", 5);


            context.Rubros.AddOrUpdate(l => l.nombre, libreria, kioscoDiario);
            

            //Locales
            context.puntosInteres.AddOrUpdate(
            l => l.nombreDePOI,
            new LocalComercial
            {
                nombreDePOI = "Librería CEIT",
                coordenada = DbGeography.FromText("POINT(-34.659492 -58.467906)"),
                rubro =libreria,
                horarioAbierto = horarios,
                nombreFantasia = "El principito"
            },
            new LocalComercial
            {
                nombreDePOI = "Kiosco Las Flores",
                coordenada = DbGeography.FromText("POINT(-34.634015 -58.482805)"),
                rubro = kioscoDiario,
                nombreFantasia = "La vieja floreria"
            });

            context.SaveChanges();


            // servicios CGP Lugano
            Servicio servicio1 = new Servicio("Rentas");
            servicio1.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio1.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio1.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio1.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio1.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio1.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            servicio1.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            List<Servicio> servicios1 = new List<Servicio>();
            servicios1.Add(servicio1);

            //servicios CGP Floresta
            Servicio servicio2 = new Servicio("Registro Civil");
            servicio2.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio2.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio2.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio2.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio2.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio2.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 10, 16));
            servicio2.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            List<Servicio> servicios2 = new List<Servicio>();
            servicios2.Add(servicio2);

            //CGPs
            context.puntosInteres.AddOrUpdate(
            c => c.nombreDePOI,
            new CGP
            {
                nombreDePOI = "Sede Comunal 8",
                calle = "Av Coronel Roca",
                numeroAltura = 5252,
                codigoPostal = 1439,
                localidad = "Ciudad Autónoma de Buenos Aires",
                barrio = "Lugano",
                provincia = "Ciudad Autónoma de Buenos Aires",
                pais = "Argentina",
                entreCalles = "Av Escalda y Av General Paz",
                coordenada = DbGeography.FromText("POINT(-34.6862397 -58.4606666)"),
                zonaDelimitadaPorLaComuna = 50,
                numeroDeComuna = 8,
                servicios = new List<Servicio>()
                {
                     new Servicio()
                    {
                         horarioAbierto = new List<HorarioAbierto>()
                                         {
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Monday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Tuesday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Wednesday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Thursday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Friday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Saturday,
                                horarioInicio = 0,
                                horarioFin = 0
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Sunday,
                                horarioInicio = 0,
                                horarioFin = 0
                                             }
                                         }
                                              }

                                    },
                horarioAbierto = new List<HorarioAbierto>()
                    {
                     new HorarioAbierto()
                    {
                         dia = System.DayOfWeek.Monday,
                        horarioInicio = 8,
                        horarioFin = 18
                                             },
                     new HorarioAbierto()
                    {
                         dia = System.DayOfWeek.Tuesday,
                        horarioInicio = 8,
                        horarioFin = 18
                                             },
                     new HorarioAbierto()
                    {
                         dia = System.DayOfWeek.Wednesday,
                        horarioInicio = 8,
                        horarioFin = 18
                                             },
                     new HorarioAbierto()
                    {
                         dia = System.DayOfWeek.Thursday,
                        horarioInicio = 8,
                        horarioFin = 18
                                             },
                     new HorarioAbierto()
                    {
                         dia = System.DayOfWeek.Friday,
                        horarioInicio = 8,
                        horarioFin = 18
                                             },
                     new HorarioAbierto()
                    {
                         dia = System.DayOfWeek.Saturday,
                        horarioInicio = 0,
                        horarioFin = 0
                                             },
                     new HorarioAbierto()
                    {
                         dia = System.DayOfWeek.Sunday,
                        horarioInicio = 0,
                        horarioFin = 0
                                             }
                                        }
            },
    new CGP
    {
        nombreDePOI = "Sede Comunal 10",
        calle = "Bacacay",
        numeroAltura = 3968,
        codigoPostal = 1407,
        localidad = "Ciudad Autónoma de Buenos Aires",
        barrio = "Vélez Sarsfield",
        provincia = "Ciudad Autónoma de Buenos Aires",
        pais = "Argentina",
        entreCalles = "Mercedes y Av Chivilcoy",
        coordenada = DbGeography.FromText("POINT(-34.6318411 -58.4857468)"),
        zonaDelimitadaPorLaComuna = 10,
        numeroDeComuna = 10,
        servicios = new List<Servicio>()
                {
                     new Servicio()
                    {
                         horarioAbierto = new List<HorarioAbierto>()
                                         {
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Monday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Tuesday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Wednesday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Thursday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Friday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Saturday,
                                horarioInicio = 10,
                                horarioFin = 16
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Sunday,
                                horarioInicio = 0,
                                horarioFin = 0
                                             }
                                         }
                                      }
                                    }
    });
            context.SaveChanges();


            // Horarios Banco Provincia
            Servicio servicio3 = new Servicio("Depósitos");
            servicio3.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Monday, 8, 18));
            servicio3.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 8, 18));
            servicio3.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 8, 18));
            servicio3.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 8, 18));
            servicio3.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Friday, 8, 18));
            servicio3.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            servicio3.horarioAbierto.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));
            List<Servicio> servicios3 = new List<Servicio>();
            servicios3.Add(servicio3);

            horarios = new List<HorarioAbierto>();
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Monday, 10, 15));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Tuesday, 10, 15));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Wednesday, 10, 15));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Thursday, 10, 15));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Friday, 10, 15));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Saturday, 0, 0));
            horarios.Add(new HorarioAbierto(System.DayOfWeek.Sunday, 0, 0));

            // Horarios Banco Francés

            
            //Bancos
            context.puntosInteres.AddOrUpdate(
            b => b.nombreDePOI,
            new Banco
            {
                nombreDePOI = "Banco Provincia",
                coordenada = DbGeography.FromText("POINT( 34.660979  58.469821)"),
                servicios = servicios3,
                horarioAbierto = horarios,
                calle = "Calle Falsa",
                numeroAltura = 123
            },
            new Banco
            {
                nombreDePOI = "Banco Frances",
                coordenada = DbGeography.FromText("POINT( 34.6579153  58.4791142)"),
                calle = "Calle Falsa2",
                numeroAltura = 345,
                servicios = new List<Servicio>()
                {
                     new Servicio()
                    {
                         horarioAbierto = new List<HorarioAbierto>()
                                         {
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Monday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Tuesday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Wednesday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Thursday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Friday,
                                horarioInicio = 8,
                                horarioFin = 18
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Saturday,
                                horarioInicio = 10,
                                horarioFin = 16
                                             },
                             new HorarioAbierto()
                            {
                                 dia = System.DayOfWeek.Sunday,
                                horarioInicio = 0,
                                horarioFin = 0
                                             }
                                         }
                                              }

                                    },
                horarioAbierto = new List<HorarioAbierto>()
                    {
                     new HorarioAbierto()
                    {
                         dia = System.DayOfWeek.Monday,
                        horarioInicio = 8,
                        horarioFin = 18
                                             },
                 new HorarioAbierto()
                {
                     dia = System.DayOfWeek.Tuesday,
                    horarioInicio = 8,
                    horarioFin = 18
                                         },
                 new HorarioAbierto()
                {
                     dia = System.DayOfWeek.Wednesday,
                    horarioInicio = 8,
                    horarioFin = 18
                                         },
                 new HorarioAbierto()
                {
                     dia = System.DayOfWeek.Thursday,
                    horarioInicio = 8,
                    horarioFin = 18
                                         },
                 new HorarioAbierto()
                {
                     dia = System.DayOfWeek.Friday,
                    horarioInicio = 8,
                    horarioFin = 18
                                         },
                 new HorarioAbierto()
                {
                     dia = System.DayOfWeek.Saturday,
                    horarioInicio = 0,
                    horarioFin = 0
                                         },
                 new HorarioAbierto()
                {
                     dia = System.DayOfWeek.Sunday,
                    horarioInicio = 0,
                    horarioFin = 0
                                         }
                                    }
            });

            context.SaveChanges();


        }
    }
}
