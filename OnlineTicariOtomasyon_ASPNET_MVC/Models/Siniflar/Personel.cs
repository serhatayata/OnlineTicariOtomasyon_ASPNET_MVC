using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Display(Name = "Personel Adı")]
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string PersonelAd { get; set; }
        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string PersonelSoyad { get; set; }
        [Display(Name = "Görsel")]
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string PersonelGorsel { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public bool Durum { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string Adres { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Mail { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string Hakkımda { get; set; }
        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }
    }
}