using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;
using ZarzadzanieNieruchomosciami.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

//using ZarzadzanieNieruchomosciami.Migrations;

//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace ZarzadzanieNieruchomosciami.DAL
{
    public class ZarzadzanieInitializer : MigrateDatabaseToLatestVersion<ZarzadzanieContext, Migrations.Configuration>
    {
        private static object dateNow;

        public static void SeedZarzadzanieData(ZarzadzanieContext context)
        {
            DateTime dateNow = DateTime.Now; 

            var kategoria = new List<Dzial>
            {
                new Dzial { KatID = 1, NazwaKat="Lokale"},
                new Dzial { KatID = 2, NazwaKat="Bloki"},
                new Dzial { KatID = 3, NazwaKat="Dokumenty"},
                new Dzial { KatID = 4, NazwaKat="Mieszkańcy"},

                new Dzial { KatID = 5, NazwaKat="Rachunki"},
                new Dzial { KatID = 6, NazwaKat="Głosowanie"},
                new Dzial { KatID = 7, NazwaKat="Tablica Informacyjna"},
                new Dzial { KatID = 8, NazwaKat="Zgłoszenia"},

            };

            kategoria.ForEach(m => context.Kategorie.AddOrUpdate(m));
            context.SaveChanges();

            var bloki = new List<BlokMieszkalny>
            {
                new BlokMieszkalny { BlokMieszkalnyId = 1, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, Adres= "Lipowa 12", PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123,  },
                new BlokMieszkalny { BlokMieszkalnyId = 2, Ulica = "Cicha", NumerBlokuMieszkalnego = 2, Adres= "Cicha 2",PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123, },
                new BlokMieszkalny { BlokMieszkalnyId = 3, Ulica = "Klonowa", NumerBlokuMieszkalnego = 8, Adres= "Klonowa 8",PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123,  },
                new BlokMieszkalny { BlokMieszkalnyId = 4, Ulica = "Tuwima", NumerBlokuMieszkalnego = 10, Adres= "Tuwima 10", PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 12,  }

            };

            bloki.ForEach(k => context.BlokiMieszkalne.AddOrUpdate(k));
            context.SaveChanges();


            //reszta......

            var lokale = new List<LokalMieszkalny>
            {
               new LokalMieszkalny { LokalID = 1, BlokMieszkalnyID=1,  Adres= "Lipowa 12", NumerLokalu=1,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1},
               new LokalMieszkalny { LokalID = 2, BlokMieszkalnyID=2, Adres= "Cicha 2", NumerLokalu=5,PowierzchniaLokalu=54.52 ,LiczbaIzb=1, PowPiwnicy = 7.6, Pietro = 4},
               new LokalMieszkalny { LokalID = 3, BlokMieszkalnyID=2,  Adres= "Cicha 2", NumerLokalu=9,PowierzchniaLokalu=54.52 ,LiczbaIzb=2, PowPiwnicy = 7.6, Pietro = 2},
            };

            lokale.ForEach(k => context.LokaleMieszkalne.AddOrUpdate(k));
            context.SaveChanges();

            var liczniki = new List<StanLicznikow>
            {
               new StanLicznikow { StanLicznikowID = 1, LokalMieszkalnyID = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0)},
               new StanLicznikow { StanLicznikowID = 2, LokalMieszkalnyID = 2, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0)},

            };

            liczniki.ForEach(k => context.StanyLicznikow.AddOrUpdate(k));
            context.SaveChanges();

            var dokumenty = new List<Dokument>
            {
             new Dokument { DokumentID = 1,  BudynekID=1, Adres= "Lipowa 12", NazwaDokumentu = "Zarzadzenie nr 1/2018", TypDokumentu = "Zarzadzenie", AutorDokumentu = "Wspólnota bloku", NazwaPlikuDokumentu = "Z1/2018qwe", OpisDokumentu = "Dotyczące utrzymania porządku", DataDokumentu= new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0)},
             new Dokument { DokumentID = 2, BudynekID=1, Adres= "Lipowa 12", NazwaDokumentu = "Postanowienie nr 1/2018", TypDokumentu = "Postanowienie", AutorDokumentu = "firma zarzadzajaca", NazwaPlikuDokumentu = "Z5/2018qwe", OpisDokumentu = "Dotyczące budowy placu zabaw", DataDokumentu= new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0)},
             new Dokument { DokumentID = 3,  BudynekID=1, Adres= "Lipowa 12", NazwaDokumentu = "Decyzja nr 1/2018", TypDokumentu = "Decyzja", AutorDokumentu = "Wspólnota bloku",  NazwaPlikuDokumentu = "Z8/2018qwe", OpisDokumentu = "W związku z wymianą drzwi wejsciwowych", DataDokumentu= new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0)},
             new Dokument { DokumentID = 4,  BudynekID=1, Adres= "Lipowa 12", NazwaDokumentu = "Postanowienie nr 1/2018", TypDokumentu = "Postanowienie", AutorDokumentu = "Zarzad",  NazwaPlikuDokumentu = "Z9/2018qwe", OpisDokumentu = "Zmiana firmy sprzatajacej", DataDokumentu= new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0)},
             new Dokument { DokumentID = 5,  BudynekID=1, Adres= "Lipowa 12", NazwaDokumentu = "Zarzadzenie nr 1/2018", TypDokumentu = "Zarzadzenie", AutorDokumentu = "firma zarzadzajaca",  NazwaPlikuDokumentu = "Z2/2018qwe", OpisDokumentu = "Naprawa dachu", DataDokumentu= new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0)},
            }; //DataDodania = 11-03-2018,

            dokumenty.ForEach(k => context.Dokumenty.AddOrUpdate(k));
            context.SaveChanges();

            var rozlicz = new List<Rozliczenie>
            {
             new Rozliczenie {RozliczenieId= 1, CentralneOgrzewanie= 1,StawkaCentralneOgrzewanie= 1,    ZWiSCLicznik= 1,StawkaZWiSC= 1, CWLicznik= 1,StawkaCW= 1, EnergiaElekCzescWspolna= 1,StawkaEnergiaElekCzescWspolna= 1,WywozSmieci= 1,StawkaWywozSmieci= 1,KosztyAdministrowania= 1,StawkaKosztyAdministrowania= 1,KosztyObslugiBankUbezp= 1,StawkaKosztyObslugiBankUbezp= 1,FunduszRemontowy= 1,StawkaFunduszRemontowy= 1,StanObecny= 212,OgolemDoZaplaty= 376},
            
            };

            rozlicz.ForEach(k => context.Rozliczenia.AddOrUpdate(k));
            context.SaveChanges();


  //????????????????????dziala czy          
  /*
            var wlasnosc = new List<Wlasnosc>
            {
             new Wlasnosc {WlasnoscId = 1, UserId="2e1cfb82-8c73-44d9-a4d4-4b5ce42a7a88", Komentarz = "lorem ipsum"},

            };

            wlasnosc.ForEach(k => context.Wlasnosci.AddOrUpdate(k));
            context.SaveChanges();

*/

            var pozycjeWlasnosci = new List<PozycjaWlasnosci>
            {
             new PozycjaWlasnosci {PozycjaWlasnosciId = 1, WlasnoscID= 1, LokalId= 1, LiczbaWlascicieli= 1, Komentarz = "Lokal wlasnosciowy, ubezpieczony"},

            };

            pozycjeWlasnosci.ForEach(k => context.PozycjeWlasnosci.AddOrUpdate(k));
            context.SaveChanges();

        }

        public static void SeedUzytkownicy(ZarzadzanieContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@admin.pl";
            const string password = "Password1!";
            const string roleName = "Admin";
            const string userName = "Admin";

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = userName, Email = name, DaneUser = new DaneUser() };
                var result = userManager.Create(user, password);
            }

            // utworzenie roli Admin jeśli nie istnieje 
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            // dodanie uzytkownika do roli Admin jesli juz nie jest w roli
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}