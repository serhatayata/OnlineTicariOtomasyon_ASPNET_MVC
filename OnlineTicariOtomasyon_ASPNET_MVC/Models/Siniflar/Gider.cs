using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}