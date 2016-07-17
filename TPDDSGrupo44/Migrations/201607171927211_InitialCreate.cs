namespace TPDDSGrupo44.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Servicios", newName: "ServicioBancoes");
            DropIndex("dbo.ServicioBancoes", new[] { "CGP_Id" });
            RenameColumn(table: "dbo.HorarioAbiertoes", name: "Servicio_Id", newName: "ServicioBanco_Id");
            RenameColumn(table: "dbo.HorarioAbiertoes", name: "Servicio_Id1", newName: "ServicioBanco_Id1");
            RenameIndex(table: "dbo.HorarioAbiertoes", name: "IX_Servicio_Id", newName: "IX_ServicioBanco_Id");
            RenameIndex(table: "dbo.HorarioAbiertoes", name: "IX_Servicio_Id1", newName: "IX_ServicioBanco_Id1");
            CreateTable(
                "dbo.ServicioCGPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        CGP_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CGP_Id);
            
            AddColumn("dbo.HorarioAbiertoes", "ServicioCGP_Id", c => c.Int());
            AddColumn("dbo.HorarioAbiertoes", "ServicioCGP_Id1", c => c.Int());
            CreateIndex("dbo.HorarioAbiertoes", "ServicioCGP_Id");
            CreateIndex("dbo.HorarioAbiertoes", "ServicioCGP_Id1");
            AddForeignKey("dbo.HorarioAbiertoes", "ServicioCGP_Id", "dbo.ServicioCGPs", "Id");
            AddForeignKey("dbo.HorarioAbiertoes", "ServicioCGP_Id1", "dbo.ServicioCGPs", "Id");
            DropColumn("dbo.ServicioBancoes", "CGPRefId");
            DropColumn("dbo.ServicioBancoes", "BancoRefId");
            DropColumn("dbo.ServicioBancoes", "CGP_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServicioBancoes", "CGP_Id", c => c.Int());
            AddColumn("dbo.ServicioBancoes", "BancoRefId", c => c.Int());
            AddColumn("dbo.ServicioBancoes", "CGPRefId", c => c.Int());
            DropForeignKey("dbo.HorarioAbiertoes", "ServicioCGP_Id1", "dbo.ServicioCGPs");
            DropForeignKey("dbo.HorarioAbiertoes", "ServicioCGP_Id", "dbo.ServicioCGPs");
            DropIndex("dbo.ServicioCGPs", new[] { "CGP_Id" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "ServicioCGP_Id1" });
            DropIndex("dbo.HorarioAbiertoes", new[] { "ServicioCGP_Id" });
            DropColumn("dbo.HorarioAbiertoes", "ServicioCGP_Id1");
            DropColumn("dbo.HorarioAbiertoes", "ServicioCGP_Id");
            DropTable("dbo.ServicioCGPs");
            RenameIndex(table: "dbo.HorarioAbiertoes", name: "IX_ServicioBanco_Id1", newName: "IX_Servicio_Id1");
            RenameIndex(table: "dbo.HorarioAbiertoes", name: "IX_ServicioBanco_Id", newName: "IX_Servicio_Id");
            RenameColumn(table: "dbo.HorarioAbiertoes", name: "ServicioBanco_Id1", newName: "Servicio_Id1");
            RenameColumn(table: "dbo.HorarioAbiertoes", name: "ServicioBanco_Id", newName: "Servicio_Id");
            CreateIndex("dbo.ServicioBancoes", "CGP_Id");
            RenameTable(name: "dbo.ServicioBancoes", newName: "Servicios");
        }
    }
}
