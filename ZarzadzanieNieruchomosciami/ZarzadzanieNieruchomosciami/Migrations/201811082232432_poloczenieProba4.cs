namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poloczenieProba4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LokalMieszkalny", "UzytkownikId");
            DropColumn("dbo.LokalMieszkalny", "Users_UzytkownikId");
            DropColumn("dbo.LokalMieszkalny", "Users_KategoriaId");
            DropColumn("dbo.LokalMieszkalny", "Users_LokalId");
            DropColumn("dbo.LokalMieszkalny", "Users_Imie");
            DropColumn("dbo.LokalMieszkalny", "Users_Nazwisko");
            DropColumn("dbo.LokalMieszkalny", "Users_Adres");
            DropColumn("dbo.LokalMieszkalny", "Users_Miasto");
            DropColumn("dbo.LokalMieszkalny", "Users_KodPocztowy");
            DropColumn("dbo.LokalMieszkalny", "Users_Telefon");
            DropColumn("dbo.LokalMieszkalny", "Users_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LokalMieszkalny", "Users_Email", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Telefon", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_KodPocztowy", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Miasto", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Adres", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Nazwisko", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_Imie", c => c.String());
            AddColumn("dbo.LokalMieszkalny", "Users_LokalId", c => c.Int(nullable: false));
            AddColumn("dbo.LokalMieszkalny", "Users_KategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.LokalMieszkalny", "Users_UzytkownikId", c => c.Int(nullable: false));
            AddColumn("dbo.LokalMieszkalny", "UzytkownikId", c => c.Int(nullable: false));
        }
    }
}
