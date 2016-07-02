namespace TPDDSGrupo44.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bancoes", "nombreDelPOI", c => c.String());
            AddColumn("dbo.Bancoes", "coordenada", c => c.Geography());
            AddColumn("dbo.LocalComercials", "nombreDelPOI", c => c.String());
            AddColumn("dbo.LocalComercials", "coordenada", c => c.Geography());
            AddColumn("dbo.ParadaDeColectivoes", "nombreDelPOI", c => c.String());
            AddColumn("dbo.ParadaDeColectivoes", "coordenada", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParadaDeColectivoes", "coordenada");
            DropColumn("dbo.ParadaDeColectivoes", "nombreDelPOI");
            DropColumn("dbo.LocalComercials", "coordenada");
            DropColumn("dbo.LocalComercials", "nombreDelPOI");
            DropColumn("dbo.Bancoes", "coordenada");
            DropColumn("dbo.Bancoes", "nombreDelPOI");
        }
    }
}
