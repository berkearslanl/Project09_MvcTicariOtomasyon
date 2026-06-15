using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var values = c.Uruns.Where(x=>x.UrunId==8).ToList();
            cs.Uruns = c.Uruns.Where(x => x.UrunId == 8).ToList();
            cs.Detays = c.Detays.Where(x => x.DetayId == 2).ToList();
            return View(cs);
        }
    }
}