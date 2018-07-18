namespace ZarzadzanieNieruchomosciami.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using ZarzadzanieNieruchomosciami.Models;

    public class ZarzadzanieContext : DbContext
    {
        // Your context has been configured to use a 'ZarzadzanieContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ZarzadzanieNieruchomosciami.DAL.ZarzadzanieContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ZarzadzanieContext' 
        // connection string in the application configuration file.

        public ZarzadzanieContext() : base("name=ZarzadzanieContext")
        {
        }

        static ZarzadzanieContext()
            {
            Database.SetInitializer<ZarzadzanieContext>(new ZarzadzanieInitializer());
            }

        public DbSet<LokalMieszkalny> LokaleMieszkalne { get; set; }
        public DbSet<BlokMieszkalny> BlokiMieszkalne { get; set; }
        public DbSet<Dokument> Dokumenty { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Wy³¹cza konwencjê, która automatycznie tworzy liczbê mnog¹ dla nazw tabel w bazie danych
            // Zamiast Kategorie zosta³aby stworzona tabela o nazwie Kategories
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}