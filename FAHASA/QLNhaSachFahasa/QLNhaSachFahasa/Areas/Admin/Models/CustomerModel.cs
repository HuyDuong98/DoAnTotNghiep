using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class CustomerModel
    {
        [Key]
        public string MAKH { get; set; }
        public string MANHOMNGUOIDUNG { get; set; }
        public string HOKH { get; set; }
        public string TENKH { get; set; }
        public string EMAIL { get; set; }
        public string DIENTHOAI { get; set; }
        public string QUOCGIA { get; set; }
        public string THANHPHO { get; set; }
        public string QUAN { get; set; }
        public string PHUONG { get; set; }
        public string DIACHI { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public DateTime? NGAYTAO { get; set; }
        public int TRANGTHAI { get; set; }

    }
}