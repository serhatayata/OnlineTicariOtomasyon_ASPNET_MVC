using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context db = new Context();
        public ActionResult Index()
        {
            int toplamSatisSayisi = db.SatisHarekets.Count();
            ViewBag.ToplamSatisSayisi = toplamSatisSayisi;
            var degerler = db.SatisHarekets.Where(x=> x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in db.Urunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }
                                           ).ToList();
            List<SelectListItem> deger2 = (from x in db.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd +" "+x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }
                                         ).ToList();
            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }
                                        ).ToList();
            ViewBag.urun = deger1;
            ViewBag.cari = deger2;
            ViewBag.personel = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            s.Durum = true;
            db.SatisHarekets.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Urunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }
                                          ).ToList();
            List<SelectListItem> deger2 = (from x in db.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }
                                         ).ToList();
            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }
                                        ).ToList();
            ViewBag.urun = deger1;
            ViewBag.cari = deger2;
            ViewBag.personel = deger3;
            var deger = db.SatisHarekets.Find(id);
            return View(deger);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var deger = db.SatisHarekets.Find(s.SatisID);
            deger.UrunID = s.UrunID;
            deger.PersonelID = s.PersonelID;
            deger.CariID = s.CariID;
            deger.Adet = s.Adet;
            deger.Fiyat = s.Fiyat;
            deger.Tarih = s.Tarih;
            deger.ToplamTutar = s.ToplamTutar;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var satisid = db.SatisHarekets.Where(x => x.SatisID == id).Select(y => y.SatisID).First();
            ViewBag.satisID=satisid;
            var deger = db.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(deger);
        }
        public ActionResult SatisSil(int id)
        {
            var deger = db.SatisHarekets.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}