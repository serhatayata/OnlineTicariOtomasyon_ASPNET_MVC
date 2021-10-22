using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context db = new Context();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        public PartialViewResult Partial1(Cariler cr)
        {
            cr.Durum = true;
            db.Carilers.Add(cr);
            db.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult Partial2()
        {
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Partial2(Cariler p)
        {
            var bilgiler = db.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre && x.Durum==true);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail,false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult AdminGiris()
        {
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AdminGiris(Admin p)
        {
            var bilgiler = db.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index","Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
