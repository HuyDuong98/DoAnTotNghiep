using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Models
{
    public class DonHangModel
    {
        public string idDonHang { get; set; }
        public string idCustomer { get; set; }
        public DateTime CreateDate { get; set; }
        public string idProduct { get; set; }
        public int soluong { get; set; }
        public decimal thanhtien { get; set; }
        public string nameProduct { get; set; }
        public string linkImage { get; set; }
        public string phuongThucTT { get; set; }
    }
}