using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context db = new Context();
        public ActionResult Index()
        {
            var toplamFatura = db.Faturalars.Where(x => x.Durum == true).Select(y => y.FaturaID).Count();
            ViewBag.ToplamFatura=toplamFatura;
            var degerler = db.Faturalars.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            f.Durum = true;
            f.Tarih = DateTime.Now.ToString("MM/dd/yyyy");
            f.Saat = DateTime.Now.ToString("HH:mm");
            db.Faturalars.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaSil(int id)
        {
            var deger = db.Faturalars.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var deger = db.Faturalars.Find(id);
            return View(deger);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var deger = db.Faturalars.Find(f.FaturaID);
            deger.FaturaSiraNo = f.FaturaSiraNo;
            deger.FaturaSeriNo = f.FaturaSeriNo;
            deger.TeslimAlan = f.TeslimAlan;
            deger.TeslimEden = f.TeslimEden;
            deger.VergiDairesi = f.VergiDairesi;
            deger.Tarih = DateTime.Now.ToString("MM/dd/yyyy");
            deger.Saat = DateTime.Now.ToString("HH:mm");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var toplamSayi = db.FaturaKalems.Where(y=>y.Durum==true).Where(x => x.FaturaID == id).Count();
            ViewBag.ToplamSayi = toplamSayi;
            var deger = db.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniKalem(int id)
        {
            var deger = db.FaturaKalems.Where(x => x.FaturaID == id).FirstOrDefault();
            return View(deger);
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            p.Durum = true;
            db.FaturaKalems.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FaturaKalemGuncelle(int id)
        {
            var deger = db.FaturaKalems.Where(x => x.Durum == true).FirstOrDefault(x=>x.FaturaKalemID==id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult FaturaKalemGuncelle(FaturaKalem p)
        {
            var deger = db.FaturaKalems.Find(p.FaturaKalemID);
            deger.Aciklama = p.Aciklama;
            deger.Miktar = p.Miktar;
            deger.BirimFiyat = p.BirimFiyat;
            deger.Tutar = p.Tutar;
            db.SaveChanges();
            return RedirectToAction("Index","Fatura");
        }
      


    }
}