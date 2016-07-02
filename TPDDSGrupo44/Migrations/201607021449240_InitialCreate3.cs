namespace TPDDSGrupo44.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PuntoDeInteres", newName: "Bancoes");
            CreateTable(
                "dbo.CGPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        direccion = c.String(),
                        numero = c.Int(nullable: false),
                        zonaDelimitadaPorLaComuna = c.Int(nullable: false),
                        palabraClave = c.String(),
                        entreCalles = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocalComercials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        palabraClave = c.String(),
                        entreCalles = c.String(),
                        rubro_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rubroes", t => t.rubro_Id)
                .Index(t => t.rubro_Id);
            
            CreateTable(
                "dbo.Rubroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombreRubro = c.String(),
                        radioDeCercania = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParadaDeColectivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        palabraClave = c.String(),
                        entreCalles = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Bancoes", "direccion");
            DropColumn("dbo.Bancoes", "numero");
            DropColumn("dbo.Bancoes", "zonaDelimitadaPorLaComuna");
            DropColumn("dbo.Bancoes", "rubro_nombreRubro");
            DropColumn("dbo.Bancoes", "rubro_radioDeCercania");
            DropColumn("dbo.Bancoes", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bancoes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Bancoes", "rubro_radioDeCercania", c => c.Int());
            AddColumn("dbo.Bancoes", "rubro_nombreRubro", c => c.String());
            AddColumn("dbo.Bancoes", "zonaDelimitadaPorLaComuna", c => c.Int());
            AddColumn("dbo.Bancoes", "numero", c => c.Int());
            AddColumn("dbo.Bancoes", "direccion", c => c.String());
            DropForeignKey("dbo.LocalComercials", "rubro_Id", "dbo.Rubroes");
            DropIndex("dbo.LocalComercials", new[] { "rubro_Id" });
            DropTable("dbo.ParadaDeColectivoes");
            DropTable("dbo.Rubroes");
            DropTable("dbo.LocalComercials");
            DropTable("dbo.CGPs");
            RenameTable(name: "dbo.Bancoes", newName: "PuntoDeInteres");
        }
    }
}
