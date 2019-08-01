namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kilkaLokaliDlaOsoby : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DaneUser_LokalId2", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUser_LokalId3", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DaneUser_LokalId4", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DaneUser_LokalId4");
            DropColumn("dbo.AspNetUsers", "DaneUser_LokalId3");
            DropColumn("dbo.AspNetUsers", "DaneUser_LokalId2");
        }
    }
}
