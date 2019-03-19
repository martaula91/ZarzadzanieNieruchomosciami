namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poleSaldoNoweTypyAwari : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LokalMieszkalny", "Saldo", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LokalMieszkalny", "Saldo");
        }
    }
}
