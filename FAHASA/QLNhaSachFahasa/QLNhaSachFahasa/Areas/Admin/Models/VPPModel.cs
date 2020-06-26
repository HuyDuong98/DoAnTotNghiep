using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class VPPModel
    {
        [Key]
        public string MASP { get; set; }
        public string IDLOAI { get; set; }
        public string MAQUOCGIA { get; set; }
        public string MAPLVPP { get; set; }
        public string TENSP { get; set; }
        public float? TRONGLUONG { get; set; }
        public string KICHTHUOC { get; set; }
        public string GIOITHIEUSP { get; set; }
        public string CHATLIEU { get; set; }
        public string MAUSAC { get; set; }
    }
}