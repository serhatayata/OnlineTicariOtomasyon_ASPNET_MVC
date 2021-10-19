using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string FaturaSiraNo { get; set; }
        public string Tarih { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(60)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string TeslimEden { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string TeslimAlan { get; set; }
        public bool Durum { get; set; }
        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}