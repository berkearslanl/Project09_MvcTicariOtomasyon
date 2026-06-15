using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Mesaj
    {
        [Key]
        public int MesajId { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girişi yapabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Gönderici { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girişi yapabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Alici { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girişi yapabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Konu { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(2000, ErrorMessage = "En fazla 2000 karakter girişi yapabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string icerik { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Tarih { get; set; }
    }
}