using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string UrunAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string UrunBilgi { get; set; }

    }
}