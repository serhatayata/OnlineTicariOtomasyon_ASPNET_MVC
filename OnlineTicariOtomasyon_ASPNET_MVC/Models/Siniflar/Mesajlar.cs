using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Gonderen { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Alici { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Konu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Icerik { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "SmallDateTime")]
        public DateTime Tarih { get; set; }
    }
}