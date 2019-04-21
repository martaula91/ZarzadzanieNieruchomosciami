namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmianyGlosowanie : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM dbo.Glos");

            DropForeignKey("dbo.Glos", "GlosowanieId", "dbo.Glosowanie");
            DropIndex("dbo.Glos", new[] { "GlosowanieId" });
            AddColumn("dbo.Glos", "PytanieId", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Glos", "Odpowiedz", c => c.Int(nullable: false));
            CreateIndex("dbo.Glos", "PytanieId");
            CreateIndex("dbo.Glos", "UserId");
            AddForeignKey("dbo.Glos", "PytanieId", "dbo.Pytanie", "PytanieId", cascadeDelete: true);
            AddForeignKey("dbo.Glos", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Glosowanie", "Pytanie1");
            DropColumn("dbo.Glosowanie", "Pytanie2");
            DropColumn("dbo.Glosowanie", "Pytanie3");
            DropColumn("dbo.Glosowanie", "Pytanie4");
            DropColumn("dbo.Glosowanie", "Pytanie5");
            DropColumn("dbo.Glosowanie", "Pytanie6");
            DropColumn("dbo.Glosowanie", "Pytanie7");
            DropColumn("dbo.Glosowanie", "Pytanie8");
            DropColumn("dbo.Glosowanie", "Pytanie9");
            DropColumn("dbo.Glosowanie", "Pytanie10");
            DropColumn("dbo.Glos", "GlosowanieId");
            DropColumn("dbo.Glos", "Odpowiedz1");
            DropColumn("dbo.Glos", "Odpowiedz2");
            DropColumn("dbo.Glos", "Odpowiedz3");
            DropColumn("dbo.Glos", "Odpowiedz4");
            DropColumn("dbo.Glos", "Odpowiedz5");
            DropColumn("dbo.Glos", "Odpowiedz6");
            DropColumn("dbo.Glos", "Odpowiedz7");
            DropColumn("dbo.Glos", "Odpowiedz8");
            DropColumn("dbo.Glos", "Odpowiedz9");
            DropColumn("dbo.Glos", "Odpowiedz10");
            DropColumn("dbo.Pytanie", "Odpowiedz");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pytanie", "Odpowiedz", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz10", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz9", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz8", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz7", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz6", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz5", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz4", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz3", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz2", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "Odpowiedz1", c => c.Int(nullable: false));
            AddColumn("dbo.Glos", "GlosowanieId", c => c.Int(nullable: false));
            AddColumn("dbo.Glosowanie", "Pytanie10", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie9", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie8", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie7", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie6", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie5", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie4", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie3", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie2", c => c.String());
            AddColumn("dbo.Glosowanie", "Pytanie1", c => c.String());
            DropForeignKey("dbo.Glos", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Glos", "PytanieId", "dbo.Pytanie");
            DropIndex("dbo.Glos", new[] { "UserId" });
            DropIndex("dbo.Glos", new[] { "PytanieId" });
            DropColumn("dbo.Glos", "Odpowiedz");
            DropColumn("dbo.Glos", "UserId");
            DropColumn("dbo.Glos", "PytanieId");
            CreateIndex("dbo.Glos", "GlosowanieId");
            AddForeignKey("dbo.Glos", "GlosowanieId", "dbo.Glosowanie", "GlosowanieId", cascadeDelete: true);
        }
    }
}
