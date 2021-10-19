using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
using System;
using System.Collections;
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
        #region Index2 : Chart Kullanim
        public ActionResult Index2()
        {
            var grafikciz = new Chart(width: 600, height: 600);
            grafikciz.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries(name: "Değerler", xValue: new[] { "Beyaz Eşya", "Telefon", "Küçük Ev Aleti", "Bilgisayar", "XBOX" }, yValues: new[] { 85, 66, 22, 33, 69 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        #endregion

        Context db = new Context();
        #region Chart Kullanım Veritabanı ile
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = db.Urunlers.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(x => yvalue.Add(x.Stok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Stoklar").AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        #endregion
        public ActionResult Index4()
        {
            return View();

        }
        #region Google Chart Kullanım1
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Chart1> Urunlistesi()
        {
            List<Chart1> snf = new List<Chart1>();
            snf.Add(new Chart1()
            {
                UrunAd = "Bilgisayar",
                Stok = 120
            });
            snf.Add(new Chart1()
            {
                UrunAd = "Çamaşır Makinesi",
                Stok = 50
            });
            snf.Add(new Chart1()
            {
                UrunAd = "Saç Kurutma Makinesi",
                Stok = 50
            });
            snf.Add(new Chart1()
            {
                UrunAd = "Mobilya",
                Stok = 54
            });
            snf.Add(new Chart1()
            {
                UrunAd = "Küçük Ev Aletleri",
                Stok = 23
            });
            return snf;
        }
        #endregion
        public ActionResult ChartPie()
        {
            return View();
        }
       public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<Chart2> UrunListesi2()
        {
            List<Chart2> list = new List<Chart2>();
            using (var c = new Context())
            {
                list = c.Urunlers.Select(x => new Chart2 { Urn = x.UrunAd, Stk = x.Stok }).ToList();

            }
            return list;
        }
        public ActionResult ChartLine()
        {
            return View();
        }
        public ActionResult ChartColumn()
        {
            return View();
        }
    }
}