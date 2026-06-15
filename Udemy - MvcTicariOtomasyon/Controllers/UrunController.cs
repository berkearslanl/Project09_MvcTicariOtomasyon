using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)//bu p view'deki textbox içinndeki p ile eşdeğer
        {
            //var values = c.Uruns.Where(x => x.Durum == true).ToList();
            var values = c.Uruns.Select(x => x);
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.UrunAd.Contains(p));
            }
            return View(values.ToList());
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriId.ToString()
                                             }).ToList();
            ViewBag.Degerler = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                urun.UrunGorsel = "/images/" + dosyaAdi + uzanti;
            }
            urun.Durum = true;
            c.Uruns.Add(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var veri = c.Uruns.Find(id);
            veri.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriId.ToString()
                                             }).ToList();
            ViewBag.Degerler = degerler;
            var value = c.Uruns.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun urun)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.KategoriId.ToString()
                                                 }).ToList();
                ViewBag.Degerler = degerler;
                return View(urun);
            }
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                urun.UrunGorsel = "/images/" + dosyaAdi + uzanti;
            }
            var value = c.Uruns.Find(urun.UrunId);
            value.UrunAd = urun.UrunAd;
            value.AlisFiyat = urun.AlisFiyat;
            value.SatisFiyat = urun.SatisFiyat;
            value.Stok = urun.Stok;
            value.Durum = urun.Durum;
            value.KategoriId = urun.KategoriId;
            value.Marka = urun.Marka;
            value.UrunGorsel = urun.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
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


            ViewBag.cari = cariler;
            ViewBag.personel = personeller;
            var value = c.Uruns.Where(x => x.UrunId == id).FirstOrDefault();
            ViewBag.fiyat = value.SatisFiyat.ToString();
            ViewBag.urunid = value.UrunId.ToString();
            ViewBag.urunstok = value.Stok;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket satisHareket)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            satisHareket.Durum = true;
            c.SatisHarekets.Add(satisHareket);
            c.SaveChanges ();
            return RedirectToAction("Index", "Satis");
        }
    }
}