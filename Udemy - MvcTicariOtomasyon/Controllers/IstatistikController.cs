using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy___MvcTicariOtomasyon.Models.EfContext;

namespace Udemy___MvcTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();//toplam cari sayısı
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();//toplam ürün sayısı
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();//toplam personel sayısı
            ViewBag.d3 = deger3;

            var deger4 = c.Kategoris.Count().ToString();//toplam kategori sayısı
            ViewBag.d4 = deger4;

            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();//toplam stok sayısı
            ViewBag.d5 = deger5;

            var deger6 = c.Uruns.Select(x => x.Marka).Distinct().Count().ToString();//tekrarsız marka sayısı
            ViewBag.d6 = deger6;

            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString();//stok sayısı 20den az olan ürün sayısı(kritik ürün)
            ViewBag.d7 = deger7;

            var deger8 = c.Uruns.OrderByDescending(x => x.SatisFiyat).Select(y => y.UrunAd).FirstOrDefault();//satış fiyatı en yüksek olan ürün adı
            ViewBag.d8 = deger8;

            var deger9 = c.Uruns.OrderBy(x => x.SatisFiyat).Select(y => y.UrunAd).FirstOrDefault();//satış fiyatı en düşük olan ürün adı
            ViewBag.d9 = deger9;

            var deger10 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(x => x.Key).FirstOrDefault();//max marka -- key değeri gruplandırdığımız veride seçilen alandır
            ViewBag.d10 = deger10;

            var deger11 = c.Uruns.Count(x => x.UrunAd == "Buzdolabi").ToString();//buzdolabı adedi
            ViewBag.d11 = deger11;

            var deger12 = c.Uruns.Where(x => x.KategoriId == (c.Kategoris.Where(z => z.KategoriAd == "Bilgisayar").Select(y => y.KategoriId).FirstOrDefault())).Count().ToString();//laptop adedi
            //var deger12 = c.Uruns.Count(x => x.Kategori.KategoriAd == "Bilgisayar").ToString();
            ViewBag.d12 = deger12;

            var deger13 = c.Uruns.Where(t => t.UrunId == (c.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();//en çok satan ürün
            ViewBag.d13 = deger13;
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();//kasadaki toplam tutar
            ViewBag.d14 = deger14;

            var bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih.Year == bugun.Year && x.Tarih.Month == bugun.Month && x.Tarih.Day == bugun.Day).ToString();//bugünkü satış adedş
            ViewBag.d15 = deger15;

            var deger16 = c.SatisHarekets.Where(x => x.Tarih.Year == bugun.Year && x.Tarih.Month == bugun.Month && x.Tarih.Day == bugun.Day).Sum(y => (decimal?)y.ToplamTutar) ?? 0;//bugünkü satışların toplam tutarı
            ViewBag.d16 = deger16;
            return View();
        }
    }
}