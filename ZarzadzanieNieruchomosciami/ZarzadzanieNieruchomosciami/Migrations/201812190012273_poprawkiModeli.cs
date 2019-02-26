namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawkiModeli : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LokalMieszkalny", new[] { "BlokMieszkalnyId" });
            DropIndex("dbo.StanLicznikow", new[] { "LokalMieszkalny_LokalId" });
            AddColumn("dbo.Dokument", "BudynekID", c => c.Int(nullable: false));
            //AddColumn("dbo.Dokument", "DataDokumentu", c => c.DateTime(nullable: false));
            AddColumn("dbo.Dokument", "BlokMieszkalny_BlokMieszkalnyId", c => c.Int());
            //AddColumn("dbo.StanLicznikow", "StanNaDzien", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BlokMieszkalny", "PowierzchniaUzytkowa", c => c.Double(nullable: false));
            AlterColumn("dbo.BlokMieszkalny", "PowDzialki", c => c.Double(nullable: false));
            CreateIndex("dbo.Dokument", "BlokMieszkalny_BlokMieszkalnyId");
            CreateIndex("dbo.LokalMieszkalny", "BlokMieszkalnyID");
            CreateIndex("dbo.StanLicznikow", "LokalMieszkalny_LokalID");
            AddForeignKey("dbo.Dokument", "BlokMieszkalny_BlokMieszkalnyId", "dbo.BlokMieszkalny", "BlokMieszkalnyId");
            //DropColumn("dbo.BlokMieszkalny", "KategoriaId");
           // DropColumn("dbo.Dokument", "KategoriaId");
           // DropColumn("dbo.LokalMieszkalny", "KategoriaId");
        }
        
        public override void Down()
        {
           // AddColumn("dbo.LokalMieszkalny", "KategoriaId", c => c.Int(nullable: false));
           // AddColumn("dbo.Dokument", "KategoriaId", c => c.Int(nullable: false));
            //AddColumn("dbo.BlokMieszkalny", "KategoriaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Dokument", "BlokMieszkalny_BlokMieszkalnyId", "dbo.BlokMieszkalny");
            DropIndex("dbo.StanLicznikow", new[] { "LokalMieszkalny_LokalID" });
            DropIndex("dbo.LokalMieszkalny", new[] { "BlokMieszkalnyID" });
            DropIndex("dbo.Dokument", new[] { "BlokMieszkalny_BlokMieszkalnyId" });
            AlterColumn("dbo.BlokMieszkalny", "PowDzialki", c => c.Int(nullable: false));
            AlterColumn("dbo.BlokMieszkalny", "PowierzchniaUzytkowa", c => c.Int(nullable: false));
           // DropColumn("dbo.StanLicznikow", "StanNaDzien");
            DropColumn("dbo.Dokument", "BlokMieszkalny_BlokMieszkalnyId");
           // DropColumn("dbo.Dokument", "DataDokumentu");
            DropColumn("dbo.Dokument", "BudynekID");
            CreateIndex("dbo.StanLicznikow", "LokalMieszkalny_LokalId");
            CreateIndex("dbo.LokalMieszkalny", "BlokMieszkalnyId");
        }
    }
}
