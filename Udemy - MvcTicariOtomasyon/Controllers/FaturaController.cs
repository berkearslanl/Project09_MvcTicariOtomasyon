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
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Faturas.Where(x => x.Durum == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            fatura.Durum = true;
            fatura.Tarih = DateTime.Now.Date;
            fatura.Saat = DateTime.Now;
            c.Faturas.Add(fatura);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FaturaGuncelle(int id)
        {
            var value = c.Faturas.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var value = c.Faturas.Find(fatura.FaturaId);
            value.FaturaSeriNo = fatura.FaturaSeriNo;
            value.FaturaSıraNo = fatura.FaturaSıraNo;
            value.TeslimAlan = fatura.TeslimAlan;
            value.TeslimEden = fatura.TeslimEden;
            value.VergiDairesi = fatura.VergiDairesi;
            value.Toplam = fatura.Toplam;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaSil(int id)
        {
            var value = c.Faturas.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var values = c.FaturaKalems.Where(x => x.FaturaId == id && x.Durum == true).ToList();
            var sırano = c.Faturas.Find(id);
            ViewBag.sırano = sırano.FaturaSıraNo;
            var fatura = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.FaturaId).FirstOrDefault();
            ViewBag.fatura = fatura;
            return View(values);
        }
        [HttpGet]
        public ActionResult FaturaKalemiEkle(int id)//bu id faturakalemiekle butonundan gönderilen viewbag.fatura'da tutulan faturaid'yi ifade ediyor
        {
            var fatura = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.FaturaId).FirstOrDefault();
            ViewBag.faturaid = fatura;
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemiEkle(FaturaKalem faturaKalem)
        {
            faturaKalem.Durum = true;
            c.FaturaKalems.Add(faturaKalem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DinamikFatura()
        {
            dFatura fatura = new dFatura();
            fatura.Faturas = c.Faturas.ToList();
            fatura.FaturaKalems = c.FaturaKalems.ToList();
            return View(fatura);
        }
    }
}