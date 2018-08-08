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
    public class ZarzadzanieInitializer : MigrateDatabaseToLatestVersion<ZarzadzanieContext, Migrations.Configuration>
    {


       

        public static void SeedZarzadzanieData(ZarzadzanieContext context)
        {

            var kategoria = new List<Kategoria>
            {
                new Kategoria { KategoriaId = 1, nazwaKategori="Lokale"},
                new Kategoria { KategoriaId = 2, nazwaKategori="Bloki"},
                new Kategoria { KategoriaId = 3, nazwaKategori="Dokumenty"},
                new Kategoria { KategoriaId = 4, nazwaKategori="Mieszkańcy"},

                new Kategoria { KategoriaId = 5, nazwaKategori="Rachunki"},
                new Kategoria { KategoriaId = 6, nazwaKategori="Głosowanie"},
                new Kategoria { KategoriaId = 7, nazwaKategori="Tablica Informacyjna"},
                new Kategoria { KategoriaId = 8, nazwaKategori="Zgłoszenia"},

            };

            kategoria.ForEach(m => context.Kategorie.AddOrUpdate(m));
            context.SaveChanges();

            var bloki = new List<BlokMieszkalny>
            {
                new BlokMieszkalny { BlokMieszkalnyId = 1, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123, KategoriaId = 2 },
                new BlokMieszkalny { BlokMieszkalnyId = 2, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123, KategoriaId = 2 },
                new BlokMieszkalny { BlokMieszkalnyId = 3, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123, KategoriaId = 2 },
                new BlokMieszkalny { BlokMieszkalnyId = 4, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 12, KategoriaId = 2 }

            };

            bloki.ForEach(k => context.BlokiMieszkalne.AddOrUpdate(k));
            context.SaveChanges();


            //reszta......

            var lokale = new List<LokalMieszkalny>
            {
               new LokalMieszkalny { LokalId = 1, BlokMieszkalnyId=1,NumerLokalu=1,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, KategoriaId = 1},
               new LokalMieszkalny { LokalId = 2, BlokMieszkalnyId=2,NumerLokalu=5,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, KategoriaId = 1},
               new LokalMieszkalny { LokalId = 3, BlokMieszkalnyId=2,NumerLokalu=9,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, KategoriaId = 1},
            };

            lokale.ForEach(k => context.LokaleMieszkalne.AddOrUpdate(k));
            context.SaveChanges();

            var dokumenty = new List<Dokument>
            {
             new Dokument { DokumentID = 1, NazwaDokumentu = "Zarzadzenie nr 1/2018", TypDokumentu = "Zarzadzenie", AutorDokumentu = "Wspólnota bloku", NazwaPlikuDokumentu = "Z1/2018qwe", OpisDokumentu = "Dotyczące utrzymania porządku", KategoriaId = 3},
             new Dokument { DokumentID = 2, NazwaDokumentu = "Postanowienie nr 1/2018", TypDokumentu = "Postanowienie", AutorDokumentu = "firma zarzadzajaca", NazwaPlikuDokumentu = "Z5/2018qwe", OpisDokumentu = "Dotyczące budowy placu zabaw", KategoriaId = 3},
             new Dokument { DokumentID = 3, NazwaDokumentu = "Decyzja nr 1/2018", TypDokumentu = "Decyzja", AutorDokumentu = "Wspólnota bloku",  NazwaPlikuDokumentu = "Z8/2018qwe", OpisDokumentu = "W związku z wymianą drzwi wejsciwowych", KategoriaId = 3},
             new Dokument { DokumentID = 4, NazwaDokumentu = "Postanowienie nr 1/2018", TypDokumentu = "Postanowienie", AutorDokumentu = "Zarzad",  NazwaPlikuDokumentu = "Z9/2018qwe", OpisDokumentu = "Zmiana firmy sprzatajacej", KategoriaId = 3},
             new Dokument { DokumentID = 5, NazwaDokumentu = "Zarzadzenie nr 1/2018", TypDokumentu = "Zarzadzenie", AutorDokumentu = "firma zarzadzajaca",  NazwaPlikuDokumentu = "Z2/2018qwe", OpisDokumentu = "Naprawa dachu", KategoriaId = 3},
            }; //DataDodania = 11-03-2018,

            dokumenty.ForEach(k => context.Dokumenty.AddOrUpdate(k));
            context.SaveChanges();

            
           


            



        }
    }
}