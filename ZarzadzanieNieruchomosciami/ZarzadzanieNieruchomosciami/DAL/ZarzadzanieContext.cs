namespace ZarzadzanieNieruchomosciami.DAL
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using ZarzadzanieNieruchomosciami.Models;

    public class ZarzadzanieContext : IdentityDbContext<ApplicationUser>
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

        public static ZarzadzanieContext Create()
        {
            return new ZarzadzanieContext();
        }


        public virtual DbSet<LokalMieszkalny> LokaleMieszkalne { get; set; }
        public virtual DbSet<BlokMieszkalny> BlokiMieszkalne { get; set; }
        public virtual DbSet<Dokument> Dokumenty { get; set; }
        public virtual DbSet<StanLicznikow> StanyLicznikow { get; set; }
        public virtual DbSet<Dzial> Kategorie { get; set; }
        public virtual DbSet<Stawka> Stawka { get; set; }
        public virtual DbSet<Rozliczenie> Rozliczenia { get; set; }
        public virtual DbSet<Informacja> Informacje { get; set; }
        public virtual DbSet<Glosowanie> Glosowanie { get; set; }
        public virtual DbSet<Pytanie> Pytanie { get; set; }

        public DbSet<PozycjaWlasnosci> PozycjeWlasnosci { get; set; }
        public DbSet<Awaria> Awaria { get; set; }
        public virtual DbSet<Ksiegowosc> Ksiegowosc { get; set; }
        // public virtual DbSet<AspNetUsers> DaneUsera { get; set; }
        //public virtual DbSet<IdentityUser> Identity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Wy��cza konwencj�, kt�ra automatycznie tworzy liczb� mnog� dla nazw tabel w bazie danych
            // Zamiast Kategorie zosta�aby stworzona tabela o nazwie Kategories
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