using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    //[AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult KayitPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult KayitPartial(Cari cari)
        {
            cari.Durum = true;
            c.Caris.Add(cari);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult GirisPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult GirisPartial(Cari cari)
        {
            var bilgiler = c.Caris.FirstOrDefault(x => x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail;
                return RedirectToAction("Index","CariPanel");
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public PartialViewResult PersonelGirisPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PersonelGirisPartial(Admin admin)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd;
                return RedirectToAction("Index", "Kategori");
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();//çıkış yap
            Session.Abandon();//istekleri terket
            return RedirectToAction("Index","Login");
        }
    }
}