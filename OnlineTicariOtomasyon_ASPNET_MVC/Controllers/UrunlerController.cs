using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        Context db = new Context();
        public ActionResult Index()
        {
            var urunler = db.Urunlers.Where(x=> x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd, Value=x.KategoriID.ToString()
                                           }
                                           ).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        public ActionResult UrunEkle(Urunler p1)
        {
            db.Urunlers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = db.Urunlers.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }
                                          ).ToList();
            ViewBag.dgr1 = deger1;
            var deger = db.Urunlers.Find(id);
            return View("UrunGetir",deger);
        }
        public ActionResult UrunGuncelle(Urunler p1)
        {
            var deger = db.Urunlers.First(x => x.UrunID == p1.UrunID);
            deger.UrunAd = p1.UrunAd;
            deger.KategoriID = p1.KategoriID;
            deger.Marka = p1.Marka;
            deger.Stok = p1.Stok;
            deger.AlisFiyati = p1.SatisFiyati;
            deger.SatisFiyati = p1.SatisFiyati;
            deger.UrunGorsel = p1.UrunGorsel;
            deger.Durum = p1.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personel = (from x in db.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }
                                        ).ToList();
            var deger = db.Urunlers.Find(id);
            ViewBag.urunid = deger.UrunID;
            ViewBag.fiyat = deger.SatisFiyati;
            ViewBag.personel = personel;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            s.Durum = true;
            db.SatisHarekets.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}