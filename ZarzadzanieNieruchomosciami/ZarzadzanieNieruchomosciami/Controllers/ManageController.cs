using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZarzadzanieNieruchomosciami.App_Start;
using ZarzadzanieNieruchomosciami.DAL;
using ZarzadzanieNieruchomosciami.Models;
using ZarzadzanieNieruchomosciami.ViewModels;

namespace ZarzadzanieNieruchomosciami.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();
        //private IMailService mailService;
        //private ZarzadzanieContext db;

        private ZarzadzanieContext db = new ZarzadzanieContext();


        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        public ManageController()
        { }

        public ManageController(ZarzadzanieContext context) //, IMailService mailService
        {
            this.db = context;
            //this.mailService = mailService;
        }

        public ManageController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Manage
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            var name = User.Identity.Name;
            //logger.Info("Admin główna | " + name);

            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageCredentialsViewModel
            {
                Message = message,
                DaneUzytkownika = user.DaneUser
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "DaneUzytkownika")]DaneUser daneUzytkownika)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.DaneUser = daneUzytkownika;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new { Message = message });
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }




         public ActionResult ListaLokali()
                {
                    var name = User.Identity.Name;
                    //logger.Info("Admin zamowienia | " + name);

                    bool isAdmin = User.IsInRole("Admin");
                    ViewBag.UserIsAdmin = isAdmin;
            
            //IEnumerable<Wlasnosc> wlasnoscUzytkownika;

            // Dla administratora zwracamy wszystkie zamowienia
            if (isAdmin)
                     {
                         //wlasnoscUzytkownika = db.Wlasnosci.Include("PozycjeWlasnosci").OrderByDescending(o => o.WlasnoscId).ToArray();
                     }
                     else
                     {
                         var userId = User.Identity.GetUserId();
                        // wlasnoscUzytkownika = db.Wlasnosci.Where(o => o.UserId == userId).Include("PozycjeWlasnosci").OrderByDescending(o => o.WlasnoscId).ToArray();
                     }

                     return View(); // return View(wlasnoscUzytkownika);

        }

    /*   [HttpPost]
      [Authorize(Roles = "Admin")]
      public StanZamowienia ZmianaStanuZamowienia(Zamowienie zamowienie)
      {
          Zamowienie zamowienieDoModyfikacji = db.Zamowienia.Find(zamowienie.ZamowienieID);
          zamowienieDoModyfikacji.StanZamowienia = zamowienie.StanZamowienia;
          db.SaveChanges();

          if (zamowienieDoModyfikacji.StanZamowienia == StanZamowienia.Zrealizowane)
          {
              this.mailService.WyslanieZamowienieZrealizowaneEmail(zamowienieDoModyfikacji);
          }

          return zamowienie.StanZamowienia;
      }
      */

    /////////////////////////

    [Authorize(Roles = "Admin")]
                public ActionResult DodajLokal(int? lokalId, bool? potwierdzenie)
                {
                    LokalMieszkalny lokal; 

                    if (lokalId.HasValue)
                    {
                        ViewBag.EditMode = true;
                        lokal = db.LokaleMieszkalne.Find(lokalId);
                    }
                    else
                    {
                        ViewBag.EditMode = false;
                        lokal = new LokalMieszkalny();
                    }

                    var result = new EditLokalViewModel();
                    result.BlokiMieszkalne = db.BlokiMieszkalne.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Lokal = lokal;
                    result.Potwierdzenie = potwierdzenie;

                    return View(result);
                }

                [HttpPost]
                [Authorize(Roles = "Admin")]
                public ActionResult DodajLokal(EditLokalViewModel model, HttpPostedFileBase file)
                {
                    if (model.Lokal.LokalID > 0)
                    {
                        // modyfikacja kursu
                        db.Entry(model.Lokal).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("DodajKurs", new { potwierdzenie = true });
                    }
                    else
                    {
                // Sprawdzenie, czy użytkownik wybrał plik

                if (file != null && file.ContentLength > 0)
                        {
                            if (ModelState.IsValid)
                            {
                                // Generowanie pliku
                                var fileExt = Path.GetExtension(file.FileName);
                                var filename = Guid.NewGuid() + fileExt;

                               // var path = Path.Combine(Server.MapPath(AppConfig.ObrazkiFolderWzgledny), filename);
                               // file.SaveAs(path);

                               // model.Lokal.NazwaPlikuObrazka = filename;
                                //model.Lokal.DataDodania = DateTime.Now;

                                db.Entry(model.Lokal).State = EntityState.Added;
                                db.SaveChanges();

                                return RedirectToAction("DodajKurs", new { potwierdzenie = true });
                            }
                            else
                            {
                               // var kategorie = db.Kategorie.ToList();
                               // model.Kategorie = kategorie;
                                return View(model);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Nie wskazano pliku");
                            var kategorie = db.Kategorie.ToList();
                           // model.Kategorie = kategorie;
                            return View(model);
                        }
                    }

                }

                
                /*
        [Authorize(Roles = "Admin")]
        public ActionResult UkryjKurs(int kursId)
        {
            var kurs = db.Kursy.Find(kursId);
            kurs.Ukryty = true;
            db.SaveChanges();

            return RedirectToAction("DodajKurs", new { potwierdzenie = true });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult PokazKurs(int kursId)
        {
            var kurs = db.Kursy.Find(kursId);
            kurs.Ukryty = false;
            db.SaveChanges();

            return RedirectToAction("DodajKurs", new { potwierdzenie = true });
        }

        [AllowAnonymous]
        public ActionResult WyslaniePotwierdzenieZamowieniaEmail(int zamowienieId, string nazwisko)
        {
            var zamowienie = db.Zamowienia.Include("PozycjeZamowienia").Include("PozycjeZamowienia.Kurs")
                               .SingleOrDefault(o => o.ZamowienieID == zamowienieId && o.Nazwisko == nazwisko);

            if (zamowienie == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            PotwierdzenieZamowieniaEmail email = new PotwierdzenieZamowieniaEmail();
            email.To = zamowienie.Email;
            email.From = "mariuszjurczenko@gmail.com";
            email.Wartosc = zamowienie.WartoscZamowienia;
            email.NumerZamowienia = zamowienie.ZamowienieID;
            email.PozycjeZamowienia = zamowienie.PozycjeZamowienia;
            email.sciezkaObrazka = AppConfig.ObrazkiFolderWzgledny;
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [AllowAnonymous]
        public ActionResult WyslanieZamowienieZrealizowaneEmail(int zamowienieId, string nazwisko)
        {
            var zamowienie = db.Zamowienia.Include("PozycjeZamowienia").Include("PozycjeZamowienia.Kurs")
                                  .SingleOrDefault(o => o.ZamowienieID == zamowienieId && o.Nazwisko == nazwisko);

            if (zamowienie == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            ZamowienieZrealizowaneEmail email = new ZamowienieZrealizowaneEmail();
            email.To = zamowienie.Email;
            email.From = "mariuszjurczenko@gmail.com";
            email.NumerZamowienia = zamowienie.ZamowienieID;
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        */
    }
}