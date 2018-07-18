using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieNieruchomosciami.DAL;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.Controllers
{
    public class HomeController : Controller
    {
        ZarzadzanieContext db = new ZarzadzanieContext();

        public ActionResult Index()
        {
            BlokMieszkalny blok = new BlokMieszkalny { BlokMieszkalnyId = 1, Ulica = "Lipowa", NumerBlokuMieszkalnego = 12, PowierzchniaUzytkowa = 1234, LiczbaLokali = 45, PowDzialki = 1234, NrEwidDzialki = 123 };
            db.BlokiMieszkalne.Add(blok);
            db.SaveChanges();

            return View();
        }
    }
}