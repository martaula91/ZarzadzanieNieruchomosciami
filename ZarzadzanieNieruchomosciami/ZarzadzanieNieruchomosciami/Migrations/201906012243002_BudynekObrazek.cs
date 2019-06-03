namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BudynekObrazek : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlokMieszkalny", "NazwaPlikuObrazka", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlokMieszkalny", "NazwaPlikuObrazka");
        }
    }
}
