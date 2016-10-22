namespace TPDDSGrupo44.Models
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class BuscAR : DbContext
    {
        
        public BuscAR singleton { get; set; }
        

        public BuscAR()
            : base("name=PoiConnectionString")
        {
            
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Busqueda> Busquedas { get; set; }

        //tablas de POIs
        public virtual DbSet<Banco> Bancos { get; set; }
        public virtual DbSet<CGP> CGPs { get; set; }
        public virtual DbSet<LocalComercial> Locales { get; set; }
        public virtual DbSet<ParadaDeColectivo> Paradas { get; set; }

        //tablas de sistema
        public virtual DbSet<DispositivoTactil> DispositivoTactiles { get; set; }
        //public virtual DbSet<ActualizacionAsincronica> LogProcesosAsincronicos { get; set; }

        // tablas accesorias
        public virtual DbSet<Rubro> Rubros { get; set; }
        public virtual DbSet<HorarioAbierto> Horarios { get; set; }
        public virtual DbSet<ServicioCGP> ServiciosCPG { get; set; }
        public virtual DbSet<CuentaDeUsuario> cuentaDeUsuario { get; set; }
        public virtual DbSet<ConfiguracionDeAcciones> configuracionDeAcciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }



    }
}