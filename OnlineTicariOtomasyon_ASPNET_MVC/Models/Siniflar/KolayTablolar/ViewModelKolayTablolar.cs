using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar.KolayTablolar
{
    public class ViewModelKolayTablolar
    {
        public IEnumerable<CariSehirler> CariSehirs { get; set; }
        public IEnumerable<StokMiktari> StokMiktaris { get; set; }
    }
}