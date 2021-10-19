using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(width: 600, height: 600);
            grafikciz.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries(name:"Değerler",xValue:new[] { "Beyaz Eşya", "Telefon", "Küçük Ev Aleti", "Bilgisayar", "XBOX" },yValues:new[] { 85,66,22,33,69 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(),"image/jpeg");
        }
    }
}