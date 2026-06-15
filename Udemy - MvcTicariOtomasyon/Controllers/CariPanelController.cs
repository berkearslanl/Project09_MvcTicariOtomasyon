using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();

        //PROFİLİM

        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];// CariMail alanı veritabanından gönderilen maili tutuyor
            if (mail != null)
            {
                var cariler = c.Caris.FirstOrDefault(x => x.CariMail == mail);
                ViewBag.CariMail = mail;
                ViewBag.CariAd = cariler.CariAd;
                ViewBag.CariSoyad = cariler.CariSoyad;
                ViewBag.CariSehir = cariler.CariSehir;
                ViewBag.CariSifre = cariler.CariSifre;

                var cariId = c.Caris.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();

                var toplamSatis = c.SatisHarekets.Where(x => x.CariId == cariId).Count();
                ViewBag.toplamsatis = toplamSatis;

                var toplamTutar = c.SatisHarekets.Where(x => x.CariId == cariId).Sum(y => y.ToplamTutar).ToString();
                ViewBag.toplamtutar = toplamTutar;

                var toplamUrun = c.SatisHarekets.Where(x => x.CariId == cariId).Sum(y => y.Adet).ToString();
                ViewBag.toplamurun = toplamUrun;

                var mesajlar = c.Mesajs.Where(x => x.Alici == mail).ToList();
                return View(mesajlar);
            }
            return View();
        }
        [HttpGet]
        public PartialViewResult Guncelle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Guncelle(Cari cari)
        {
            var cMail = (string)Session["CariMail"];
            var user = c.Caris.FirstOrDefault(x => x.CariMail == cMail);
            ViewBag.CariMail = cMail;
            ViewBag.CariAd = user.CariAd;
            ViewBag.CariSoyad = user.CariSoyad;
            ViewBag.CariSehir = user.CariSehir;
            ViewBag.CariSifre = user.CariSifre;


            user.CariAd = cari.CariAd;
            user.CariSoyad = cari.CariSoyad;
            user.CariSehir = cari.CariSehir;
            user.CariMail = cari.CariMail;
            user.CariSifre = cari.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index", "CariPanel");
        }

        //SİPARİŞLERİM

        public ActionResult Siparislerim()
        {
            var cariMail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == cariMail).Select(y => y.CariId).FirstOrDefault();
            var siparisler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(siparisler);
        }

        //MESAJLAR

        public ActionResult MesajListesi()
        {
            var cariMail = (string)Session["CariMail"];
            var values = c.Mesajs.Where(x => x.Alici == cariMail).OrderByDescending(x => x.Tarih).ToList();
            ViewBag.sayi = values.Count;
            return View(values);
        }
        public ActionResult GonderilenMesajlar()
        {
            var cariMail = (string)Session["CariMail"];
            var values = c.Mesajs.Where(x => x.Gönderici == cariMail).OrderByDescending(x => x.Tarih).ToList();
            ViewBag.sayi = values.Count;
            return View(values);
        }
        public ActionResult MesajDetay(int id)
        {
            var mesajDetay = c.Mesajs.Where(x => x.MesajId == id).FirstOrDefault();
            return View(mesajDetay);
        }
        [HttpGet]
        public ActionResult MesajGonder(string aliciMail)
        {
            var mail = (string)Session["CariMail"];
            ViewBag.GondericiMail = mail;
            ViewBag.AliciMail = aliciMail;
            return View();
        }
        [HttpPost]
        public ActionResult MesajGonder(Mesaj mesaj)
        {
            mesaj.Tarih = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View(mesaj);
            }
            c.Mesajs.Add(mesaj);
            c.SaveChanges();
            return RedirectToAction("GonderilenMesajlar");
        }

        //KARGO TAKİP

        public ActionResult KargoTakip(string p)
        {
            var values = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.TakipKodu.Contains(p));
            }
            var cariMail = (string)Session["CariMail"];
            var cariAd = c.Caris.Where(x => x.CariMail == cariMail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            var lastValues = values.Where(x => x.Alici == cariAd).ToList();
            return View(lastValues);
        }

        public ActionResult CariKargoDetay(string id)
        {
            var values = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            ViewBag.takipkodu = id;
            return View(values);
        }
        //duyurular
        public PartialViewResult DuyuruPartial()
        {
            var values = c.Mesajs.Where(x => x.Gönderici == "Admin").ToList();
            return PartialView(values);
        }
    }
}