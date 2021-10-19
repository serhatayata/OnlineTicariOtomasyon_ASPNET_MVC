using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context db = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in db.KargoDetays where x.Durum==true select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(x=>x.Durum==true).Where(y => y.TakipKodu.Contains(p));
            }
            var toplamKargo = db.KargoDetays.Where(x => x.Durum == true).Count();
            ViewBag.ToplamKargo = toplamKargo;
            return View(k.ToList());
        }
        [HttpGet] 
        public ActionResult KargoEkle()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D","E","F","G","H","I","K","L" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 999); 
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.TakipKod = kod;
            return View();
        }
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay k)
        {
            db.KargoDetays.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakip(string id)
        {
            var degerler = db.KargoTakips.Where(x=>x.TakipKodu==id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KargoGetir(int id)
        {
            var deger = db.KargoDetays.Where(x => x.Durum == true).FirstOrDefault();
            return View(deger);
        }
        [HttpPost]
        public ActionResult KargoGuncelle(KargoDetay k)
        {
            var deger = db.KargoDetays.Find(k.KargoDetayID);
            deger.Personel = k.Personel;
            deger.Alici = k.Alici;
            deger.Tarih = k.Tarih;
            deger.Aciklama = k.Aciklama;
            db.SaveChanges();
            return RedirectToAction("Index","Kargo");
        }
        public ActionResult KargoSil(int id)
        {
            var deger = db.KargoDetays.Where(x => x.Durum == true).FirstOrDefault();
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index","Kargo");
        }
    }
}