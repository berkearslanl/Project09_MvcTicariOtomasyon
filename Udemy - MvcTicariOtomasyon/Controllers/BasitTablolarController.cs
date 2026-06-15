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
    public class BasitTablolarController : Controller
    {
        // GET: BasitTablolar
        Context c = new Context();
        public ActionResult Index()
        {
            var query = (from x in c.Caris
                         group x by x.CariSehir into g
                         orderby g.Count() descending
                         select new GrupSinif
                         {
                             Sehir = g.Key,
                             Sayi = g.Count()
                         });
            return View(query.ToList());
        }
        public PartialViewResult Partial1()
        {
            var query = (from x in c.Personels
                         group x by x.Departmant.DepartmantAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         });
            return PartialView(query.ToList());
        }
        public PartialViewResult Partial2()
        {
            var values = c.Caris.Where(x => x.Durum == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult Partial3()
        {
            var values = c.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult Partial4()
        {
            var query = (from x in c.Uruns
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             Marka = g.Key,
                             Sayi = g.Count()
                         });
            return PartialView(query.ToList());
        }
    }
}