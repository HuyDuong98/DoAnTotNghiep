using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class HinhAnhSPModel
    {
        [Key]
        public string LINKHINHANH { get; set; }
        public string IDSANPHAM { get; set; }
        public string TENHINHANH { get; set; }
    }
}