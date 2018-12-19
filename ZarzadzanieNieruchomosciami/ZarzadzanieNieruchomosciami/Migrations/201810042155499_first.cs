namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_KategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_LokalId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Imie", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Nazwisko", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Adres", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Miasto", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_KodPocztowy", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Telefon", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Email");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Telefon");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_KodPocztowy");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Miasto");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Adres");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Nazwisko");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Imie");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_LokalId");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_KategoriaId");
        }
    }
}
