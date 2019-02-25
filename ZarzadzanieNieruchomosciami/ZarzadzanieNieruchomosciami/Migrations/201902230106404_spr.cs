namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spr : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "LokalMieszkalny_LokalID" });


        }
        
        public override void Down()
        {

            CreateIndex("dbo.AspNetUsers", "LokalMieszkalny_LokalID");
        }
    }
}
