using OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class FaturaViewModel
    {
        public IEnumerable<Faturalar> deger1 { get; set; }
        public IEnumerable<FaturaKalem> deger2 { get; set; }
    }
}