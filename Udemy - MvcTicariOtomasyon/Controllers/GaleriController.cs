using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.Page = "Galeri";
            var values = c.Uruns.ToList();
            return View(values);
        }
    }
}