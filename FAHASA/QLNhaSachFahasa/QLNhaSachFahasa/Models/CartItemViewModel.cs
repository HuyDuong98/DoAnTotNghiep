using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Models
{
    public class CartItemViewModel
    {
        public string MASANPHAM { get; set; }
        public string LOAIMATHANG { get; set; }
        public string TENSANPHAM { get; set; }
        public string MAUSAC { get; set; }
        public decimal GIABAN { get; set; }
        public string LINKHINHANH { get; set; }
        public int SOLUONGMUA { get; set; }
        public string TACGIA { get; set; }
        public decimal DONGIA { get; set; }
        public string CHUONGTRINHKHUYENMAI { get; set; }
        public int SOLUONGTON { get; set; }
    }
}