using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string FaturaSıraNo { get; set; }

        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string TeslimAlan { get; set; }

        public bool Durum { get; set; }

        public decimal Toplam { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}