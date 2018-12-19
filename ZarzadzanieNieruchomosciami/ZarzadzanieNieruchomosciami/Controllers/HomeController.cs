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
           // var listablokow = db.BlokiMieszkalne.ToList();

            return View();
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }

        

    }
}