namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class powiazanie2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Rozliczenie", "LokalID");
            AddForeignKey("dbo.Rozliczenie", "LokalID", "dbo.LokalMieszkalny", "LokalID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rozliczenie", "LokalID", "dbo.LokalMieszkalny");
            DropIndex("dbo.Rozliczenie", new[] { "LokalID" });
        }
    }
}
