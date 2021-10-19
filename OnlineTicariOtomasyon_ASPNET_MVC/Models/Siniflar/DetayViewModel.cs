using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class DetayViewModel
    {
        public IEnumerable<Urunler> Deger1 { get; set; }
        public IEnumerable<Detay> Deger2  { get; set; }
    }
}