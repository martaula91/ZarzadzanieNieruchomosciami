using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieNieruchomosciami.DAL;
using ZarzadzanieNieruchomosciami.ViewModels;
using ZarzadzanieNieruchomosciami.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;
using ZarzadzanieNieruchomosciami.Models.Enums;

namespace ZarzadzanieNieruchomosciami.Controllers
{
    public class ZarzadzanieController : Controller
    {

        private ZarzadzanieContext db = new ZarzadzanieContext();

        // GET: Zarzadzanie
        public ActionResult Index()
        {
            //var kategorieDostepne = db.Kategorie.ToList();

            //var vm = new StartViewModel()
            //{
            //    Kategoria = kategorieDostepne,

            //};
            //return View(vm); //vm




            var informacje = db.Informacje.ToList();
            return View(informacje);

            //return View();
        }


        // SZCZEGOLY LOKALU
        public ActionResult SzczegolyLokalu(int id)
        {
            var lokal = db.LokaleMieszkalne.Find(id);
            var name = User.Identity.Name;
            //logger.Info("Strona szczególy | " + kurs.TytulKursu + " | " + name);
            //return View(lokal);


            var vm = new LokalViewModels()
            {
                Lokal = lokal,
                BlokiMieszkalne = db.BlokiMieszkalne.ToList(),
            };

            return View(vm);
        }
        // SZCZEGOLY BLOKU MIESZKALNEGO
        public ActionResult SzczegolyBloku(int id)
        {
            var result = new WypisanieLokaliZBlokuViewModel();
            result.BlokiMieszkalne = db.BlokiMieszkalne.Find(id);
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Lokal = db.LokaleMieszkalne.Where(k => k.BlokMieszkalnyID == id).ToList();
            //result.Potwierdzenie = potwierdzenie;

            return View(result);





            //var blok = db.BlokiMieszkalne.Find(id);
            //var name = User.Identity.Name;
            //return View(blok);
        }

        // SZCZEGOLY DOKUMENTU
        public ActionResult SzczegolyDokumentu(int id)
        {
            var dok = db.Dokumenty.Find(id);
            var name = User.Identity.Name;
            //logger.Info("Strona szczególy | " + kurs.TytulKursu + " | " + name);
            //return View(lokal);


            return View(dok);
        }

        // SZCZEGOLY ROZLICZEN
        public ActionResult SzczegolyRozliczen(int id)
        {
            var roz = db.Rozliczenia.Find(id);
            var name = User.Identity.Name;
            //logger.Info("Strona szczególy | " + kurs.TytulKursu + " | " + name);
            //return View(lokal);


            return View(roz);
        }

        // SZCZEGOLY STANU LICZNIKOW
        public ActionResult SzczegolyLicznikow(int id)
        {
            var stan = db.StanyLicznikow.Find(id);
            var name = User.Identity.Name;
            //logger.Info("Strona szczególy | " + kurs.TytulKursu + " | " + name);
            //return View(lokal);


            return View(stan);
        }


        // SZCZEGOLY KSIEGOWOSCI
        public ActionResult SzczegolyKsiegowosci(int id)
        {
            var wplyw = db.Ksiegowosc.Find(id);
            var name = User.Identity.Name;
            
            //var vm = new LokalViewModels()
            //{
            //    Lokal = lokal,
            //    BlokiMieszkalne = db.BlokiMieszkalne.ToList(),
            //};

            return View(wplyw); //vm
        }

        // SZCZEGOLY glosowania
        public ActionResult SzczegolyGlosowania(int id)
        {
            var glos = db.Glosowanie.Find(id);
            var name = User.Identity.Name;

            //var vm = new LokalViewModels()
            //{
            //    Lokal = lokal,
            //    BlokiMieszkalne = db.BlokiMieszkalne.ToList(),
            //};

            return View(glos);
        }




        // LISTA ZGLOSZEN
        public ActionResult ListaZgloszen()
        {
            var name = User.Identity.Name;


            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            bool isEmployee = User.IsInRole("Employee");
            ViewBag.UserIsEmployee = isEmployee;

            IEnumerable<Awaria> zgloszeniaUzytkownika;

            // Dla administratora zwracamy wszystko
            if (isAdmin || isEmployee)
            {
                zgloszeniaUzytkownika = db.Awaria.OrderByDescending(o => o.DataDodania).ToArray();
            }                                    
            else
            {
                var userId = User.Identity.GetUserId();
                zgloszeniaUzytkownika = db.Awaria.Where(o => o.UserId == userId).OrderByDescending(o => o.DataDodania).ToArray();
            }                                                                  

            return View(zgloszeniaUzytkownika);
        }


        ///////////////////////// DODAJ AWARIE


        public ActionResult DodajAwarie(int? awariaID, bool? potwierdzenie)
        {
            Awaria awaria;

            if (awariaID.HasValue)
            {
                ViewBag.EditMode = true;
                awaria = db.Awaria.Find(awariaID);
            }
            else
            {
                ViewBag.EditMode = false;
                awaria = new Awaria();
            }

            var result = new EditAwariaViewModel();
            result.Budynek = db.BlokiMieszkalne.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Awaria = awaria;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        public ActionResult DodajAwarie(EditAwariaViewModel model, HttpPostedFileBase file)
        {
            if (model.Awaria.AwariaID > 0)
            {
                // modyfikacja awari
                db.Entry(model.Awaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajAwarie", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    model.Awaria.DataDodania = DateTime.Now;
                    model.Awaria.UserId = User.Identity.GetUserId();
                    db.Entry(model.Awaria).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("DodajAwarie", new { potwierdzenie = true });
                }
                else
                {
                    var kategorie = db.BlokiMieszkalne.ToList();
                    model.Budynek = kategorie;
                    return View(model);
                }
            }

        }


        ///////////////////////// ODDAJ GLOS


        public ActionResult OddajGlos(int glosowanieId)
        {
            var glosowanie = db.Glosowanie.Find(glosowanieId);
            var pytania = db.Pytanie.Where(p => p.GlosowanieId == glosowanieId).Select(p => new PytanieViewModel()
            {
                PytanieId = p.PytanieId,
                TrescPytania = p.TrescPytania, 
            }).ToList();

            var model = new OddajGlosViewModel();
            model.NumerUchwaly = glosowanie.NumerUchwaly;
            model.Nazwa = glosowanie.Nazwa;
            model.Pytania = pytania;


            return View(model);
        }

        [HttpPost]
        public ActionResult OddajGlos(OddajGlosViewModel model)
        {
            foreach (var pytanie in model.Pytania)
            {
                var glos = new Glos()
                {
                    PytanieId = pytanie.PytanieId,
                    UserId = User.Identity.GetUserId(),
                    Odpowiedz = pytanie.Odpowiedz,                    
                    DataOddaniaGlosu = DateTime.Now,
                };

                db.Glos.Add(glos);
            }

            db.SaveChanges();

            return RedirectToAction("StronyKategori", new { nazwa = "Glosowanie" });
        }

        ///////////////////////// DODAJ ODCZYT LICZNIKOW


        public ActionResult OdczytLicznikow(int? stanLicznikowID, bool? potwierdzenie)
        {
            StanLicznikow stanLicznikow;

            if (stanLicznikowID.HasValue)
            {
                ViewBag.EditMode = true;
                stanLicznikow = db.StanyLicznikow.Find(stanLicznikowID);
            }
            else
            {
                ViewBag.EditMode = false;
                stanLicznikow = new StanLicznikow();
            }

            var result = new EditLicznikViewModel();
            result.Lokal = db.LokaleMieszkalne.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.StanLicznikow = stanLicznikow;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        public ActionResult OdczytLicznikow(EditLicznikViewModel model, HttpPostedFileBase file)
        {
            if (model.StanLicznikow.StanLicznikowID > 0)
            {
                // modyfikacja awari
                db.Entry(model.StanLicznikow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OdczytLicznikow", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    model.StanLicznikow.LokalMieszkalnyID = (from u in db.Users
                                                             join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                                                             where u.UserName == User.Identity.Name
                                                             select l.LokalID).FirstOrDefault();

                    //model.StanLicznikow.StanNaDzien = DateTime.Now;
                    db.Entry(model.StanLicznikow).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("OdczytLicznikow", new { potwierdzenie = true });
                }
                else
                {
                   // var kategorie = db.LokaleMieszkalne.ToList();
                   /// model.Lokal = kategorie;
                    return View(model);
                }
            }

        }


        //[Authorize(Roles = "Admin")]
        //public ActionResult UkryjBudynek(int budynekID)
        //{
        //    var budynek = db.BlokiMieszkalne.Find(budynekID);
        //    budynek.Ukryty = true;
        //    db.SaveChanges();

        //    return RedirectToAction("DodajBudynek", new { potwierdzenie = true });
        //}

        //[Authorize(Roles = "Admin")]
        //public ActionResult PokazBudynek(int budynekID)
        //{
        //    var budynek = db.BlokiMieszkalne.Find(budynekID);
        //    budynek.Ukryty = false;
        //    db.SaveChanges();

        //    return RedirectToAction("DodajBudynek", new { potwierdzenie = true });
        //}





        /////////////////////////

   
            
            /// ZMIANA STANU AWARII
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public Status ZmianaStanuAwari(Awaria awaria)
        {
            Awaria awariaDoModyfikacji = db.Awaria.Find(awaria.AwariaID);
            awariaDoModyfikacji.Status = awaria.Status;
            db.SaveChanges();

            //if (zamowienieDoModyfikacji.StanZamowienia == StanZamowienia.Zrealizowane)
            //{
            //    this.mailService.WyslanieZamowienieZrealizowaneEmail(zamowienieDoModyfikacji);
            //}

            return awaria.Status;
        }

        ///////////////////////// 
        [ChildActionOnly]
      //  [OutputCache(Duration = 60000)]
        public ActionResult KategorieMenu()
        {
            // var kategorie = db.Kategorie.ToList();
            return PartialView("_KategorieMenu"); //, kategorie
        }

        public ActionResult StronyKategori(string nazwa)
        {
            //NOWE
            var name = User.Identity.Name;
            //LokalMieszkalny lokalmieszkalny;

            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            bool isEmployee = User.IsInRole("Employee");
            ViewBag.UserIsEmployee = isEmployee;
            //KONIEC

            if (nazwa == "Lokal")
            {
                var lokal = new List<LokalMieszkalny>();
                if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("User"))
                    {
                        lokal = (from u in db.Users
                                 join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                                 where u.UserName == User.Identity.Name
                                 select l).ToList();
                    }
                    else
                    {
                        lokal = db.LokaleMieszkalne.ToList();
                    }
                }

                return View(nazwa, lokal);
            }

            if (nazwa == "Budynek")
            {
                var blok = db.BlokiMieszkalne.ToList();
                return View(nazwa, blok);
            }

            //return View(nazwa);

            if (nazwa == "Dokumenty")
            {
                var dok = new List<Dokument>();
                if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("User"))
                    {
                        dok = (from u in db.Users
                               join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                               join b in db.BlokiMieszkalne on l.BlokMieszkalnyID equals b.BlokMieszkalnyId
                               join d in db.Dokumenty on b.BlokMieszkalnyId equals d.BlokMieszkalnyId
                               where u.UserName == User.Identity.Name
                               select d).ToList();
                    }
                    else
                    {
                        dok = db.Dokumenty.ToList();
                    }
                }

                return View(nazwa, dok);
            }
            if (nazwa == "Biblioteka")
            {

                return View(nazwa);
            }

            if (nazwa == "Rozliczenia")
            {
                var roz = new List<Rozliczenie>();
                if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("User"))
                    {
                        roz = (from u in db.Users
                               join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                               join r in db.Rozliczenia on l.LokalID equals r.LokalID
                               where u.UserName == User.Identity.Name
                               select r).ToList();
                    }
                    else
                    {
                        roz = db.Rozliczenia.ToList();
                    }
                }

                return View(nazwa, roz);
            }
            if (nazwa == "StanLicznikow")
            {
                var stan = new List<StanLicznikow>();
                if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("User"))
                    {
                        stan = (from u in db.Users
                                join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                                join r in db.StanyLicznikow on l.LokalID equals r.LokalMieszkalnyID
                                where u.UserName == User.Identity.Name
                                select r).ToList();
                    }
                    else
                    {
                        stan = db.StanyLicznikow.ToList();
                    }
                }
                //var stan = db.StanyLicznikow.ToList();
                return View(nazwa, stan);
            }
            if (nazwa == "Telefony")
            {
                return View(nazwa);
            }
            if (nazwa == "Awaria")
            {
                return View(nazwa);
            }
            if (nazwa == "ListaZgloszen")
            {
                return View(nazwa);
            }
            if (nazwa == "OdczytLicznikow")
            {
                return View(nazwa);
            }
            if (nazwa == "Ksiegowosc")
            {
                var model = new KsiegowoscViewModel();
                if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("User"))
                    {
                        var wplaty = (from u in db.Users
                                      join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                                      join k in db.Ksiegowosc on l.LokalID equals k.LokalMieszkalnyID
                                      where u.UserName == User.Identity.Name
                                      select k).ToList();

                        var saldo = (from u in db.Users
                                     join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                                     select l.Saldo).FirstOrDefault();

                        model.IsInUserRole = true;
                        model.Documents = wplaty;
                        model.Saldo = saldo;
                    }
                    else if (User.IsInRole("Admin") || User.IsInRole("Employee"))
                    {
                        var wplaty = db.Ksiegowosc.ToList();

                        model.IsInUserRole = false;
                        model.Documents = wplaty;
                    }
                }
                
                return View(nazwa, model);
            }
            if (nazwa == "Glosowanie")
            {
                var glos = new List<Glosowanie>();
                if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("User"))
                    {
                        glos = (from u in db.Users
                                join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                                join b in db.BlokiMieszkalne on l.BlokMieszkalnyID equals b.BlokMieszkalnyId
                                join g in db.Glosowanie on b.BlokMieszkalnyId equals g.BlokMieszkalnyId
                                where u.UserName == User.Identity.Name
                                select g).ToList();
                    }
                    else
                    {
                        glos = db.Glosowanie.ToList();
                    }
                }

                var glosowania = new List<GlosowanieExtendedModel>();
                var userId = User.Identity.GetUserId();
                foreach (var g in glos)
                {
                    var pytaniaIds = g.Pytania.Select(p => p.PytanieId).ToList();
                    var glosUser = db.Glos.Where(x => pytaniaIds.Contains(x.PytanieId) && x.UserId == userId).ToList();

                    var glosowanieDoDodania = new GlosowanieExtendedModel()
                    {
                        GlosowanieId = g.GlosowanieId,
                        BlokMieszkalnyId = g.BlokMieszkalnyId,
                        NumerUchwaly = g.NumerUchwaly,
                        Nazwa = g.Nazwa,
                        DataUtworzeniaGlosowania = g.DataUtworzeniaGlosowania,
                        DataKoncaGlosowania = g.DataKoncaGlosowania,
                        CzyMozeUserMozeGlosowac = g.DataKoncaGlosowania > DateTime.Now && !glosUser.Any(),
                        CzyZakonczone = g.DataKoncaGlosowania < DateTime.Now,
                    };

                    glosowania.Add(glosowanieDoDodania);
                }

                var model = new GlosowanieViewModel();
                model.Glosowania = glosowania;

                return View(nazwa, model);
            }

            if (nazwa == "Statystyka")
            {
                var model = new StatystykaViewModel();
                model.Awarie = (from a in db.Awaria
                                group a by a.Status into g
                                select new AwariaGroupedModel()
                                {
                                    Status = g.Key,
                                    Liczba = g.Count(),
                                }).ToList();
                model.AwarieLokal = (from a in db.Awaria
                                     join b in db.BlokiMieszkalne on a.BlokMieszkalnyId equals b.BlokMieszkalnyId
                                     group new { a, b } by b.Adres into g
                                     select new AwariaLokalGroupedModel()
                                     {
                                         Lokal = g.Key,
                                         Typ = g.Select(x => x.a.Typ).ToList()
                                     }).ToList();

                return View(nazwa, model);
            }

            if (nazwa == "Windykacja")
            {
                var model = new WindykacjaViewModel();
                model.WindykacjaItems = (from u in db.Users
                                         join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                                         where l.Saldo < 0
                                         select new WindykacjaItem
                                         {
                                             LocalAddress = l.Adres + " m. " + l.NumerLokalu,
                                             FullName = u.DaneUser.Imie + " " + u.DaneUser.Nazwisko,
                                             Address = u.DaneUser.Adres,
                                             Phone = u.DaneUser.Telefon,
                                             Saldo = l.Saldo
                                         }).ToList();

                return View(nazwa, model);
            }

            return View(nazwa);

        }

        public ActionResult WynikiGlosowania(int glosowanieId)
        {
            var glosowanie = db.Glosowanie.Find(glosowanieId);
            var pytaniaIds = glosowanie.Pytania.Select(p => p.PytanieId).ToList();
            var glosy = db.Glos.Where(x => pytaniaIds.Contains(x.PytanieId)).ToList();

            var pytania = new List<PytanieWynikiViewModel>();

            foreach(var p in glosowanie.Pytania)
            {
                var pytanie = new PytanieWynikiViewModel();
                pytanie.PytanieId = p.PytanieId;
                pytanie.TrescPytania = p.TrescPytania;
                var odpowiedzi = Enum.GetValues(typeof(EnumOdpowiedz)).Cast<EnumOdpowiedz>().ToList();
                foreach(var odp in odpowiedzi)
                {
                    pytanie.Odpowiedzi.Add(odp.ToString(), glosy.Count(x => x.PytanieId == p.PytanieId && x.Odpowiedz == odp));
                }
                pytania.Add(pytanie);
            }

            var model = new WynikGlosowaniaViewModel();
            model.NumerUchwaly = glosowanie.NumerUchwaly;
            model.Nazwa = glosowanie.Nazwa;
            model.Pytania = pytania;

            return View(model);
        }

        /////////////////////////////
        public ActionResult BudynkiPodpowiedzi(string term)
        {
            var budynek = db.BlokiMieszkalne.Where(a => !a.Ukryty && a.Adres.ToLower().Contains(term.ToLower()))
                        .Take(5).Select(a => new { label = a.Adres });

            return Json(budynek, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RozliczenieLokalu(int id)
        {
            var roz = new List<Rozliczenie>();

                         roz = (from l in db.LokaleMieszkalne 
                                join r in db.Rozliczenia on l.LokalID equals r.LokalID
                                where r.LokalID == id
                                select r).ToList();

            return View("Rozliczenia", roz);
        }

        public ActionResult KsiegowoscLokalu(int id)
        {
            var model = new KsiegowoscViewModel();

            var wplaty = (from l in db.LokaleMieszkalne
                          join k in db.Ksiegowosc on l.LokalID equals k.LokalMieszkalnyID
                          where k.LokalMieszkalnyID == id
                          select k).ToList();

            model.Documents = wplaty;
            model.IsInUserRole = false;

            return View("Ksiegowosc", model);
       }

        public ActionResult LicznikiLokalu(int id)
        {
            var stan = new List<StanLicznikow>();

            stan = (from l in db.LokaleMieszkalne
                   join s in db.StanyLicznikow on l.LokalID equals s.LokalMieszkalnyID
                    where s.LokalMieszkalnyID == id
                   select s).ToList();

            return View("StanLicznikow", stan);
        }

        public ActionResult DokumentyBudynku(int id)
        {
            var dok = new List<Dokument>();

            dok = (from b in db.BlokiMieszkalne
                   join d in db.Dokumenty on b.BlokMieszkalnyId equals d.BlokMieszkalnyId
                   where d.BlokMieszkalnyId == id
                   select d).ToList();

            return View("Dokumenty", dok);
        }

        public ActionResult Wlasciciel(int id)
        {
            var name = User.Identity.Name;
            //var osoba = db.Users.Find(id);

            var osoba = (from u in db.Users
                         join l in db.LokaleMieszkalne on u.DaneUser.LokalId equals l.LokalID
                         where u.DaneUser.LokalId == id
                         select u).SingleOrDefault();

            return View("SzczegolyOsoby", osoba);
        }

        public ActionResult GlosowaniaBudynku(int id)
        {
            var glosy = new List<Glosowanie>();

            glosy = (from b in db.BlokiMieszkalne 
                     join g in db.Glosowanie on b.BlokMieszkalnyId equals g.BlokMieszkalnyId
                     where g.BlokMieszkalnyId == id
                     select g).ToList();

            return View("Glosowanie", glosy);
        }

    }
}