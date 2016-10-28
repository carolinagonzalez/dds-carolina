namespace TPDDSGrupo44.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class BuscAR : DbContext
    {
        
        public BuscAR singleton { get; set; }
        

        public BuscAR()
            : base("name=DbConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new PuntoDeInteresMap());
            modelBuilder.Configurations.Add(new ParadaDeColectivoMap());
            modelBuilder.Configurations.Add(new LocalComercialMap());
            modelBuilder.Configurations.Add(new CgpMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new AdministradorMap());
            modelBuilder.Configurations.Add(new TerminalMap());

            base.OnModelCreating(modelBuilder);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Busqueda> Busquedas { get; set; }

        //tablas de POIs
        public virtual DbSet<PuntoDeInteres> puntosInteres { get; set; }
        public virtual DbSet<PalabraClave> PalabrasClave { get; set; }
        public virtual DbSet<Rubro> Rubros { get; set; }
        public virtual DbSet<HorarioAbierto> Horarios { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<CuentaDeUsuario> cuentaDeUsuario { get; set; }
        public virtual DbSet<ConfiguracionDeAcciones> configuracionDeAcciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<DispositivoTactil> DispositivoTactiles { get; set; }

    /* Mappeo de los puntos de interes */

        public class PuntoDeInteresMap : EntityTypeConfiguration<PuntoDeInteres>
        {
            public PuntoDeInteresMap()
            {
                HasKey(x => x.id);
                Property(x => x.coordenada).IsRequired();
                Property(x => x.calle).HasMaxLength(250);
                Property(x => x.numeroAltura);
                Property(x => x.piso);
                Property(x => x.unidad);
                Property(x => x.codigoPostal);
                Property(x => x.localidad).HasMaxLength(250);
                Property(x => x.barrio).HasMaxLength(250);
                Property(x => x.provincia).HasMaxLength(250);
                Property(x => x.pais).HasMaxLength(250);
                Property(x => x.entreCalles).HasMaxLength(250);
                Property(x => x.localidad).HasMaxLength(250);
                Property(x => x.nombreDePOI).HasMaxLength(250);

                Map<Banco>(x => x.Requires("tipoDePOI")
                            .HasValue("Banco"));
            }
        }

        public class ParadaDeColectivoMap : EntityTypeConfiguration<ParadaDeColectivo>
        {
            public ParadaDeColectivoMap()
            {
                ToTable("ParadasDeColectivo");

                Property(x => x.lineaDeColectivo).IsRequired()
                                               .HasColumnType("varchar")
                                               .HasMaxLength(100);
            }
        }

        public class CgpMap : EntityTypeConfiguration<CGP>
        {
            public CgpMap()
            {
                ToTable("CGPS");

                Property(x => x.numeroDeComuna);
                Property(x => x.zonaDelimitadaPorLaComuna);
            }
        }

        public class LocalComercialMap : EntityTypeConfiguration<LocalComercial>
        {
            public LocalComercialMap()
            {
                ToTable("LocalesComerciales");

                Property(x => x.nombreFantasia).HasColumnType("varchar").HasMaxLength(100);
            }
        }

        /* Fin mappeo de pois */
        /* Mappeo de Usuarios */

        public class UsuarioMap : EntityTypeConfiguration<Usuario>
        {
            public UsuarioMap()
            {
                HasKey(x => x.id);
                Property(x => x.email).HasMaxLength(250);
                Property(x => x.contrasenia).HasMaxLength(250);
                Property(x => x.nombre).HasMaxLength(250);
                
            }
        }

        
        public class TerminalMap : EntityTypeConfiguration<Terminal>
        {
            public TerminalMap()
            {
                ToTable("UsuarioTerminal");

                Property(x => x.activa);
            }
        }
        
        public class AdministradorMap : EntityTypeConfiguration<Administrador>
        {
            public AdministradorMap()
            {
                ToTable("UsuariosAdministradores");

                Property(x => x.cantSegDemoraA);
            }
        }

    }
}