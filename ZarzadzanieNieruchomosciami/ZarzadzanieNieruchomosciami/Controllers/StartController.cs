using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieNieruchomosciami.DAL;
using ZarzadzanieNieruchomosciami.Models;
using ZarzadzanieNieruchomosciami.ViewModels;

namespace ZarzadzanieNieruchomosciami.Controllers
{
    public class StartController : Controller
    {

        private ZarzadzanieContext db = new ZarzadzanieContext();

        // GET: Start
        public ActionResult Index()
        {
            ///var KategoriaUser = db.KategoriaUser.ToList();
            var Kategoria = db.Kategorie.ToList();

            var vm = new StartViewModel()
            {
                Kategoria = Kategoria,
                //KategoriaUser = KategoriaUser,
            };
            return View(vm);

            
        }


       
    }
}