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
    public class KargoController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var values = c.KargoDetays.Select(x => x);
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.TakipKodu.Contains(p));
            }
            return View(values.ToList());
        }
        [HttpGet]
        public ActionResult KargoEkle()
        {
            Random rnd = new Random();
            string ilkKisim = "ABC";

            string ortaKisim = "";
            for (int i = 0; i < 5; i++)
            {
                ortaKisim = ortaKisim + rnd.Next(0, 10);
            }

            string harfler = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string sonKisim = "";
            for (int i = 0; i < 2; i++)
            {
                sonKisim = sonKisim + harfler[rnd.Next(harfler.Length)];
            }

            ViewBag.takipkodu = ilkKisim + ortaKisim + sonKisim;
            return View();
        }
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay kargoDetay)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            kargoDetay.Tarih = DateTime.Now;
            c.KargoDetays.Add(kargoDetay);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoDetay(string id)
        {
            var values = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            ViewBag.takipkodu = id;
            return View(values);
        }
    }
}