using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Urunlers.Where(x=>x.Durum == true).ToList();
            return View(degerler);
        }
    }
}