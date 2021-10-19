using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
using PagedList.Mvc;
using PagedList;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context db = new Context();  
        public ActionResult Index(int? page)
        {
            DetayViewModel cs = new DetayViewModel();
            cs.Deger1 = db.Urunlers.ToList();
            cs.Deger2 = db.Detays.ToList();
            return View(cs);
        }
        public PartialViewResult UrunDetayPartial()
        {
            return PartialView();
        }
    }
}