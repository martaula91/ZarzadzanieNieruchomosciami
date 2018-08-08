using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieNieruchomosciami.DAL;

namespace ZarzadzanieNieruchomosciami.Controllers
{
    public class ZarzadzanieController : Controller
    {

        private ZarzadzanieContext db = new ZarzadzanieContext();

        // GET: Zarzadzanie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string nazwaKategori) //string nazwaKategori
        {


            //var kategoria = db.Kategorie.Include("Kursy").Where(k => k.NazwaKategorii.ToUpper() == nazwaKategori.ToUpper()).Single();
            //var kursy = kategoria.LokalMieszkalny.ToList();
            // return View(kursy);

            
                var kategoria = db.Kategorie.Where(k => k.nazwaKategori.ToUpper() == nazwaKategori.ToUpper()).Single();

            if (kategoria.KategoriaId == 1)
            { var kursy = kategoria.LokalMieszkalny.ToList(); //Where(a => a.KategoriaId == kategoria.KategoriaId);
                return View(kursy);
            }
           else
                 if (kategoria.KategoriaId == 2)
            {
                var kursy = kategoria.BlokMieszkalny.ToList(); //Where(a => a.KategoriaId == kategoria.KategoriaId);
                return View(kursy);
            }
            
            else

            return View();





            // var lokale = db.LokalMieszkalny.Where(a => !a.Ukryty)
            // var kurs = db.Kategorie.Find(kategoria);

        }

        public ActionResult Szczegoly(int id, int nrKolumny)
        {
            //var kurs = db.Kursy.Find(id);

            if (nrKolumny == 1)
            {
                var lokal = db.LokaleMieszkalne.Find(id);
                return View(lokal);
            }
            else
                if (nrKolumny == 2)
            {
                var blok = db.BlokiMieszkalne.Find(id);
                return View(blok);
            }

            else
                // var name = User.Identity.Name;
                // logger.Info("Strona szczególy | " + kurs.TytulKursu + " | " + name);


                // return View(opcja);
                return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult KategorieMenu()
        {
            var kategorie = db.Kategorie.ToList();
            return PartialView("_KategorieMenu", kategorie);
        }


    }
}