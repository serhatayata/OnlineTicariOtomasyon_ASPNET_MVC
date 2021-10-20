using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori 
        Context db = new Context(); 
        public ActionResult Index() 
        {
            int toplamKategori = db.Kategoris.Count();
            ViewBag.ToplamKategori = toplamKategori;
            var degerler = db.Kategoris.ToList();
            return View(degerler);
        }
       
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori p1)
        {
            db.Kategoris.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.Kategoris.Find(id);
            db.Kategoris.Remove(ktg);
            db.SaveChanges(); 
            return RedirectToAction("Index");
        }
        
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(Kategori p1)
        {
            var ktg = db.Kategoris.Find(p1.KategoriID);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}