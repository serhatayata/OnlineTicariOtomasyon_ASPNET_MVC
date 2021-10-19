using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon_ASPNET_MVC.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<Personel> Personels { get; set; }
    }
}