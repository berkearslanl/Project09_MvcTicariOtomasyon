using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string UrunBilgi { get; set; }
    }
}