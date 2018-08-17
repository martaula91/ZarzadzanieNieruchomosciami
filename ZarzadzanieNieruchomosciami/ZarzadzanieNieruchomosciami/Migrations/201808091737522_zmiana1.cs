namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoria", "nazwaKategori", c => c.String());
            DropColumn("dbo.Kategoria", "NazwaKategoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoria", "NazwaKategoria", c => c.String());
            DropColumn("dbo.Kategoria", "nazwaKategori");
        }
    }
}
