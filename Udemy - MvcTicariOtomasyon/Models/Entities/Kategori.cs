using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string KategoriAd { get; set; }

        public ICollection<Urun> Uruns { get; set; }
    }
}