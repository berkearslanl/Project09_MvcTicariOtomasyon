using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Yapilacaklar
    {
        [Key]
        public int YapilacaklarId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(100,ErrorMessage = "En fazla 100 karakter girişi yapabilirsiniz!")]
        public string Baslik { get; set; }

        [Column(TypeName ="Date")]
        [Required(ErrorMessage = "Tarih alanı boş bırakılamaz!")]
        public DateTime Tarih { get; set; }

        [Column(TypeName ="bit")]
        public bool Durum { get; set; }
    }
}