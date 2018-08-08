namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dokument", "DataDodania");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dokument", "DataDodania", c => c.DateTime(nullable: false));
        }
    }
}
