namespace TPDDSGrupo44.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispositivoTactils", "coordenada", c => c.Geography());
            DropColumn("dbo.DispositivoTactils", "coordenada_Altitude");
            DropColumn("dbo.DispositivoTactils", "coordenada_Course");
            DropColumn("dbo.DispositivoTactils", "coordenada_HorizontalAccuracy");
            DropColumn("dbo.DispositivoTactils", "coordenada_Latitude");
            DropColumn("dbo.DispositivoTactils", "coordenada_Longitude");
            DropColumn("dbo.DispositivoTactils", "coordenada_Speed");
            DropColumn("dbo.DispositivoTactils", "coordenada_VerticalAccuracy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DispositivoTactils", "coordenada_VerticalAccuracy", c => c.Double(nullable: false));
            AddColumn("dbo.DispositivoTactils", "coordenada_Speed", c => c.Double(nullable: false));
            AddColumn("dbo.DispositivoTactils", "coordenada_Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.DispositivoTactils", "coordenada_Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.DispositivoTactils", "coordenada_HorizontalAccuracy", c => c.Double(nullable: false));
            AddColumn("dbo.DispositivoTactils", "coordenada_Course", c => c.Double(nullable: false));
            AddColumn("dbo.DispositivoTactils", "coordenada_Altitude", c => c.Double(nullable: false));
            DropColumn("dbo.DispositivoTactils", "coordenada");
        }
    }
}
