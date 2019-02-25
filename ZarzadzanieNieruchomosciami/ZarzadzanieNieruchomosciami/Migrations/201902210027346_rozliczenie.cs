namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rozliczenie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ksiegowosc",
                c => new
                    {
                        KsiegowoscID = c.Int(nullable: false, identity: true),
                        LokalMieszkalnyID = c.Int(nullable: false),
                        Nazwa = c.String(),
                        OpisDokumentu = c.Int(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                        Wartosc = c.Double(nullable: false),
                        LokalMieszkalny_LokalID = c.Int(),
                    })
                .PrimaryKey(t => t.KsiegowoscID)
                .ForeignKey("dbo.LokalMieszkalny", t => t.LokalMieszkalny_LokalID)
                .Index(t => t.LokalMieszkalny_LokalID);
            
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rozliczenie",
                c => new
                    {
                        RozliczenieId = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.RozliczenieId);
            
            DropForeignKey("dbo.Ksiegowosc", "LokalMieszkalny_LokalID", "dbo.LokalMieszkalny");
            DropIndex("dbo.Ksiegowosc", new[] { "LokalMieszkalny_LokalID" });
            DropTable("dbo.Ksiegowosc");
        }
    }
}
