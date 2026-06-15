using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Personel { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Alici { get; set; }

        public DateTime Tarih { get; set; }
    }
}