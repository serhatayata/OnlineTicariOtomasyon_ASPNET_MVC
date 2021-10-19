using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar.KolayTablolar;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context db = new Context();
        public ActionResult Index()
        {
            var deger1 = db.Carilers.Where(x=>x.Durum == true).Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = db.Urunlers.Where(x => x.Durum == true).Count();
            ViewBag.d2 = deger2;
            var deger3 = db.Personels.Where(x => x.Durum == true).Count();
            ViewBag.d3 = deger3;
            var deger4 = db.Kategoris.Count();
            ViewBag.d4 = deger4;
            var deger5 = db.Urunlers.Where(x => x.Durum == true).Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in db.Urunlers
                          select x.Marka).Distinct().Count();
            ViewBag.d6 = deger6;
            var deger7 = db.Urunlers.Count(x => x.Stok <= 20);
            ViewBag.d7 = deger7;
            var deger8 = (from x in db.Urunlers
                          orderby x.SatisFiyati descending
                          select x.UrunAd
                          ).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in db.Urunlers
                          orderby x.SatisFiyati ascending
                          select x.UrunAd
                          ).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = db.Urunlers.Count(x=>x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = db.Urunlers.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = db.Urunlers.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y=> y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = db.Urunlers.Where(x=>x.UrunID == (db.SatisHarekets.GroupBy(y => y.UrunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = db.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            var deger15 = db.SatisHarekets.Count(x => x.Tarih == DateTime.Today).ToString();
            ViewBag.d15 = deger15;
            if (db.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Count() == 0 )
            {
                ViewBag.d16 = 0;
            }
            else
            {
                var deger16 = db.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Sum(x => x.ToplamTutar).ToString();
                ViewBag.d16 = deger16;
            }
            //  d16 nullable 2. çözüm
            // var deger16 = db.SatisHarekets.Where(x=>x.Tarih == DateTime.Today).Sum(x=>(decimal)?x.ToplamTutar).ToString();
            return View();
        }

        public ActionResult KolayTablolar()
        {
            ViewModelKolayTablolar vm = new ViewModelKolayTablolar();
            var sorgu = (from x in db.Carilers where x.Durum==true
                         group x by x.CariSehir into g
                         select new CariSehirler
                         {
                             Sehir = g.Key,
                             Toplam = g.Count()
                         }
                         ).OrderByDescending(y=>y.Toplam).Take(5);
            var sorgu2 = (from x in db.Urunlers
                          orderby x.Stok
                          select new StokMiktari
                          {
                              UrunAd = x.UrunAd,
                              StokAdet = x.Stok
                          }
                         ).OrderBy(x=>x.StokAdet).OrderByDescending(x=>x.StokAdet).Take(5);
            vm.CariSehirs = sorgu.ToList();
            vm.StokMiktaris = sorgu2;
            var SorguCariToplam1 = db.Carilers.Where(x => x.Durum == true).Select(y => y.CariSehir).Count();
            ViewBag.sorguCariToplam1 = (double)SorguCariToplam1;
            return View(vm);
        }
        public PartialViewResult Partial1()
        {
            var sorgu = (from x in db.Personels where x.Durum==true
                         join dp in db.Departmans on x.DepartmanID equals dp.DepartmanID
                         group x by new { x.DepartmanID, dp.DepartmanAd }  into g
                         select new PersonelDepartman
                         {
                             Departman = g.Key.DepartmanID,
                             DepartmanAd = g.Key.DepartmanAd,
                             Sayi = g.Count()
                         }
                        ).Take(5);
            var sorguToplam = db.Personels.Where(x => x.Durum == true).Count();
            ViewBag.ToplamPersonel = sorguToplam;
            return PartialView(sorgu.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = db.Carilers.Where(x => x.Durum == true).ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = db.Urunlers.Where(x => x.Durum == true).ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = (from x in db.Urunlers
                         group x by x.Marka into g
                         select new MarkaUrunMiktari
                         {
                             Marka = g.Key,
                             UrunAdet = g.Count()
                         }
                    ).Take(5);
            return PartialView(sorgu.ToList());
        }
    } 
}