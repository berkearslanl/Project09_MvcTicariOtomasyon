using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Udemy___MvcTicariOtomasyon.Models.Entities
{
    public class dFatura
    {
        public IEnumerable<Fatura> Faturas { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalems { get; set; }
    }
}