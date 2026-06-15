using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Caris.Where(x => x.Durum == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CariEkle()
        { return View(); }
        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            cari.Durum = true;
            c.Caris.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Caris.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var value = c.Caris.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var value = c.Caris.Find(cari.CariId);
            value.CariAd = cari.CariAd;
            value.CariSoyad = cari.CariSoyad;
            value.CariSehir = cari.CariSehir;
            value.CariMail = cari.CariMail;
            value.Durum = cari.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSatisGecmisi(int id)
        {
            var values = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cari = c.Caris.Find(id);
            ViewBag.cari = cari.CariAd + " " + cari.CariSoyad;
            return View(values);
        }
    }
}