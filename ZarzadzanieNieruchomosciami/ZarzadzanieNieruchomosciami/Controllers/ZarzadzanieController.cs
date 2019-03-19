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

            IEnumerable<Awaria> zgloszeniaUzytkownika;

            // Dla administratora zwracamy wszystkie zamowienia
            if (isAdmin)
            {
                zgloszeniaUzytkownika = db.Awaria.OrderByDescending(o => o.DataDodania).ToArray();
            }                                      //Include("PozycjeZamowienia").
            else
            {
                var userId = User.Identity.GetUserId();
                zgloszeniaUzytkownika = db.Awaria.Where(o => o.UserId == userId).OrderByDescending(o => o.DataDodania).ToArray();
            }                                                                   //Include("PozycjeZamowienia").

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


        public ActionResult OddajGlos(int? glosId, bool? potwierdzenie)
        {
            Glos glos;

            if (glosId.HasValue)
            {
                ViewBag.EditMode = true;
                glos = db.Glos.Find(glosId);
            }
            else
            {
                ViewBag.EditMode = false;
                glos = new Glos();
            }

            var result = new OddajGlosViewModel();
            result.Glosowanie = db.Glosowanie.ToList();
            result.Glos = glos;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        public ActionResult OddajGlos(OddajGlosViewModel model, HttpPostedFileBase file)
        {
            if (model.Glos.GlosId > 0)
            {
                // modyfikacja awari
                db.Entry(model.Glos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OddajGlos", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    model.Glos.DataOddaniaGlosu = DateTime.Now;
                    db.Entry(model.Glos).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("OddajGlos", new { potwierdzenie = true });
                }
                else
                {
                    //var kategorie = db.Glos.ToList();
                    //model.Glos = kategorie;
                    return View(model);
                    
                }
            }

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
                    //model.StanLicznikow.StanNaDzien = DateTime.Now;
                    db.Entry(model.Lokal).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("OdczytLicznikow", new { potwierdzenie = true });
                }
                else
                {
                    var kategorie = db.LokaleMieszkalne.ToList();
                    model.Lokal = kategorie;
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
        [Authorize(Roles = "Admin")]
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
        [OutputCache(Duration = 60000)]
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
            //KONIEC

            if (nazwa == "Lokal")
            {

                var lokal = db.LokaleMieszkalne.ToList();
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
                var dok = db.Dokumenty.ToList();
                return View(nazwa, dok);
            }
            if (nazwa == "Biblioteka")
            {

                return View(nazwa);
            }

            if (nazwa == "Rozliczenia")
            {
                var roz = db.Rozliczenia.ToList();
                return View(nazwa, roz);
            }
            if (nazwa == "StanLicznikow")
            {
                var stan = db.StanyLicznikow.ToList();
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
                var wplaty = db.Ksiegowosc.ToList();
                return View(nazwa, wplaty);
            }
            if (nazwa == "Glosowanie")
            {

                var glos = db.Glosowanie.ToList();
                return View(nazwa, glos);

            }

            if (nazwa == "Statystyka")
            {
                return View(nazwa);
            }

            if (nazwa == "Windykacja")
            {
                return View(nazwa);
            }

            return View(nazwa);

        }


        /////////////////////////////
        public ActionResult BudynkiPodpowiedzi(string term)
        {
            var budynek = db.BlokiMieszkalne.Where(a => !a.Ukryty && a.Adres.ToLower().Contains(term.ToLower()))
                        .Take(5).Select(a => new { label = a.Adres });

            return Json(budynek, JsonRequestBehavior.AllowGet);
        }
    }
}