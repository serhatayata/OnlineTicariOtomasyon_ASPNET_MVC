using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public int Miktar { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public decimal BirimFiyat { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public decimal Tutar { get; set; }
        public bool Durum { get; set; }
        public int FaturaID { get; set; }
        public virtual Faturalar Faturalar { get; set; }
    }
}