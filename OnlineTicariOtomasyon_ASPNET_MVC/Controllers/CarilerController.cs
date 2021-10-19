using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context db = new Context();
        public ActionResult Index()
        {
            int toplamCari = db.Carilers.Where(x => x.Durum == true).Count();
            ViewBag.ToplamCari = toplamCari;
            var degerler = db.Carilers.Where(x=> x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler p1)
        {
            p1.Durum = true;
            db.Carilers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var deger = db.Carilers.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = db.Carilers.Find(id);
            return View(cari);
        }
        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            else
            {
                var cari = db.Carilers.Find(p.CariID);
                cari.CariAd = p.CariAd;
                cari.CariSoyad = p.CariSoyad;
                cari.CariSehir = p.CariSehir;
                cari.CariMail = p.CariMail;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult CariSatis(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.CariID == id).ToList();
            var deger = db.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd +" "+ y.CariSoyad).FirstOrDefault();
            ViewBag.csts = deger.ToString();
            return View(degerler);
        }

    }
}