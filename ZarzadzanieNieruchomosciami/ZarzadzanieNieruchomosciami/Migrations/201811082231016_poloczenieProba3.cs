namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poloczenieProba3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DaneUser_UzytkownikId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUser_KategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUser_LokalId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUser_Imie", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUser_Nazwisko", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUser_Adres", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUser_Miasto", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUser_KodPocztowy", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUser_Telefon", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUser_Email", c => c.String());
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_UzytkownikId");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_KategoriaId");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_LokalId");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Imie");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Nazwisko");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Adres");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Miasto");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_KodPocztowy");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Telefon");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Telefon", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_KodPocztowy", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Miasto", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Adres", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Nazwisko", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Imie", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_LokalId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_KategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_UzytkownikId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "DaneUser_Email");
            DropColumn("dbo.AspNetUsers", "DaneUser_Telefon");
            DropColumn("dbo.AspNetUsers", "DaneUser_KodPocztowy");
            DropColumn("dbo.AspNetUsers", "DaneUser_Miasto");
            DropColumn("dbo.AspNetUsers", "DaneUser_Adres");
            DropColumn("dbo.AspNetUsers", "DaneUser_Nazwisko");
            DropColumn("dbo.AspNetUsers", "DaneUser_Imie");
            DropColumn("dbo.AspNetUsers", "DaneUser_LokalId");
            DropColumn("dbo.AspNetUsers", "DaneUser_KategoriaId");
            DropColumn("dbo.AspNetUsers", "DaneUser_UzytkownikId");
        }
    }
}
