namespace ZarzadzanieNieruchomosciami.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZarzadzanieNieruchomosciami.DAL;

    public sealed class Configuration : DbMigrationsConfiguration<ZarzadzanieNieruchomosciami.DAL.ZarzadzanieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ZarzadzanieNieruchomosciami.DAL.ZarzadzanieContext";
        }

        protected override void Seed(ZarzadzanieNieruchomosciami.DAL.ZarzadzanieContext context)
        {
            ZarzadzanieInitializer.SeedZarzadzanieData(context);
            ZarzadzanieInitializer.SeedUzytkownicy(context);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
