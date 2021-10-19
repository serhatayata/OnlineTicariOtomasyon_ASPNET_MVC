using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class YapilacaklarController : Controller
    {
        // GET: Yapilacaklar
        Context db = new Context();
        public ActionResult Index()
        {
            var deger1 = db.Carilers.Where(x => x.Durum == true).Count().ToString();
            var deger2 = db.Urunlers.Where(x => x.Durum == true).Count().ToString();
            var deger3 = db.Kategoris.Count().ToString();
            var deger4 = (from x in db.Carilers where x.Durum == true select x.CariSehir).Distinct().Count().ToString();
            
            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;

            var liste = db.Yapilacaks.Where(x => x.Durum == true).ToList();

            return View(liste);
        }
        [HttpGet]
        public PartialViewResult YapilacakEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult YapilacakEkleDonen(Yapilacaklar list)
        {
            list.Durum = true;
            db.Yapilacaks.Add(list);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}