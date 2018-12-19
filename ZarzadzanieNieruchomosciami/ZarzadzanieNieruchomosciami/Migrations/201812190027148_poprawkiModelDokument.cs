namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawkiModelDokument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LokalMieszkalny", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.LokalMieszkalny", "ApplicationUser_Id");
            AddForeignKey("dbo.LokalMieszkalny", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LokalMieszkalny", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LokalMieszkalny", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.LokalMieszkalny", "ApplicationUser_Id");
        }
    }
}
