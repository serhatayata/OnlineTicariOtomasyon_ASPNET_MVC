using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var cariMail = (string)Session["CariMail"];
            var degerler = db.Carilers.Where(x=>x.Durum==true).FirstOrDefault(x => x.CariMail == cariMail);
            ViewBag.m = cariMail;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(Cariler p)
        {
            var deger = db.Carilers.Where(x => x.Durum == true && x.CariMail == p.CariMail).FirstOrDefault();
            deger.CariAd = p.CariAd;
            deger.CariSoyad = p.CariSoyad;
            deger.CariSehir = p.CariSehir;
            deger.CariSifre = p.CariSifre;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = db.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y=>y.CariID).FirstOrDefault();
            var degerler = db.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = db.Mesajlars.Where(x=>x.Alici==mail && x.Durum==true).OrderByDescending(x => x.Tarih).ToList();
            var gelenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Alici == mail).ToString();
            ViewBag.GelenSayi = gelenSayisi;
            var gidenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Gonderen == mail).ToString();
            ViewBag.GidenSayi = gidenSayisi;
            var geriDonusumSayisi = db.Mesajlars.Where(x => x.Durum == false).Count().ToString();
            ViewBag.GeriDonusumSayisi = geriDonusumSayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = db.Mesajlars.Where(x => x.Gonderen == mail && x.Durum ==true).OrderByDescending(x => x.Tarih).ToList();
            var gidenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Gonderen == mail).ToString();
            ViewBag.GidenSayi = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Alici == mail).ToString();
            ViewBag.GelenSayi = gelenSayisi;
            var geriDonusumSayisi = db.Mesajlars.Where(x => x.Durum == false).Count().ToString();
            ViewBag.GeriDonusumSayisi = geriDonusumSayisi;
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = db.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gidenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Gonderen == mail).ToString();
            ViewBag.GidenSayi = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Alici == mail).ToString();
            ViewBag.GelenSayi = gelenSayisi;
            var geriDonusumSayisi = db.Mesajlars.Where(x => x.Durum == false).Count().ToString();
            ViewBag.GeriDonusumSayisi = geriDonusumSayisi;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gidenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Gonderen == mail).ToString();
            ViewBag.GidenSayi = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Alici == mail).ToString();
            ViewBag.GelenSayi = gelenSayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderen = mail;
            m.Durum = true;
            db.Mesajlars.Add(m);
            db.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }
        public ActionResult GeriDonusumKutusu()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = db.Mesajlars.Where(x => x.Durum == false && x.Gonderen == mail || x.Alici == mail).OrderByDescending(x => x.Tarih).ToList();
            var gidenSayisi = db.Mesajlars.Where(x=>x.Durum==true).Count(x => x.Gonderen == mail).ToString();
            ViewBag.GidenSayi = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Alici == mail).ToString();
            ViewBag.GelenSayi = gelenSayisi;
            var geriDonusumSayisi = db.Mesajlars.Where(x => x.Durum == false).Count().ToString();
            ViewBag.GeriDonusumSayisi = geriDonusumSayisi;
            return View(mesajlar);
        }
        [HttpPost]
        public ActionResult GelenKutusuMesajAra(string icerik)
        {
            var mail = (string)Session["CariMail"];
            var deger = db.Mesajlars.Where(x => x.Alici == mail && x.Durum==true).Where(x => x.Icerik.Contains(icerik) || x.Gonderen.Contains(icerik) || x.Alici.Contains(icerik) || x.Konu.Contains(icerik) || x.Tarih.ToString().Contains(icerik)).ToList();
            var gidenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Gonderen == mail).ToString();
            ViewBag.GidenSayi = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Alici == mail).ToString();
            ViewBag.GelenSayi = gelenSayisi;
            var geriDonusumSayisi = db.Mesajlars.Where(x => x.Durum == false).Count().ToString();
            ViewBag.GeriDonusumSayisi = geriDonusumSayisi;
            return View("GelenMesajlar", deger);
        }
        public ActionResult GidenKutusuMesajAra(string icerik)
        {
            var mail = (string)Session["CariMail"];
            var deger = db.Mesajlars.Where(x=>x.Gonderen == mail && x.Durum==true).Where(x => x.Icerik.Contains(icerik) || x.Gonderen.Contains(icerik) || x.Alici.Contains(icerik) || x.Konu.Contains(icerik) || x.Tarih.ToString().Contains(icerik)).ToList();
            var gidenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Gonderen == mail).ToString();
            ViewBag.GidenSayi = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Alici == mail).ToString();
            ViewBag.GelenSayi = gelenSayisi;
            var geriDonusumSayisi = db.Mesajlars.Where(x => x.Durum == false).Count().ToString();
            ViewBag.GeriDonusumSayisi = geriDonusumSayisi;
            return View("GidenMesajlar", deger);
        }
        public ActionResult GeriDonusumKutusuMesajAra(string icerik)
        {
            var mail = (string)Session["CariMail"];
            var deger = db.Mesajlars.Where(x => x.Durum == false && x.Gonderen == mail || x.Alici==mail ).Where(x => x.Icerik.Contains(icerik) || x.Gonderen.Contains(icerik) || x.Alici.Contains(icerik) || x.Konu.Contains(icerik) || x.Tarih.ToString().Contains(icerik)).ToList();
            var gidenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Gonderen == mail).ToString();
            ViewBag.GidenSayi = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Where(x => x.Durum == true).Count(x => x.Alici == mail).ToString();
            ViewBag.GelenSayi = gelenSayisi;
            var geriDonusumSayisi = db.Mesajlars.Where(x => x.Durum == false).Count().ToString();
            ViewBag.GeriDonusumSayisi = geriDonusumSayisi;
            return View("GeriDonusumKutusu", deger);
        }
        public ActionResult MesajSil(int id)
        {
            var deger = db.Mesajlars.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }



    }
}