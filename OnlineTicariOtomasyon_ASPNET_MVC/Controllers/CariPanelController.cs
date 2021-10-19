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
            var mesajlar = db.Mesajlars.ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
    }
}