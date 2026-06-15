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
    [Authorize(Roles = "A")]
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Personels.Where(x => x.Durum == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> degerler = (from x in c.Departmants.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmantAd,
                                                 Value = x.DepartmantId.ToString()
                                             }).ToList();

            ViewBag.Degerler = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (Request.Files.Count > 0) //isteklerim arasında bir dosya varsa
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName); //dosyanın adını al
                string uzanti = Path.GetExtension(Request.Files[0].FileName); //dosyanın uzantısını al
                string yol = "/images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/images/" + dosyaAdi + uzanti;
            }
            personel.Durum = true;
            c.Personels.Add(personel);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            List<SelectListItem> degerler = (from x in c.Departmants.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmantAd,
                                                 Value = x.DepartmantId.ToString()
                                             }).ToList();

            ViewBag.Degerler = degerler;

            var value = c.Personels.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> degerler = (from x in c.Departmants.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmantAd,
                                                     Value = x.DepartmantId.ToString()
                                                 }).ToList();

                ViewBag.Degerler = degerler;
                return View(personel);
            }
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/images/" + dosyaAdi + uzanti;
            }
            var value = c.Personels.Find(personel.PersonelId);
            value.PersonelAd = personel.PersonelAd;
            value.PersonelSoyad = personel.PersonelSoyad;
            value.Durum = personel.Durum;
            value.DepartmantId = personel.DepartmantId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var value = c.Personels.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSatisGecmisi(int id)
        {
            var value = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var prs = c.Personels.Find(id);
            ViewBag.personel = prs.PersonelAd + " " + prs.PersonelSoyad;
            return View(value);
        }
        public ActionResult PersonelDetay()
        {
            var values = c.Personels.Where(x => x.Durum == true).ToList();
            return View(values);
        }
    }
}