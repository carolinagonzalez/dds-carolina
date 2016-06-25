namespace TPDDSGrupo44.Models
{
    using System.Data.Entity;

    public class BuscAR : DbContext
    {
        // Your context has been configured to use a 'Busqueda' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TPDDSGrupo44.Models.Busqueda' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Busqueda' 
        // connection string in the application configuration file.
        public BuscAR singleton { get; set; }

        public BuscAR()
            : base("name=BuscAR")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Busqueda> Busquedas { get; set; }
    }

}