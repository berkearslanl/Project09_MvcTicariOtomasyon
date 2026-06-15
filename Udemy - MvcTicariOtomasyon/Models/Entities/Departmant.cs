using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class Departmant
    {
        [Key]
        public int DepartmantId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string DepartmantAd { get; set; }

        public bool Durum { get; set; }

        public ICollection<Personel> Personels { get; set; }
    }
}