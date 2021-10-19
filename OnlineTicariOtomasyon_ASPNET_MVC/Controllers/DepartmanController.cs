using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context db = new Context();
        public ActionResult Index()
        {
            int toplamDepartman = db.Departmans.Where(x => x.Durum == true).Count();
            ViewBag.ToplamDepartman = toplamDepartman;
            var degerler = db.Departmans.Where(x=> x.Durum == true).ToList();
            return View(degerler); 
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            d.Durum = true;
            db.Departmans.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = db.Departmans.Find(id);
            dep.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var deger = db.Departmans.Find(id);
            return View(deger);
        }
        public ActionResult DepartmanGuncelle(Departman dep)
        {
            var depart = db.Departmans.Find(dep.DepartmanID);
            depart.DepartmanAd = dep.DepartmanAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = db.Personels.Where(x => x.DepartmanID == id).ToList();
            var dpt = db.Departmans.Where(x=> x. DepartmanID == id ).Select(y=> y.DepartmanAd).FirstOrDefault();
            ViewBag.detayDpt = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = db.SatisHarekets.Where(x=> x.PersonelID == id).ToList();
            ViewBag.DepPer = db.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).First();
            return View(degerler);
        }
    }
}