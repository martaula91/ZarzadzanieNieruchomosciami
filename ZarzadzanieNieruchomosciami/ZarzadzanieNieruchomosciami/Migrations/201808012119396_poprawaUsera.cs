namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawaUsera : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DaneUzytkownika", "KategoriaId", "dbo.Kategoria");
            DropForeignKey("dbo.AspNetUsers", "DaneUzytkownika_UzytkownikId", "dbo.DaneUzytkownika");
            DropIndex("dbo.DaneUzytkownika", new[] { "KategoriaId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "DaneUzytkownika_UzytkownikId", newName: "DaneUzytkownika_KategoriaId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_DaneUzytkownika_UzytkownikId", newName: "IX_DaneUzytkownika_KategoriaId");
            DropPrimaryKey("dbo.DaneUzytkownika");
            AddColumn("dbo.DaneUzytkownika", "Kategoria_KategoriaId", c => c.Int());
            AlterColumn("dbo.DaneUzytkownika", "KategoriaId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DaneUzytkownika", "KategoriaId");
            CreateIndex("dbo.DaneUzytkownika", "Kategoria_KategoriaId");
            AddForeignKey("dbo.DaneUzytkownika", "Kategoria_KategoriaId", "dbo.Kategoria", "KategoriaId");
            AddForeignKey("dbo.AspNetUsers", "DaneUzytkownika_KategoriaId", "dbo.DaneUzytkownika", "KategoriaId");
            DropColumn("dbo.DaneUzytkownika", "UzytkownikId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DaneUzytkownika", "UzytkownikId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AspNetUsers", "DaneUzytkownika_KategoriaId", "dbo.DaneUzytkownika");
            DropForeignKey("dbo.DaneUzytkownika", "Kategoria_KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.DaneUzytkownika", new[] { "Kategoria_KategoriaId" });
            DropPrimaryKey("dbo.DaneUzytkownika");
            AlterColumn("dbo.DaneUzytkownika", "KategoriaId", c => c.Int(nullable: false));
            DropColumn("dbo.DaneUzytkownika", "Kategoria_KategoriaId");
            AddPrimaryKey("dbo.DaneUzytkownika", "UzytkownikId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_DaneUzytkownika_KategoriaId", newName: "IX_DaneUzytkownika_UzytkownikId");
            RenameColumn(table: "dbo.AspNetUsers", name: "DaneUzytkownika_KategoriaId", newName: "DaneUzytkownika_UzytkownikId");
            CreateIndex("dbo.DaneUzytkownika", "KategoriaId");
            AddForeignKey("dbo.AspNetUsers", "DaneUzytkownika_UzytkownikId", "dbo.DaneUzytkownika", "UzytkownikId");
            AddForeignKey("dbo.DaneUzytkownika", "KategoriaId", "dbo.Kategoria", "KategoriaId", cascadeDelete: true);
        }
    }
}
