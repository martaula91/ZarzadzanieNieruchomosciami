using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieNieruchomosciami.DAL;
using ZarzadzanieNieruchomosciami.ViewModels;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.Controllers
{
    public class ZarzadzanieController : Controller
    {

        private ZarzadzanieContext db = new ZarzadzanieContext();

        // GET: Zarzadzanie
        public ActionResult Index()
        {
            var kategorieDostepne = db.Kategorie.ToList();

            var vm = new StartViewModel()
            {
                Kategoria = kategorieDostepne,

            };
            return View(vm); //vm



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
            var blok = db.BlokiMieszkalne.Find(id);
            var name = User.Identity.Name;
            //logger.Info("Strona szczególy | " + kurs.TytulKursu + " | " + name);
            //return View(lokal);


            return View(blok);
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


        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult KategorieMenu()
        {
            var kategorie = db.Kategorie.ToList();
            return PartialView("_KategorieMenu", kategorie);
        }

        public ActionResult StronyKategori(string nazwa)
        {
           if  (nazwa == "Lokal")
            {
                var lokal = db.LokaleMieszkalne.ToList();
                return View(nazwa, lokal);
            }

            if(nazwa == "Budynek")
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

            if (nazwa == "Rozliczenia")
            {
                var dok = db.Rozliczenia.ToList();
                return View(nazwa, dok);
            }
            if (nazwa == "StanLicznikow")
            {
                var dok = db.Dokumenty.ToList();
                return View(nazwa, dok);
            }

            return View(nazwa);

        }



    }
}