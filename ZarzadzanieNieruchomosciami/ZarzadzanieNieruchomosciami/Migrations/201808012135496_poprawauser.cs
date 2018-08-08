namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawauser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DaneUzytkownika_KategoriaId", "dbo.DaneUzytkownika");
            RenameColumn(table: "dbo.AspNetUsers", name: "DaneUzytkownika_KategoriaId", newName: "DaneUzytkownika_UzytkownikId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_DaneUzytkownika_KategoriaId", newName: "IX_DaneUzytkownika_UzytkownikId");
            DropPrimaryKey("dbo.DaneUzytkownika");
            AddColumn("dbo.DaneUzytkownika", "UzytkownikId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DaneUzytkownika", "UzytkownikId");
            AddForeignKey("dbo.AspNetUsers", "DaneUzytkownika_UzytkownikId", "dbo.DaneUzytkownika", "UzytkownikId");
            DropColumn("dbo.DaneUzytkownika", "KategoriaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DaneUzytkownika", "KategoriaId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AspNetUsers", "DaneUzytkownika_UzytkownikId", "dbo.DaneUzytkownika");
            DropPrimaryKey("dbo.DaneUzytkownika");
            DropColumn("dbo.DaneUzytkownika", "UzytkownikId");
            AddPrimaryKey("dbo.DaneUzytkownika", "KategoriaId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_DaneUzytkownika_UzytkownikId", newName: "IX_DaneUzytkownika_KategoriaId");
            RenameColumn(table: "dbo.AspNetUsers", name: "DaneUzytkownika_UzytkownikId", newName: "DaneUzytkownika_KategoriaId");
            AddForeignKey("dbo.AspNetUsers", "DaneUzytkownika_KategoriaId", "dbo.DaneUzytkownika", "KategoriaId");
        }
    }
}
