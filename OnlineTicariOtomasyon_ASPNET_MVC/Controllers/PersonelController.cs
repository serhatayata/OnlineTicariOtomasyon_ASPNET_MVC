using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context db = new Context();
        public ActionResult Index()
        {
            int personelSayi = db.Personels.Where(x=>x.Durum == true).Count();
            ViewBag.PersonelSayi = personelSayi;
            var degerler = db.Personels.Where(x=>x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }
                                          ).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaAdi + uzanti;
            }
            p.Durum = true;
            db.Personels.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }
                                        ).ToList();
            ViewBag.dgr1 = deger1;
            var d = db.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dgr = d;
            var deger = db.Personels.Find(id);
            return View(deger);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaAdi + uzanti;
            }
            var prsn = db.Personels.Find(p.PersonelID);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.DepartmanID = p.DepartmanID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var deger = db.Personels.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var sorguToplam = db.Personels.Where(x => x.Durum == true).Count();
            var deger = db.Personels.Where(x => x.Durum == true).ToList();
            ViewBag.ToplamPersonel = sorguToplam;
            return View(deger);
        }
    }
}