using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string PersonelSoyad { get; set; }

        [Display(Name = "Personel Görseli")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string PersonelGorsel { get; set; }

        public int DepartmantId { get; set; }
        public virtual Departmant Departmant { get; set; }

        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}