using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string KullaniciAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Sifre { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Yetki { get; set; }
    }
}