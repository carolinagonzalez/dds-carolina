namespace TPDDSGrupo44.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PuntoDeInteres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        palabraClave = c.String(),
                        entreCalles = c.String(),
                        direccion = c.String(),
                        numero = c.Int(),
                        zonaDelimitadaPorLaComuna = c.Int(),
                        rubro_nombreRubro = c.String(),
                        rubro_radioDeCercania = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        Banco_Id = c.Int(),
                        CGP_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PuntoDeInteres", t => t.Banco_Id)
                .ForeignKey("dbo.PuntoDeInteres", t => t.CGP_Id)
                .Index(t => t.Banco_Id)
                .Index(t => t.CGP_Id);
            
            CreateTable(
                "dbo.HorarioAbiertoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dia = c.Int(nullable: false),
                        numeroDeDia = c.Int(nullable: false),
                        numeroDeMes = c.Int(nullable: false),
                        horarioInicio = c.Int(nullable: false),
                        horarioFin = c.Int(nullable: false),
                        Servicio_Id = c.Int(),
                        Servicio_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Servicios", t => t.Servicio_Id)
                .ForeignKey("dbo.Servicios", t => t.Servicio_Id1)
                .Index(t => t.Servicio_Id)
                .Index(t => t.Servicio_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicios", "CGP_Id", "dbo.PuntoDeInteres");
            DropForeignKey("dbo.Servicios", "Banco_Id", "dbo.PuntoDeInteres");
            DropForeignKey("dbo.HorarioAbiertoes", "Servicio_Id1", "dbo.Servicios");
            DropForeignKey("dbo.HorarioAbiertoes", "Servicio_Id", "dbo.Servicios");
            DropIndex("dbo.HorarioAbiertoes", new[] { "Servicio_Id1" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "Servicio_Id" });
            DropIndex("dbo.Servicios", new[] { "CGP_Id" });
            DropIndex("dbo.Servicios", new[] { "Banco_Id" });
            DropTable("dbo.HorarioAbiertoes");
            DropTable("dbo.Servicios");
            DropTable("dbo.PuntoDeInteres");
        }
    }
}
