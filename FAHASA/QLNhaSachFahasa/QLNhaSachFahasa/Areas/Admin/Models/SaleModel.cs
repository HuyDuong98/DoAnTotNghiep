using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class SaleModel
    {
        public string MaCTKM { get; set; }
        public string TenCTKM { get; set; }
        public string MaThoiGian { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int PhanTramGiamGia { get; set; }
    }
}