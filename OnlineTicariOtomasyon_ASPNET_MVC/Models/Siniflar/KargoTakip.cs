using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipID { get; set; }
        [Display(Name = "Takip Kodu")]
        [Column(TypeName = "VarChar")]
        public string TakipKodu { get; set; }
        [Display(Name = "Açıklama")]
        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}