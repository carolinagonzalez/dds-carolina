namespace TPDDSGrupo44.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bancoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombreDelPOI = c.String(),
                        coordenada = c.Geography(),
                        calle = c.String(),
                        numeroAltura = c.Int(nullable: false),
                        piso = c.Int(nullable: false),
                        unidad = c.Int(nullable: false),
                        codigoPostal = c.Int(nullable: false),
                        localidad = c.String(),
                        barrio = c.String(),
                        provincia = c.String(),
                        pais = c.String(),
                        entreCalles = c.String(),
                        palabraClave = c.String(),
                        tipoDePOI = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
                        Banco_id = c.Int(),
                        Banco_id1 = c.Int(),
                        ServicioBanco_Id = c.Int(),
                        ServicioBanco_Id1 = c.Int(),
                        CGP_id = c.Int(),
                        CGP_id1 = c.Int(),
                        ServicioCGP_Id = c.Int(),
                        ServicioCGP_Id1 = c.Int(),
                        LocalComercial_id = c.Int(),
                        LocalComercial_id1 = c.Int(),
                        ParadaDeColectivo_id = c.Int(),
                        ParadaDeColectivo_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancoes", t => t.Banco_id)
                .ForeignKey("dbo.Bancoes", t => t.Banco_id1)
                .ForeignKey("dbo.ServicioBancoes", t => t.ServicioBanco_Id)
                .ForeignKey("dbo.ServicioBancoes", t => t.ServicioBanco_Id1)
                .ForeignKey("dbo.CGPs", t => t.CGP_id)
                .ForeignKey("dbo.CGPs", t => t.CGP_id1)
                .ForeignKey("dbo.ServicioCGPs", t => t.ServicioCGP_Id)
                .ForeignKey("dbo.ServicioCGPs", t => t.ServicioCGP_Id1)
                .ForeignKey("dbo.LocalComercials", t => t.LocalComercial_id)
                .ForeignKey("dbo.LocalComercials", t => t.LocalComercial_id1)
                .ForeignKey("dbo.ParadaDeColectivoes", t => t.ParadaDeColectivo_id)
                .ForeignKey("dbo.ParadaDeColectivoes", t => t.ParadaDeColectivo_id1)
                .Index(t => t.Banco_id)
                .Index(t => t.Banco_id1)
                .Index(t => t.ServicioBanco_Id)
                .Index(t => t.ServicioBanco_Id1)
                .Index(t => t.CGP_id)
                .Index(t => t.CGP_id1)
                .Index(t => t.ServicioCGP_Id)
                .Index(t => t.ServicioCGP_Id1)
                .Index(t => t.LocalComercial_id)
                .Index(t => t.LocalComercial_id1)
                .Index(t => t.ParadaDeColectivo_id)
                .Index(t => t.ParadaDeColectivo_id1);
            
            CreateTable(
                "dbo.ServicioBancoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        Banco_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancoes", t => t.Banco_id)
                .Index(t => t.Banco_id);
            
            CreateTable(
                "dbo.Busquedas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        textoBuscado = c.String(),
                        cantidadDeResultados = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        terminal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DispositivoTactils", t => t.terminal_Id)
                .Index(t => t.terminal_Id);
            
            CreateTable(
                "dbo.DispositivoTactils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        coordenada = c.Geography(),
                        nombre = c.String(),
                        comuna = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CGPs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        coordenada = c.Geography(),
                        calle = c.String(),
                        numeroAltura = c.Int(nullable: false),
                        piso = c.Int(nullable: false),
                        unidad = c.Int(nullable: false),
                        codigoPostal = c.Int(nullable: false),
                        localidad = c.String(),
                        barrio = c.String(),
                        provincia = c.String(),
                        pais = c.String(),
                        entreCalles = c.String(),
                        palabraClave = c.String(),
                        tipoDePOID = c.String(),
                        numeroDeComuna = c.Int(nullable: false),
                        zonaDelimitadaPorLaComuna = c.Int(nullable: false),
                        tipoDePOI = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ServicioCGPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        CGP_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CGPs", t => t.CGP_id)
                .Index(t => t.CGP_id);
            
            CreateTable(
                "dbo.LocalComercials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        coordenada = c.Geography(),
                        calle = c.String(),
                        numeroAltura = c.Int(nullable: false),
                        piso = c.Int(nullable: false),
                        unidad = c.Int(nullable: false),
                        codigoPostal = c.Int(nullable: false),
                        localidad = c.String(),
                        barrio = c.String(),
                        provincia = c.String(),
                        pais = c.String(),
                        entreCalles = c.String(),
                        palabraClave = c.String(),
                        tipoDePOI = c.String(),
                        nombreDelPOI = c.String(),
                        rubro_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Rubroes", t => t.rubro_Id)
                .Index(t => t.rubro_Id);
            
            CreateTable(
                "dbo.Rubroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        radioDeCercania = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParadaDeColectivoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        coordenada = c.Geography(),
                        calle = c.String(),
                        numeroAltura = c.Int(nullable: false),
                        piso = c.Int(nullable: false),
                        unidad = c.Int(nullable: false),
                        codigoPostal = c.Int(nullable: false),
                        localidad = c.String(),
                        barrio = c.String(),
                        provincia = c.String(),
                        pais = c.String(),
                        entreCalles = c.String(),
                        palabraClave = c.String(),
                        tipoDePOI = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HorarioAbiertoes", "ParadaDeColectivo_id1", "dbo.ParadaDeColectivoes");
            DropForeignKey("dbo.HorarioAbiertoes", "ParadaDeColectivo_id", "dbo.ParadaDeColectivoes");
            DropForeignKey("dbo.LocalComercials", "rubro_Id", "dbo.Rubroes");
            DropForeignKey("dbo.HorarioAbiertoes", "LocalComercial_id1", "dbo.LocalComercials");
            DropForeignKey("dbo.HorarioAbiertoes", "LocalComercial_id", "dbo.LocalComercials");
            DropForeignKey("dbo.ServicioCGPs", "CGP_id", "dbo.CGPs");
            DropForeignKey("dbo.HorarioAbiertoes", "ServicioCGP_Id1", "dbo.ServicioCGPs");
            DropForeignKey("dbo.HorarioAbiertoes", "ServicioCGP_Id", "dbo.ServicioCGPs");
            DropForeignKey("dbo.HorarioAbiertoes", "CGP_id1", "dbo.CGPs");
            DropForeignKey("dbo.HorarioAbiertoes", "CGP_id", "dbo.CGPs");
            DropForeignKey("dbo.Busquedas", "terminal_Id", "dbo.DispositivoTactils");
            DropForeignKey("dbo.ServicioBancoes", "Banco_id", "dbo.Bancoes");
            DropForeignKey("dbo.HorarioAbiertoes", "ServicioBanco_Id1", "dbo.ServicioBancoes");
            DropForeignKey("dbo.HorarioAbiertoes", "ServicioBanco_Id", "dbo.ServicioBancoes");
            DropForeignKey("dbo.HorarioAbiertoes", "Banco_id1", "dbo.Bancoes");
            DropForeignKey("dbo.HorarioAbiertoes", "Banco_id", "dbo.Bancoes");
            DropIndex("dbo.LocalComercials", new[] { "rubro_Id" });
            DropIndex("dbo.ServicioCGPs", new[] { "CGP_id" });
            DropIndex("dbo.Busquedas", new[] { "terminal_Id" });
            DropIndex("dbo.ServicioBancoes", new[] { "Banco_id" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "ParadaDeColectivo_id1" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "ParadaDeColectivo_id" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "LocalComercial_id1" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "LocalComercial_id" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "ServicioCGP_Id1" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "ServicioCGP_Id" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "CGP_id1" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "CGP_id" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "ServicioBanco_Id1" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "ServicioBanco_Id" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "Banco_id1" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "Banco_id" });
            DropTable("dbo.ParadaDeColectivoes");
            DropTable("dbo.Rubroes");
            DropTable("dbo.LocalComercials");
            DropTable("dbo.ServicioCGPs");
            DropTable("dbo.CGPs");
            DropTable("dbo.DispositivoTactils");
            DropTable("dbo.Busquedas");
            DropTable("dbo.ServicioBancoes");
            DropTable("dbo.HorarioAbiertoes");
            DropTable("dbo.Bancoes");
        }
    }
}
