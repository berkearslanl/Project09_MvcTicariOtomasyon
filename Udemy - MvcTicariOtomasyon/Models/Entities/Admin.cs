using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Sifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Yetki { get; set; }
    }
}