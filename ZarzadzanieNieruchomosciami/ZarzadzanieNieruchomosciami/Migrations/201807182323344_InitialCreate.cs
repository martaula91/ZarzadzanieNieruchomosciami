namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlokMieszkalny",
                c => new
                    {
                        BlokMieszkalnyId = c.Int(nullable: false, identity: true),
                        Ulica = c.String(),
                        NumerBlokuMieszkalnego = c.Int(nullable: false),
                        PowierzchniaUzytkowa = c.Int(nullable: false),
                        LiczbaLokali = c.Int(nullable: false),
                        PowDzialki = c.Int(nullable: false),
                        NrEwidDzialki = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlokMieszkalnyId);
            
            CreateTable(
                "dbo.Dokument",
                c => new
                    {
                        DokumentID = c.Int(nullable: false, identity: true),
                        NazwaDokumentu = c.String(),
                        TypDokumentu = c.String(nullable: false, maxLength: 100),
                        AutorDokumentu = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        NazwaPlikuDokumentu = c.String(),
                        OpisDokumentu = c.String(),
                    })
                .PrimaryKey(t => t.DokumentID);
            
            CreateTable(
                "dbo.LokalMieszkalny",
                c => new
                    {
                        LokalId = c.Int(nullable: false, identity: true),
                        BlokMieszkalnyId = c.Int(nullable: false),
                        NumerLokalu = c.Int(nullable: false),
                        PowierzchniaLokalu = c.Double(nullable: false),
                        LiczbaIzb = c.Int(nullable: false),
                        PowPiwnicy = c.Double(nullable: false),
                        Pietro = c.Int(nullable: false),
                        WodaZimna = c.Int(nullable: false),
                        WodaCiepla = c.Int(nullable: false),
                        EnergiaElektryczna = c.Int(nullable: false),
                        Gaz = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LokalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LokalMieszkalny");
            DropTable("dbo.Dokument");
            DropTable("dbo.BlokMieszkalny");
        }
    }
}
