using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieNieruchomosciami.DAL;
using ZarzadzanieNieruchomosciami.ViewModels;

namespace ZarzadzanieNieruchomosciami.Controllers
{
    public class ZarzadzanieController : Controller
    {

        private ZarzadzanieContext db = new ZarzadzanieContext();

        // GET: Zarzadzanie
        public ActionResult Index()
        {

            var Kategoria = db.Kategorie.ToList();

            var vm = new StartViewModel()
            {
                Kategoria = Kategoria,

            };
            return View(vm);


            //return View();
        }

        public ActionResult Lista(string nazwaKategori) //string nazwaKategori
        {


            var name = User.Identity.Name;
            // logger.Info("Strona kategoria | " + nazwaKategori + " | " + name);
            //var kategoria = db.Kategorie.Include("Kursy").Where(k => k.NazwaKategorii.ToUpper() == nazwaKategori.ToUpper()).Single();

            //var kursy = kategoria.Kursy.Where(a => (searchQuery == null ||
            //                                  a.TytulKursu.ToLower().Contains(searchQuery.ToLower()) ||
            //                                  a.AutorKursu.ToLower().Contains(searchQuery.ToLower())) &&
            //                                  !a.Ukryty);

            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("_KursyList", kursy);
            // }
            var lokal = db.LokaleMieszkalne;        //

            return View(lokal);


            //return View();

        }

        public ActionResult Szczegoly(int id)
        {
            var lokal = db.LokaleMieszkalne.Find(id);
            var name = User.Identity.Name;
            //logger.Info("Strona szczególy | " + kurs.TytulKursu + " | " + name);
            return View(lokal);


           // return View();
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
            return View(nazwa);
        }

    }
}