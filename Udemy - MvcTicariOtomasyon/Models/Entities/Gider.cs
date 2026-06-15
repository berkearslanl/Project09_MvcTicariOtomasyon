using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }

        public bool Durum { get; set; }
    }
}