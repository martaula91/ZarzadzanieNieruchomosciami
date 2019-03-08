namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodajGlosowaniePytania : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Glosowanie",
                c => new
                    {
                        GlosowanieId = c.Int(nullable: false, identity: true),
                        BlokMieszkalnyId = c.Int(nullable: false),
                        NumerUchwaly = c.String(),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.GlosowanieId)
                .ForeignKey("dbo.BlokMieszkalny", t => t.BlokMieszkalnyId, cascadeDelete: true)
                .Index(t => t.BlokMieszkalnyId);
            
            CreateTable(
                "dbo.Pytanie",
                c => new
                    {
                        PytanieId = c.Int(nullable: false, identity: true),
                        GlosowanieId = c.Int(nullable: false),
                        TrescPytania = c.String(),
                        Odpowiedz = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PytanieId)
                .ForeignKey("dbo.Glosowanie", t => t.GlosowanieId, cascadeDelete: true)
                .Index(t => t.GlosowanieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pytanie", "GlosowanieId", "dbo.Glosowanie");
            DropForeignKey("dbo.Glosowanie", "BlokMieszkalnyId", "dbo.BlokMieszkalny");
            DropIndex("dbo.Pytanie", new[] { "GlosowanieId" });
            DropIndex("dbo.Glosowanie", new[] { "BlokMieszkalnyId" });
            DropTable("dbo.Pytanie");
            DropTable("dbo.Glosowanie");
        }
    }
}
