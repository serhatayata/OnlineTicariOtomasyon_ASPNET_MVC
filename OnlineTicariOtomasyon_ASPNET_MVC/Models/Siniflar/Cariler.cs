using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50,ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CariAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CariSehir { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CariMail { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CariSifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}