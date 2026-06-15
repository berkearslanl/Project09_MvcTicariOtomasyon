using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SatisHarekets.Where(x => x.Durum == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunId.ToString()
                                            }).ToList();

            List<SelectListItem> cariler = (from x in c.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariId.ToString()
                                            }).ToList();

            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelId.ToString()
                                                }).ToList();

            ViewBag.urun = urunler;
            ViewBag.cari = cariler;
            ViewBag.personel = personeller;
            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(SatisHareket satisHareket)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            satisHareket.Durum = true;
            satisHareket.Tarih = DateTime.Now;
            c.SatisHarekets.Add(satisHareket);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisSil(int id)
        {
            var value = c.SatisHarekets.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var values = c.SatisHarekets.Where(x => x.SatisHareketId == id).ToList();
            return View(values);
        }
    }
}