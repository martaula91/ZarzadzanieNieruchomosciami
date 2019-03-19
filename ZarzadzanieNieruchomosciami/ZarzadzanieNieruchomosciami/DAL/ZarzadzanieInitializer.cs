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




namespace ZarzadzanieNieruchomosciami.DAL
{
    public class ZarzadzanieInitializer : MigrateDatabaseToLatestVersion<ZarzadzanieContext, Migrations.Configuration>  //: MigrateDatabaseToLatestVersion<ZarzadzanieContext, Migrations.Configuration>
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
               new LokalMieszkalny { LokalID = 1, BlokMieszkalnyID=1,  Adres= "Lipowa 12", NumerLokalu=1,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
               new LokalMieszkalny { LokalID = 2, BlokMieszkalnyID=1, Adres= "Lipowa 12", NumerLokalu=2,PowierzchniaLokalu=54.52 ,LiczbaIzb=1, PowPiwnicy = 7.6, Pietro = 4, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
               new LokalMieszkalny { LokalID = 3, BlokMieszkalnyID=1,  Adres= "Lipowa 12", NumerLokalu=3,PowierzchniaLokalu=54.52 ,LiczbaIzb=2, PowPiwnicy = 7.6, Pietro = 2, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},

                new LokalMieszkalny { LokalID = 4, BlokMieszkalnyID=2,  Adres= "Cicha 2", NumerLokalu=1,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
               new LokalMieszkalny { LokalID = 5, BlokMieszkalnyID=2, Adres= "Cicha 2", NumerLokalu=2,PowierzchniaLokalu=54.52 ,LiczbaIzb=1, PowPiwnicy = 7.6, Pietro = 4, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
               new LokalMieszkalny { LokalID = 6, BlokMieszkalnyID=2,  Adres= "Cicha 2", NumerLokalu=3,PowierzchniaLokalu=54.52 ,LiczbaIzb=2, PowPiwnicy = 7.6, Pietro = 2, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},

               new LokalMieszkalny { LokalID = 7, BlokMieszkalnyID=3,  Adres= "Klonowa 8", NumerLokalu=1,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
               new LokalMieszkalny { LokalID = 8, BlokMieszkalnyID=3, Adres= "Klonowa 8", NumerLokalu=2,PowierzchniaLokalu=54.52 ,LiczbaIzb=1, PowPiwnicy = 7.6, Pietro = 4, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
               new LokalMieszkalny { LokalID = 9, BlokMieszkalnyID=3,  Adres= "Klonowa 8", NumerLokalu=3,PowierzchniaLokalu=54.52 ,LiczbaIzb=2, PowPiwnicy = 7.6, Pietro = 2, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},

               new LokalMieszkalny { LokalID = 10, BlokMieszkalnyID=4,  Adres= "Tuwima 10", NumerLokalu=1,PowierzchniaLokalu=54.52 ,LiczbaIzb=3, PowPiwnicy = 7.6, Pietro = 1, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
               new LokalMieszkalny { LokalID = 11, BlokMieszkalnyID=4, Adres= "Tuwima 10", NumerLokalu=2,PowierzchniaLokalu=54.52 ,LiczbaIzb=1, PowPiwnicy = 7.6, Pietro = 4, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
               new LokalMieszkalny { LokalID = 12, BlokMieszkalnyID=4,  Adres= "Tuwima 10", NumerLokalu=3,PowierzchniaLokalu=54.52 ,LiczbaIzb=2, PowPiwnicy = 7.6, Pietro = 2, LiczbaLokatorow = 1, LiczbaWodyZimnej = 7,  LiczbaWodyCieplej = 3.5},
            };

            lokale.ForEach(k => context.LokaleMieszkalne.AddOrUpdate(k));
            context.SaveChanges();

            var liczniki = new List<StanLicznikow>
            {
               new StanLicznikow { StanLicznikowID = 1, LokalMieszkalnyID = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(2019, 1, 10, 7, 0, 0)},
               new StanLicznikow { StanLicznikowID = 2, LokalMieszkalnyID = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(2019, 2, 7, 7, 0, 0)},
               new StanLicznikow { StanLicznikowID = 3, LokalMieszkalnyID = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(2019, 3, 9, 7, 0, 0)},
               new StanLicznikow { StanLicznikowID = 4, LokalMieszkalnyID = 1, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(2019, 4, 12, 7, 0, 0)},

               new StanLicznikow { StanLicznikowID = 5, LokalMieszkalnyID = 2, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(2019, 1, 10, 7, 0, 0)},
               new StanLicznikow { StanLicznikowID = 6, LokalMieszkalnyID = 2, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(2019, 2, 7, 7, 0, 0)},
               new StanLicznikow { StanLicznikowID = 7, LokalMieszkalnyID = 2, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(2019, 3, 9, 7, 0, 0)},
               new StanLicznikow { StanLicznikowID = 8, LokalMieszkalnyID = 2, WodaZimna = 0 , WodaCiepla = 0 , EnergiaElektryczna = 0 , Gaz=0, StanNaDzien = new DateTime(2019, 4, 12, 7, 0, 0)},

            };

            liczniki.ForEach(k => context.StanyLicznikow.AddOrUpdate(k));
            context.SaveChanges();

            var dokumenty = new List<Dokument>
            {
             new Dokument { DokumentID = 1,  BlokMieszkalnyId=1, Adres= "Lipowa 12", NazwaDokumentu = "Zarzadzenie nr 1/2019", TypDokumentu = "Zarzadzenie", AutorDokumentu = "Wspólnota bloku", NazwaPlikuDokumentu = "Z12018qwe.pdf", OpisDokumentu = "Dotyczące utrzymania porządku", DataDokumentu= new DateTime(2019, 1, 11, 7, 0, 0)},
             new Dokument { DokumentID = 2, BlokMieszkalnyId=1, Adres= "Lipowa 12", NazwaDokumentu = "Postanowienie nr 1/2019", TypDokumentu = "Postanowienie", AutorDokumentu = "firma zarzadzajaca", NazwaPlikuDokumentu = "Z12018qwe.pdf", OpisDokumentu = "Dotyczące budowy placu zabaw", DataDokumentu= new DateTime(2019, 1, 11, 7, 0, 0)},

             new Dokument { DokumentID = 3,  BlokMieszkalnyId=2, Adres= "Cicha 2", NazwaDokumentu = "Decyzja nr 1/2019", TypDokumentu = "Decyzja", AutorDokumentu = "Wspólnota bloku",  NazwaPlikuDokumentu = "Z12018qwe.pdf", OpisDokumentu = "W związku z wymianą drzwi wejsciwowych", DataDokumentu= new DateTime(2019, 1, 11, 7, 0, 0)},
             new Dokument { DokumentID = 4,  BlokMieszkalnyId=2, Adres= "Cicha 2", NazwaDokumentu = "Postanowienie nr 1/2019", TypDokumentu = "Postanowienie", AutorDokumentu = "Zarzad",  NazwaPlikuDokumentu = "Z12018qwe.pdf", OpisDokumentu = "Zmiana firmy sprzatajacej", DataDokumentu= new DateTime(2019, 1, 11, 7, 0, 0)},
             new Dokument { DokumentID = 5,  BlokMieszkalnyId=2, Adres= "Cicha 2", NazwaDokumentu = "Zarzadzenie nr 1/2019", TypDokumentu = "Zarzadzenie", AutorDokumentu = "firma zarzadzajaca",  NazwaPlikuDokumentu = "Z12018qwe.pdf", OpisDokumentu = "Naprawa dachu", DataDokumentu= new DateTime(2019, 1, 11, 7, 0, 0)},
            }; //DataDodania = 11-03-2018,

            dokumenty.ForEach(k => context.Dokumenty.AddOrUpdate(k));
            context.SaveChanges();

            var rozlicz = new List<Rozliczenie>
            {
            new Rozliczenie {RozliczenieId= 1, StawkaID=1, LokalID= 1, Nazwa="styczeń-2019", CentralneOgrzewanie= 110.97,   ZWiSCLicznik= 52.43, CWLicznik= 59.50, EnergiaElekCzescWspolna= 2.22, WywozSmieci= 9.00, KosztyAdministrowania= 41.06,KosztyObslugiBankUbezp= 5.55,FunduszRemontowy= 96.17,StanObecny= 212,OgolemDoZaplaty= 376, StanNaDzien = new DateTime(2019, 1, 1, 7, 0, 0)},
            new Rozliczenie {RozliczenieId= 2, StawkaID=1, LokalID= 1, Nazwa="luty-2019", CentralneOgrzewanie= 110.97,   ZWiSCLicznik= 52.43, CWLicznik= 59.50, EnergiaElekCzescWspolna= 2.22, WywozSmieci= 9.00, KosztyAdministrowania= 41.06,KosztyObslugiBankUbezp= 5.55,FunduszRemontowy= 96.17,StanObecny= 212,OgolemDoZaplaty= 376, StanNaDzien = new DateTime(2019, 2, 1, 7, 0, 0)},
            new Rozliczenie {RozliczenieId= 3, StawkaID=1, LokalID= 1, Nazwa="marzec-2019", CentralneOgrzewanie= 110.97,   ZWiSCLicznik= 52.43, CWLicznik= 59.50, EnergiaElekCzescWspolna= 2.22, WywozSmieci= 9.00, KosztyAdministrowania= 41.06,KosztyObslugiBankUbezp= 5.55,FunduszRemontowy= 96.17,StanObecny= 212,OgolemDoZaplaty= 376, StanNaDzien = new DateTime(2019, 3, 1, 7, 0, 0)},
            new Rozliczenie {RozliczenieId= 4, StawkaID=1, LokalID= 1, Nazwa="kwiecień-2019", CentralneOgrzewanie= 110.97,   ZWiSCLicznik= 52.43, CWLicznik= 59.50, EnergiaElekCzescWspolna= 2.22, WywozSmieci= 9.00, KosztyAdministrowania= 41.06,KosztyObslugiBankUbezp= 5.55,FunduszRemontowy= 96.17,StanObecny= 212,OgolemDoZaplaty= 376, StanNaDzien = new DateTime(2019, 4, 1, 7, 0, 0)},

            new Rozliczenie {RozliczenieId= 5, StawkaID=1, LokalID= 2, Nazwa="styczeń-2019", CentralneOgrzewanie= 110.97,   ZWiSCLicznik= 52.43, CWLicznik= 59.50, EnergiaElekCzescWspolna= 2.22, WywozSmieci= 9.00, KosztyAdministrowania= 41.06,KosztyObslugiBankUbezp= 5.55,FunduszRemontowy= 96.17,StanObecny= 212,OgolemDoZaplaty= 376, StanNaDzien = new DateTime(2019, 1, 1, 7, 0, 0)},
            new Rozliczenie {RozliczenieId= 6, StawkaID=1, LokalID= 2, Nazwa="luty-2019", CentralneOgrzewanie= 110.97,   ZWiSCLicznik= 52.43, CWLicznik= 59.50, EnergiaElekCzescWspolna= 2.22, WywozSmieci= 9.00, KosztyAdministrowania= 41.06,KosztyObslugiBankUbezp= 5.55,FunduszRemontowy= 96.17,StanObecny= 212,OgolemDoZaplaty= 376, StanNaDzien = new DateTime(2019, 2, 1, 7, 0, 0)},
            new Rozliczenie {RozliczenieId= 7, StawkaID=1, LokalID= 2, Nazwa="marzec-2019", CentralneOgrzewanie= 110.97,   ZWiSCLicznik= 52.43, CWLicznik= 59.50, EnergiaElekCzescWspolna= 2.22, WywozSmieci= 9.00, KosztyAdministrowania= 41.06,KosztyObslugiBankUbezp= 5.55,FunduszRemontowy= 96.17,StanObecny= 212,OgolemDoZaplaty= 376, StanNaDzien = new DateTime(2019, 3, 1, 7, 0, 0)},
            new Rozliczenie {RozliczenieId= 8, StawkaID=1, LokalID= 2, Nazwa="kwiecień-2019", CentralneOgrzewanie= 110.97,   ZWiSCLicznik= 52.43, CWLicznik= 59.50, EnergiaElekCzescWspolna= 2.22, WywozSmieci= 9.00, KosztyAdministrowania= 41.06,KosztyObslugiBankUbezp= 5.55,FunduszRemontowy= 96.17,StanObecny= 212,OgolemDoZaplaty= 376, StanNaDzien = new DateTime(2019, 4, 1, 7, 0, 0)},
            };

            rozlicz.ForEach(k => context.Rozliczenia.AddOrUpdate(k));
            context.SaveChanges();

            var stawka = new List<Stawka>
            {
           new Stawka {StawkaID= 1, Okres = "styczeń 2019", DataDodania = new DateTime(2019, 1, 11, 7, 0, 0),StawkaCentralneOgrzewanie= 3.00,   StawkaZWiSC= 7.49, StawkaCW= 17.00, StawkaEnergiaElekCzescWspolna= 0.06,StawkaWywozSmieci= 9.00,StawkaKosztyAdministrowania= 1.11,StawkaKosztyObslugiBankUbezp= 0.15,StawkaFunduszRemontowy= 2.60},

            };

            stawka.ForEach(k => context.Stawka.AddOrUpdate(k));
            context.SaveChanges();

            var informacja = new List<Informacja> //https://www.drazkiewicz.com/wiadomosci
            {
             new Informacja { InformacjaID = 1,  Tytul="Zakończono przeglądy techniczne 2018", Tresc ="Informujemy, że wszystkie zarządzane przez nas nieruchomości, przeszły obowiązkowe przeglądy techniczne. O wynikach przeglądów będziemy informować zarządy wspólnot oraz właścicieli na zebraniach. Dziękujemy inspektorom wykonującym przeglądy, oraz zarządom które uczestniczyły w przeglądach.",  DataDodania = new DateTime(2019, 1, 11, 7, 0, 0)}, //DataDodania =  new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0)
             new Informacja { InformacjaID = 2,  Tytul="Zbiórka elektrośmieci", Tresc ="Informujemy że w okresie od 3 października do 30 marca 2019 roku na ternie Białegostoku będzie przeprowadzona zbiórka elektrośmieci (np. zużyte pralki, lodówki, komputer, telefony komórkowe).",  DataDodania = new DateTime(2019, 1, 11, 7, 0, 0)},
             new Informacja { InformacjaID = 3,  Tytul="Płatności za pomocą kodów QR", Tresc ="Informujemy, że od roku 2019, na dokumentach rozliczeniowych (np rozliczenie roku 2018) które dostają właściciele mieszkań we wspólnotach mieszkaniowych, wprowadziliśmy kody QR, które pozwalają na szybką płatność przez zeskanowanie aplikacja mobilna banku w którym macie Państwo rachunek bankowy.",  DataDodania = new DateTime(2019, 1, 11, 7, 0, 0)},

            };

            //informacja.ForEach(k => context.Informacje.AddOrUpdate(k));
            //context.SaveChanges();

            var awaria = new List<Awaria>
            {
           new Awaria {AwariaID= 1, BlokMieszkalnyId= 1, Opis = "Skrzypia drzwi w klatce III", DataDodania = new DateTime(2019, 1, 11, 20, 55, 0), Status=Status.Nowe, Typ=Typ.uszkodzenia_budynku},
           new Awaria {AwariaID= 2, BlokMieszkalnyId= 1, Opis = "Niedomykanie okna na  klatce miedzy I a II piętrem", DataDodania = new DateTime(2019, 1, 16, 17, 46, 0), Status=Status.Nowe, Typ=Typ.uszkodzenia_budynku},
           new Awaria {AwariaID= 3, BlokMieszkalnyId= 1, Opis = "Pani sprzatajaca nie myje okien", DataDodania = new DateTime(2019, 2, 3, 9, 0, 0), Status=Status.Nowe, Typ=Typ.uwagi_opinie},
           new Awaria {AwariaID= 4, BlokMieszkalnyId= 1, Opis = "Graffiti na wejsciowej scianie bloku", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.uszkodzenia_budynku},
           new Awaria {AwariaID= 5, BlokMieszkalnyId= 1, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.uszkodzenia_budynku},
           new Awaria {AwariaID= 6, BlokMieszkalnyId= 1, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.awarie_mediow},
           new Awaria {AwariaID= 7, BlokMieszkalnyId= 1, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.awarie_mediow},
           new Awaria {AwariaID= 8, BlokMieszkalnyId= 1, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.awarie_mediow},
           new Awaria {AwariaID= 9, BlokMieszkalnyId= 1, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.inne},
           new Awaria {AwariaID= 10, BlokMieszkalnyId= 1, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.inne},
           new Awaria {AwariaID= 11, BlokMieszkalnyId= 1, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.otoczenie_budynku},

            new Awaria {AwariaID= 12, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.awarie_mediow},
            new Awaria {AwariaID= 13, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.awarie_mediow},
            new Awaria {AwariaID= 14, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.uszkodzenia_budynku},
            new Awaria {AwariaID= 15, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.uszkodzenia_budynku},
            new Awaria {AwariaID= 16, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.otoczenie_budynku},
            new Awaria {AwariaID= 17, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.otoczenie_budynku},
            new Awaria {AwariaID= 18, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.otoczenie_budynku},
            new Awaria {AwariaID= 19, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.otoczenie_budynku},
            new Awaria {AwariaID= 20, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.inne},
            new Awaria {AwariaID= 21, BlokMieszkalnyId= 2, Opis = "test", DataDodania = new DateTime(2019, 2, 21, 12, 10, 0), Status=Status.Nowe, Typ=Typ.uwagi_opinie},
            };

            awaria.ForEach(k => context.Awaria.AddOrUpdate(k));
            context.SaveChanges();


            var ksiegowosc = new List<Ksiegowosc>
            {
           new Ksiegowosc { KsiegowoscID = 1,  LokalMieszkalnyID=1, Nazwa= "Styczen-2019", OpisDokumentu=OpisDokumentu.Naliczenie, DataDodania= new DateTime(2019, 1, 11, 7, 0, 0), Wartosc = 125.25 },
           new Ksiegowosc { KsiegowoscID = 2,  LokalMieszkalnyID=1, Nazwa= "Styczen-2019", OpisDokumentu=OpisDokumentu.Wplata, DataDodania= new DateTime(2019, 1, 11, 7, 0, 0), Wartosc = 125.25 },
           new Ksiegowosc { KsiegowoscID = 3,  LokalMieszkalnyID=2, Nazwa= "Styczen-2019", OpisDokumentu=OpisDokumentu.Naliczenie, DataDodania= new DateTime(2019, 1, 11, 7, 0, 0), Wartosc = 125.25 },
           new Ksiegowosc { KsiegowoscID = 4,  LokalMieszkalnyID=2, Nazwa= "Styczen-2019", OpisDokumentu=OpisDokumentu.Naliczenie, DataDodania= new DateTime(2019, 1, 11, 7, 0, 0), Wartosc = 125.25 },
            };

            ksiegowosc.ForEach(k => context.Ksiegowosc.AddOrUpdate(k));
            context.SaveChanges();


            var glosowanie = new List<Glosowanie>
            {
          new Glosowanie { GlosowanieId=1, BlokMieszkalnyId = 1, NumerUchwaly="XYZ1", Nazwa= "spotkanie wspolnoty styczen-2019", DataUtworzeniaGlosowania = new DateTime(2019, 1, 11, 7, 0, 0), DataKoncaGlosowania = new DateTime(2019, 3, 11, 7, 0, 0), Pytanie1 = "Czy ma być remontowany plac zabaw?", Pytanie2="Wymiana stolarki okiennej?", Pytanie3="Czy kredyt na termomodernizacje?" },
          new Glosowanie { GlosowanieId=2, BlokMieszkalnyId = 1, NumerUchwaly="XXX1", Nazwa= "spotkanie wspolnoty luty-2019", DataUtworzeniaGlosowania = new DateTime(2019, 1, 11, 7, 0, 0), DataKoncaGlosowania = new DateTime(2019, 3, 11, 7, 0, 0)},
          new Glosowanie { GlosowanieId=3, BlokMieszkalnyId = 1, NumerUchwaly="XZZ1", Nazwa= "spotkanie wspolnoty marzec-2019", DataUtworzeniaGlosowania = new DateTime(2019, 1, 11, 7, 0, 0), DataKoncaGlosowania = new DateTime(2019, 3, 11, 7, 0, 0)},
            };

            glosowanie.ForEach(k => context.Glosowanie.AddOrUpdate(k));
            context.SaveChanges();


            var glos = new List<Glos>
            {
           new Glos { GlosId = 1,  GlosowanieId=1, DataOddaniaGlosu= new DateTime(2019, 1, 11, 7, 0, 0) , Odpowiedz1=Odpowiedz.Tak, Odpowiedz2=Odpowiedz.Tak, Odpowiedz3=Odpowiedz.Nie },
           new Glos { GlosId = 2,  GlosowanieId=1, DataOddaniaGlosu= new DateTime(2019, 1, 11, 7, 0, 0) , Odpowiedz1=Odpowiedz.Tak, Odpowiedz2=Odpowiedz.Tak, Odpowiedz3=Odpowiedz.Nie },
            };

            glos.ForEach(k => context.Glos.AddOrUpdate(k));
            context.SaveChanges();


            var pytanie = new List<Pytanie>
            {
           new Pytanie { PytanieId = 1,  GlosowanieId=1, TrescPytania= "Czy ma być remontowany plac zabaw?" }, // Odpowiedz=Odpowiedz.Tak
           new Pytanie { PytanieId = 2,  GlosowanieId=1, TrescPytania= "Wymiana stolarki okiennej?" },
           new Pytanie { PytanieId = 3,  GlosowanieId=1, TrescPytania= "Czy kredyt na termomodernizacje?" },
            };

            pytanie.ForEach(k => context.Pytanie.AddOrUpdate(k));
            context.SaveChanges();


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
            //var rolesForUser = userManager.GetRoles(user.Id);
            //if (!rolesForUser.Contains(role.Name))
            //{
            //    var result = userManager.AddToRole(user.Id, role.Name);
            //}
        }
    }
}