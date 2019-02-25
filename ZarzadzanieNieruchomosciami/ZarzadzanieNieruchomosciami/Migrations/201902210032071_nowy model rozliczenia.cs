namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowymodelrozliczenia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rozliczenie",
                c => new
                    {
                        RozliczenieId = c.Int(nullable: false, identity: true),
                        StawkaID = c.Int(nullable: false),
                        Nazwa = c.String(),
                        CentralneOgrzewanie = c.Double(nullable: false),
                        ZWiSCLicznik = c.Double(nullable: false),
                        CWLicznik = c.Double(nullable: false),
                        EnergiaElekCzescWspolna = c.Double(nullable: false),
                        WywozSmieci = c.Double(nullable: false),
                        KosztyAdministrowania = c.Double(nullable: false),
                        KosztyObslugiBankUbezp = c.Double(nullable: false),
                        FunduszRemontowy = c.Double(nullable: false),
                        StanObecny = c.Double(nullable: false),
                        OgolemDoZaplaty = c.Double(nullable: false),
                        StanNaDzien = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RozliczenieId)
                .ForeignKey("dbo.Stawka", t => t.StawkaID, cascadeDelete: true)
                .Index(t => t.StawkaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rozliczenie", "StawkaID", "dbo.Stawka");
            DropIndex("dbo.Rozliczenie", new[] { "StawkaID" });
            DropTable("dbo.Rozliczenie");
        }
    }
}
