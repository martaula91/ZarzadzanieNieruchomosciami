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
using ZarzadzanieNieruchomosciami.Infrastructure;
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

  
        /////////////////////////

        [Authorize(Roles = "Employee")]
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
        [Authorize(Roles = "Employee")]
        public ActionResult DodajLokal(EditLokalViewModel model, HttpPostedFileBase file)
        {
            if (model.Lokal.LokalID > 0)
            {
                // modyfikacja 
                db.Entry(model.Lokal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajLokal", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    db.Entry(model.Lokal).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("DodajLokal", new { potwierdzenie = true });
                }
                else
                {
                    var kategorie = db.BlokiMieszkalne.ToList();
                    model.BlokiMieszkalne = kategorie;
                    return View(model);
                }

            }

        }

        [Authorize(Roles = "Employee")]
        public ActionResult UkryjLokal(int lokalId)
        {
            var lokal = db.LokaleMieszkalne.Find(lokalId);
            db.Entry(lokal).State = EntityState.Deleted;
           // lokal.Ukryty = true;
            db.SaveChanges();

            return RedirectToAction("DodajLokal", new { potwierdzenie = true });
        }

        [Authorize(Roles = "Employee")]
        public ActionResult PokazLokal(int lokalId)
        {
            var lokal = db.LokaleMieszkalne.Find(lokalId);
            lokal.Ukryty = false;
            db.SaveChanges();

            return RedirectToAction("DodajLokal", new { potwierdzenie = true });
        }

        ///////////////////////// DODAJ BUDYNEK

        [Authorize(Roles = "Employee")]
        public ActionResult DodajBudynek(int? blokMieszkalnyId, bool? potwierdzenie)
        {
            BlokMieszkalny budynek;

            if (blokMieszkalnyId.HasValue)
            {
                ViewBag.EditMode = true;
                budynek = db.BlokiMieszkalne.Find(blokMieszkalnyId);
            }
            else
            {
                ViewBag.EditMode = false;
                budynek = new BlokMieszkalny();
            }

            var result = new EditBudynekViewModel();
            //result.Lokale = db.LokaleMieszkalne.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Budynek = budynek;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DodajBudynek(EditBudynekViewModel model, HttpPostedFileBase file)
        {
            if (model.Budynek.BlokMieszkalnyId > 0)
            {
                // modyfikacja budynku
                db.Entry(model.Budynek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajBudynek", new { potwierdzenie = true });
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

                        var path = Path.Combine(Server.MapPath(AppConfig.ObrazkiFolderWzgledny), filename);
                        file.SaveAs(path);

                        model.Budynek.NazwaPlikuObrazka = filename;


                        db.Entry(model.Budynek).State = EntityState.Added;
                        db.SaveChanges();

                        return RedirectToAction("DodajBudynek", new { potwierdzenie = true });
                    }
                    else
                    {
                        //var kategorie = db.BlokiMieszkalne.ToList();
                        //model.BlokiMieszkalne = kategorie;
                        return View(model);
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Nie wskazano pliku");

                    
                    return View(model);
                }

        }
}


        [Authorize(Roles = "Employee")]
        public ActionResult UkryjBudynek(int BlokMieszkalnyId)
        {
            var budynek = db.BlokiMieszkalne.Find(BlokMieszkalnyId);
            db.Entry(budynek).State = EntityState.Deleted;
            //budynek.Ukryty = true;
            db.SaveChanges();

            return RedirectToAction("DodajBudynek", new { potwierdzenie = true });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult PokazBudynek(int BlokMieszkalnyId)
        {
            var budynek = db.BlokiMieszkalne.Find(BlokMieszkalnyId);
            budynek.Ukryty = false;
            db.SaveChanges();

            return RedirectToAction("DodajBudynek", new { potwierdzenie = true });
        }

        ///////////////////////// DODAJ DOKUMENT

        [Authorize(Roles = "Employee")]
        public ActionResult DodajDokument(int? dokumentId, bool? potwierdzenie)
        {
            Dokument dokument;

            if (dokumentId.HasValue)
            {
                ViewBag.EditMode = true;
                dokument = db.Dokumenty.Find(dokumentId);
            }
            else
            {
                ViewBag.EditMode = false;
                dokument = new Dokument();
            }

            var result = new EditDokumentViewModel();
            result.BlokiMieszkalne = db.BlokiMieszkalne.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Dokument = dokument;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DodajDokument(EditDokumentViewModel model, HttpPostedFileBase file)
        {
            if (model.Dokument.DokumentID > 0)
            {
                // modyfikacja dok
                db.Entry(model.Dokument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajDokument", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    model.Dokument.DataDokumentu = DateTime.Now;
                    db.Entry(model.Dokument).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("DodajDokument", new { potwierdzenie = true });
                }
                else
                {
                    var kategorie = db.BlokiMieszkalne.ToList();
                    model.BlokiMieszkalne = kategorie;
                    return View(model);
                }
            }

        }


        [Authorize(Roles = "Employee")]
        public ActionResult UkryjDokument(int dokumentID)
        {
            var dokument = db.Dokumenty.Find(dokumentID);
            db.Entry(dokument).State = EntityState.Deleted;
            //dokument.Ukryty = true;
            db.SaveChanges();

            return RedirectToAction("DodajDokument", new { potwierdzenie = true });
        }

        [Authorize(Roles = "Employee")]
        public ActionResult PokazDokument(int dokumentID)
        {
            var dokument = db.Dokumenty.Find(dokumentID);
            dokument.Ukryty = false;
            db.SaveChanges();

            return RedirectToAction("DodajDokument", new { potwierdzenie = true });
        }

        /////////////////////DODAJ INFORMACJE

        [Authorize(Roles = "Employee")]
        public ActionResult DodajInformacje(int? informacjaID, bool? potwierdzenie)
        {
            Informacja info;

            if (informacjaID.HasValue)
            {
                ViewBag.EditMode = true;
                info = db.Informacje.Find(informacjaID);
            }
            else
            {
                ViewBag.EditMode = false;
                info = new Informacja();
            }

            var result = new EditInformacjaViewModel();
            //result.Informacja = db.Informacje.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Informacja = info;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DodajInformacje(EditInformacjaViewModel model, HttpPostedFileBase file)
        {
            if (model.Informacja.InformacjaID > 0)
            {
                // modyfikacja kursu
                db.Entry(model.Informacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajInformacje", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    model.Informacja.DataDodania = DateTime.Now;
                    db.Entry(model.Informacja).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("DodajInformacje", new { potwierdzenie = true });
                }
                else
                {
                    //var kategorie = db.BlokiMieszkalne.ToList();
                    //model.BlokiMieszkalne = kategorie;
                    return View(model);
                }
            }

        }

        [Authorize(Roles = "Employee")]
        public ActionResult UkryjInformacje(int informacjaID)
        {
            var info = db.Informacje.Find(informacjaID);
            db.Entry(info).State = EntityState.Deleted;
            //info.Ukryty = true;
            db.SaveChanges();

            return RedirectToAction("DodajInformacje", new { potwierdzenie = true });
        }

        [Authorize(Roles = "Employee")]
        public ActionResult PokazInformacje(int informacjaID)
        {
            var info = db.Informacje.Find(informacjaID);
            db.Entry(info).State = EntityState.Deleted;
            // info.Ukryty = false;
            db.SaveChanges();

            return RedirectToAction("DodajInformacje", new { potwierdzenie = true });
        }

        /////////////////////////Dodaj Ksiegowosc

        [Authorize(Roles = "Employee")]
        public ActionResult DodajKsiegowosc(int? ksiegowoscId, bool? potwierdzenie)
        {
            Ksiegowosc ksiegowosc;

            if (ksiegowoscId.HasValue)
            {
                ViewBag.EditMode = true;
                ksiegowosc = db.Ksiegowosc.Find(ksiegowoscId);
            }
            else
            {
                ViewBag.EditMode = false;
                ksiegowosc = new Ksiegowosc();
            }

            var result = new EditKsiegowoscViewModel();
            result.LokalMieszkalny = db.LokaleMieszkalne.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Ksiegowosc = ksiegowosc;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DodajKsiegowosc(EditKsiegowoscViewModel model, HttpPostedFileBase file)
        {
            if (model.Ksiegowosc.KsiegowoscID > 0)
            {
                // modyfikacja 
                db.Entry(model.Ksiegowosc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajKsiegowosc", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    var lokalMieszkalny = db.LokaleMieszkalne.FirstOrDefault(l => l.LokalID == model.Ksiegowosc.LokalMieszkalnyID);
                    if (model.Ksiegowosc.OpisDokumentu == OpisDokumentu.Naliczenie || model.Ksiegowosc.OpisDokumentu == OpisDokumentu.Odsetki)
                    {
                        lokalMieszkalny.Saldo -= model.Ksiegowosc.Wartosc;
                    }
                    else if (model.Ksiegowosc.OpisDokumentu == OpisDokumentu.Wplata)
                    {
                        lokalMieszkalny.Saldo += model.Ksiegowosc.Wartosc;
                    }
                    model.Ksiegowosc.DataDodania = DateTime.Now;
                    db.Entry(model.Ksiegowosc).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("DodajKsiegowosc", new { potwierdzenie = true });
                }
                else
                {
                    var lokal = db.LokaleMieszkalne.ToList();
                    model.LokalMieszkalny = lokal;
                    return View(model);
                }

            }

        }


        /////////////////////////Dodaj Rozliczenie

        [Authorize(Roles = "Employee")]
        public ActionResult DodajRozliczenie(int? rozliczenieId, bool? potwierdzenie)
        {
            Rozliczenie rozliczenie;

            if (rozliczenieId.HasValue)
            {
                ViewBag.EditMode = true;
                rozliczenie = db.Rozliczenia.Find(rozliczenieId);
            }
            else
            {
                ViewBag.EditMode = false;
                rozliczenie = new Rozliczenie();
            }

            var result = new EditRozliczenieViewModel();
            result.LokalMieszkalny = db.LokaleMieszkalne.ToList();
            result.Stawka = db.Stawka.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Rozliczenie = rozliczenie;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DodajRozliczenie(EditRozliczenieViewModel model, HttpPostedFileBase file)
        {
            if (model.Rozliczenie.RozliczenieId > 0)
            {
                // modyfikacja 
                db.Entry(model.Rozliczenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajRozliczenie", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    model.Rozliczenie.StanNaDzien = DateTime.Now;
                    db.Entry(model.Rozliczenie).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("DodajRozliczenie", new { potwierdzenie = true });
                }
                else
                {
                    //var kategorie = db.BlokiMieszkalne.ToList();
                    //model.BlokiMieszkalne = kategorie;
                    return View(model);
                }

            }

        }

        /////////////////////////Dodaj Glosowanie

        [Authorize(Roles = "Employee")]
        public ActionResult DodajGlosowanie(int? glosowanieId, bool? potwierdzenie)
        {
            Glosowanie glosowanie;

            if (glosowanieId.HasValue)
            {
                ViewBag.EditMode = true;
                glosowanie = db.Glosowanie.Find(glosowanieId);
            }
            else
            {
                ViewBag.EditMode = false;
                glosowanie = new Glosowanie();
            }

            var result = new EditGlosowanieViewModel();
            result.BlokiMieszkalne = db.BlokiMieszkalne.ToList();
            //result.DaneUsera = db.DaneUsera.ToList();
            result.Glosowanie = glosowanie;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DodajGlosowanie(EditGlosowanieViewModel model, HttpPostedFileBase file)
        {
            if (model.Glosowanie.GlosowanieId > 0)
            {
                // modyfikacja 
                db.Entry(model.Glosowanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajGlosowanie", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    model.Glosowanie.DataUtworzeniaGlosowania = DateTime.Now;
                    model.Glosowanie.DataKoncaGlosowania = DateTime.Now.AddMonths(1);
                    db.Entry(model.Glosowanie).State = EntityState.Added;
                    db.SaveChanges();

                    foreach (var p in model.Pytania)
                    {
                        var pytanie = new Pytanie()
                        {
                            GlosowanieId = model.Glosowanie.GlosowanieId,
                            TrescPytania = p.TrescPytania
                        };

                        db.Pytanie.Add(pytanie);
                    }

                    db.SaveChanges();

                    return RedirectToAction("DodajGlosowanie", new { potwierdzenie = true });
                }
                else
                {
                    var kategorie = db.BlokiMieszkalne.ToList();
                    model.BlokiMieszkalne = kategorie;
                    return View(model);
                }

            }

        }

        /////////////////////////Dodaj Stawke

        [Authorize(Roles = "Employee")]
        public ActionResult DodajStawke(int? stawkaId, bool? potwierdzenie)
        {
            Stawka stawka;

            if (stawkaId.HasValue)
            {
                ViewBag.EditMode = true;
                stawka = db.Stawka.Find(stawkaId);
            }
            else
            {
                ViewBag.EditMode = false;
                stawka = new Stawka();
            }

            var result = new EditStawkaViewModel();
            result.Stawka = stawka;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DodajStawke(EditStawkaViewModel model, HttpPostedFileBase file)
        {
            if (model.Stawka.StawkaID > 0)
            {
                // modyfikacja 
                db.Entry(model.Stawka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DodajStawke", new { potwierdzenie = true });
            }
            else
            {
                // dodanie nowego
                if (ModelState.IsValid)
                {
                    model.Stawka.DataDodania = DateTime.Now;
                    db.Entry(model.Stawka).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("DodajStawke", new { potwierdzenie = true });
                }
                else
                {

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