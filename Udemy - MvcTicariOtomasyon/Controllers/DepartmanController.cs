using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departmants.Where(x => x.Durum == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departmant departmant)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            departmant.Durum = true;
            c.Departmants.Add(departmant);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var value = c.Departmants.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var value = c.Departmants.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departmant departmant)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var value = c.Departmants.Find(departmant.DepartmantId);
            value.DepartmantAd = departmant.DepartmantAd;
            value.Durum = departmant.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var prs = c.Personels.Where(x => x.DepartmantId == id).ToList();
            var value = c.Departmants.Find(id);
            ViewBag.departman = value.DepartmantAd;
            return View(prs);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var values = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var personel = c.Personels.Find(id);
            ViewBag.personel = personel.PersonelAd + " " + personel.PersonelSoyad;
            return View(values);
        }
    }
}