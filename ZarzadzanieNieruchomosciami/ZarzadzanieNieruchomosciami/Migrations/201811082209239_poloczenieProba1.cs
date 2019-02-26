namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poloczenieProba1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PozycjaWlasnosci", "WlasnoscID", "dbo.Wlasnosc");
            DropForeignKey("dbo.Wlasnosc", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PozycjaWlasnosci", new[] { "WlasnoscID" });
            DropIndex("dbo.Wlasnosc", new[] { "UserId" });
            AddColumn("dbo.LokalMieszkalny", "UzytkownikId", c => c.Int(nullable: false));
            AddColumn("dbo.LokalMieszkalny", "Users_UzytkownikId", c => c.Int(nullable: false));
            AddColumn("dbo.LokalMieszkalny", "Users_KategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.LokalMieszkalny", "Users_LokalId", c => c.Int(nullable: false));
            AddColumn("dbo.LokalMieszkalny", "Users_Imie", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Nazwisko", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Adres", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Miasto", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_KodPocztowy", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Telefon", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_UzytkownikId", c => c.Int(nullable: false));
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Wlasnosc",
                c => new
                    {
                        WlasnoscId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Komentarz = c.String(),
                    })
                .PrimaryKey(t => t.WlasnoscId);
            
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_UzytkownikId");
            DropColumn("dbo.LokalMieszkalny", "Users_Email");
            DropColumn("dbo.LokalMieszkalny", "Users_Telefon");
            DropColumn("dbo.LokalMieszkalny", "Users_KodPocztowy");
            DropColumn("dbo.LokalMieszkalny", "Users_Miasto");
            DropColumn("dbo.LokalMieszkalny", "Users_Adres");
            DropColumn("dbo.LokalMieszkalny", "Users_Nazwisko");
            DropColumn("dbo.LokalMieszkalny", "Users_Imie");
            DropColumn("dbo.LokalMieszkalny", "Users_LokalId");
            DropColumn("dbo.LokalMieszkalny", "Users_KategoriaId");
            DropColumn("dbo.LokalMieszkalny", "Users_UzytkownikId");
            DropColumn("dbo.LokalMieszkalny", "UzytkownikId");
            CreateIndex("dbo.Wlasnosc", "UserId");
            CreateIndex("dbo.PozycjaWlasnosci", "WlasnoscID");
            AddForeignKey("dbo.Wlasnosc", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PozycjaWlasnosci", "WlasnoscID", "dbo.Wlasnosc", "WlasnoscId", cascadeDelete: true);
        }
    }
}
