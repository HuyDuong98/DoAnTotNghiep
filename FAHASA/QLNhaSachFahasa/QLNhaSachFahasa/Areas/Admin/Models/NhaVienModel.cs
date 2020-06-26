using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class NhaVienModel
    {
        [Key]
        public string MANHANVIEN { get; set; }
        public string TENNHANVIEN { get; set; }
        public string TENDANGNHAPNHANVIEN { get; set; }
        public string MATKHAUNHANVIEN { get; set; }
        [Compare("MATKHAUNHANVIEN", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfimPassword { get; set; }
        public string DIACHINHANVIEN { get; set; }
        public string SDT { get; set; }
        public DateTime? NGAYTAO { get; set; }
        public string EMAIL { get; set; }
        public bool TRANGTHAI { get; set; }
        public string MANHOMNGUOIDUNG { get; set; }
        public DateTime? NGAYSINH { get; set; }
        public string CMND { get; set; }
        public string HINHANH { get; set; }
        public string LOAIHINHCONGVIEC { get; set; }
        public string CHUCVU { get; set; }

        //Hiển thị tên group
        public string NameGroup { get; set;}
    }
}