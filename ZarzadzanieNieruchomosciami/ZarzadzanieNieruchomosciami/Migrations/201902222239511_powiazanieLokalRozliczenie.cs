namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class powiazanieLokalRozliczenie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rozliczenie", "LokalID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rozliczenie", "LokalID");
        }
    }
}
