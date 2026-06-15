using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)//sayfalama işlemi bu değerden başlar
        {
            var values = c.Kategoris.ToList().ToPagedList(sayfa, 4);//1. başlangıç değeri, 2. her sayfada kaç adet veri olacağı
            return View(values);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            c.Kategoris.Add(kategori);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var value = c.Kategoris.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var value = c.Kategoris.Find(kategori.KategoriId);
            value.KategoriAd = kategori.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var value = c.Kategoris.Find(id);
            c.Kategoris.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Cascading()
        {
            Class2 cs = new Class2();
            cs.Kategoriler = new SelectList(c.Kategoris, "KategoriId", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "UrunId", "UrunAd");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunListesi = (from x in c.Uruns
                               join y in c.Kategoris
                               on x.KategoriId equals y.KategoriId
                               where x.KategoriId == p
                               select new
                               {
                                   Text = x.UrunAd,
                                   Value = x.UrunId.ToString()
                               }).ToList();
            return Json(urunListesi, JsonRequestBehavior.AllowGet);
        }
    }
}