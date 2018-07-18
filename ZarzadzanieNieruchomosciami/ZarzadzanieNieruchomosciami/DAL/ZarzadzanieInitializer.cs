using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

//using ZarzadzanieNieruchomosciami.Migrations;

//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace ZarzadzanieNieruchomosciami.DAL
{
    public class ZarzadzanieInitializer : DropCreateDatabaseAlways<ZarzadzanieContext>//MigrateDatabaseToLatestVersion<ZarzadzanieContext, Migrations.Configuration>
    {


        protected override void Seed(ZarzadzanieContext context)
        {
            SeedZarzadzanieData(context);
            base.Seed(context);
        }

        private void SeedZarzadzanieData(ZarzadzanieContext context)
        {
            var bloki = new List<BlokMieszkalny>
            {
                new BlokMieszkalny { BlokMieszkalnyId = 1, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123 },
                new BlokMieszkalny { BlokMieszkalnyId = 2, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123 },
                new BlokMieszkalny { BlokMieszkalnyId = 3, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123 },
                new BlokMieszkalny { BlokMieszkalnyId = 4, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123 }

            };

            bloki.ForEach(k => context.BlokiMieszkalne.AddOrUpdate(k));
            context.SaveChanges();


            //reszta......

            var lokale = new List<LokalMieszkalny>
            {
                new LokalMieszkalny { LokalId = 1, BlokMieszkalnyId=1,NumerLokalu=1,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0},
               new LokalMieszkalny { LokalId = 2, BlokMieszkalnyId=2,NumerLokalu=5,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0},
               new LokalMieszkalny { LokalId = 3, BlokMieszkalnyId=2,NumerLokalu=9,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0},
            };

            lokale.ForEach(k => context.LokaleMieszkalne.AddOrUpdate(k));
            context.SaveChanges();





        }
    }
}