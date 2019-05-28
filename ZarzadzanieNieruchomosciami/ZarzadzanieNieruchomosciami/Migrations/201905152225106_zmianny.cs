namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmianny : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlokMieszkalny", "DataOstProtokołuKontroli", c => c.DateTime(nullable: false));
            AddColumn("dbo.BlokMieszkalny", "DataKontroliSysOgrzewania", c => c.DateTime(nullable: false));

        }
        
        public override void Down()
        {
           
            DropColumn("dbo.BlokMieszkalny", "DataKontroliSysOgrzewania");
            DropColumn("dbo.BlokMieszkalny", "DataOstProtokołuKontroli");
        }
    }
}
