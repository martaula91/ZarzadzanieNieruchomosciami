namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weryfikacjaLicznika : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StanLicznikow", "Weryfikacja", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StanLicznikow", "Weryfikacja");
        }
    }
}
