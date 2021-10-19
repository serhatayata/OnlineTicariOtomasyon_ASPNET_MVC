using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string UrunAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public short Stok { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public decimal AlisFiyati { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string UrunGorsel { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public int KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}

