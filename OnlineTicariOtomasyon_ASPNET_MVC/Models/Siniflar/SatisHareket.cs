using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class SatisHareket 
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public int UrunID { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public int CariID { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public int PersonelID { get; set; }
        public bool Durum { get; set; }
        public virtual Urunler Urunler { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}