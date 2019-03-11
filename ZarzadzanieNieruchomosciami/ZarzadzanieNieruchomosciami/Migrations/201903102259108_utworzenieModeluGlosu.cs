namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utworzenieModeluGlosu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Glos",
                c => new
                    {
                        GlosId = c.Int(nullable: false, identity: true),
                        GlosowanieId = c.Int(nullable: false),
                        DataOddaniaGlosu = c.DateTime(nullable: false),
                        Odpowiedz1 = c.Int(nullable: false),
                        Odpowiedz2 = c.Int(nullable: false),
                        Odpowiedz3 = c.Int(nullable: false),
                        Odpowiedz4 = c.Int(nullable: false),
                        Odpowiedz5 = c.Int(nullable: false),
                        Odpowiedz6 = c.Int(nullable: false),
                        Odpowiedz7 = c.Int(nullable: false),
                        Odpowiedz8 = c.Int(nullable: false),
                        Odpowiedz9 = c.Int(nullable: false),
                        Odpowiedz10 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GlosId)
                .ForeignKey("dbo.Glosowanie", t => t.GlosowanieId, cascadeDelete: true)
                .Index(t => t.GlosowanieId);
            
            AddColumn("dbo.Glosowanie", "DataUtworzeniaGlosowania", c => c.DateTime(nullable: false));
            AddColumn("dbo.Glosowanie", "DataKoncaGlosowania", c => c.DateTime(nullable: false));
            AddColumn("dbo.Glosowanie", "Pytanie1", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie2", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie3", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie4", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie5", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie6", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie7", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie8", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie9", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie10", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Glos", "GlosowanieId", "dbo.Glosowanie");
            DropIndex("dbo.Glos", new[] { "GlosowanieId" });
            DropColumn("dbo.Glosowanie", "Pytanie10");
            DropColumn("dbo.Glosowanie", "Pytanie9");
            DropColumn("dbo.Glosowanie", "Pytanie8");
            DropColumn("dbo.Glosowanie", "Pytanie7");
            DropColumn("dbo.Glosowanie", "Pytanie6");
            DropColumn("dbo.Glosowanie", "Pytanie5");
            DropColumn("dbo.Glosowanie", "Pytanie4");
            DropColumn("dbo.Glosowanie", "Pytanie3");
            DropColumn("dbo.Glosowanie", "Pytanie2");
            DropColumn("dbo.Glosowanie", "Pytanie1");
            DropColumn("dbo.Glosowanie", "DataKoncaGlosowania");
            DropColumn("dbo.Glosowanie", "DataUtworzeniaGlosowania");
            DropTable("dbo.Glos");
        }
    }
}
