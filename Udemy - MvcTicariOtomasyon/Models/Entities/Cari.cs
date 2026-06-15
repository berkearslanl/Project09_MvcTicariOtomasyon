using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girişi yapabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girişi yapabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13, ErrorMessage = "En fazla 13 karakter girişi yapabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girişi yapabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girişi yapabilirsiniz!")]
        public string CariSifre { get; set; }

        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}