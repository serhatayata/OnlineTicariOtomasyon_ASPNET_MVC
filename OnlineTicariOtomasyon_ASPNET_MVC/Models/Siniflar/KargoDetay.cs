using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayID { get; set; }
        [Display(Name = "Açıklama")]
        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string Aciklama { get; set; }
        [Display(Name = "Takip Kodu")]
        public string TakipKodu { get; set; }
        [StringLength(50)]
        public string Personel { get; set; }
        [Display(Name = "Takip Kodu")]
        [StringLength(50)]
        public string Alici { get; set; }
        public bool Durum { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Tarih { get; set; }
    }
}