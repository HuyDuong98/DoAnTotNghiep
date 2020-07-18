using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class BookModel
    {
        [Key]
        public string MASACH { get; set; }
        public string IDLOAI { get; set; }
        public string MANGONNGU { get; set; }
        public string MAPHANLOAISACH { get; set; }
        public string MAHINHTHUC { get; set; }
        public string TENSACH { get; set; }
        public string TACGIA { get; set; }
        public decimal GIASACH { get; set; }
        public double? TRONGLUONG { get; set; }
        public int? SOTRANG { get; set; }
        public string KICHTHUOC { get; set; }
        public string TOMTAC { get; set; }
        public string NHAXUATBAN { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string  NGAYTAO { get; set; }
    }
}