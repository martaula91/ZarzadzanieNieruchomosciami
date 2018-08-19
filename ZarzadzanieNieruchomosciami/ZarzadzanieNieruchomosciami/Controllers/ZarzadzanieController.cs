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

       

        public ActionResult SzczegolyLokalu(int id)
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

            return View(nazwa);
        }



    }
}