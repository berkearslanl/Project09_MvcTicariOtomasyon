using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Aciklama { get; set; }

        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }

        public bool Durum { get; set; }

        public int FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}