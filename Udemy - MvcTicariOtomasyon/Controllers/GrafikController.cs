using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;
using Udemy___MvcTicariOtomasyon.Models.Entities;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class GrafikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikCiz = new Chart(width: 600, height: 600);
            grafikCiz.AddTitle("Kategori - Ürün Stok Sayısı")
                .AddLegend("")
                .AddSeries
                    (
                        "Değerler",
                        xValue: new[]
                        {
                            "Mobilya","Ofis Ürünleri","Bilgisayar"
                        },
                        yValues: new[]
                        {
                            85,120,98
                        }
                    ).Write();
            return File(grafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalues = new ArrayList();
            ArrayList yvalues = new ArrayList();

            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalues.Add(x.UrunAd));
            sonuclar.ToList().ForEach(x => yvalues.Add(x.Stok));

            var grafik = new Chart(width: 500, height: 500)
                .AddTitle("Ürün Stok Verileri")
                .AddSeries
                (
                    chartType: "Line",
                    name: "Stok",
                    xValue: xvalues,
                    yValues: yvalues
                );

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizaUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<chartsinif> UrunListesi()
        {
            List<chartsinif> snf = new List<chartsinif>();
            snf.Add(new chartsinif()
            {
                UrunAd = "Bilgisayar",
                Stok = 120
            });
            snf.Add(new chartsinif()
            {
                UrunAd = "Bulaşık Makinesi",
                Stok = 150
            });
            snf.Add(new chartsinif()
            {
                UrunAd = "Koltuk Takımı",
                Stok = 70
            });
            snf.Add(new chartsinif()
            {
                UrunAd = "Kahve Makinesi",
                Stok = 180
            });
            snf.Add(new chartsinif()
            {
                UrunAd = "Tablet",
                Stok = 90
            });
            return snf;

        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult DinamikVisualizaUrunResult()
        {
            return Json(DinamikUrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<dinamikchartsinif> DinamikUrunListesi()
        {
            List<dinamikchartsinif> snf = new List<dinamikchartsinif>();
            using (var c = new Context())
            {
                snf = c.Uruns.Select(x => new dinamikchartsinif
                {
                    stk = x.Stok,
                    urn = x.UrunAd
                }).ToList();
            }
            return snf;
        }

    }
}