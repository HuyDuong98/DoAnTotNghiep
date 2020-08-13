using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Models
{
    public class SanPhamModel
    {
        public string MASANPHAM { get; set; }
        public string LOAIMATHANG { get; set; }
        public string NGONNGU { get; set; }
        public string HINHTHUC { get; set; }
        public string TENSANPHAM { get; set; }
        public string TACGIA { get; set; }
        public decimal DONGIA { get; set; }
        public float TRONGLUONG { get; set; }
        public int SOTRANG { get; set; }
        public string KICHTHUOC { get; set; }
        public string NHAXUATBAN { get; set; }
        public string GHICHU { get; set; }
        public string QUOCGIA { get; set; }
        public string CHATLIEU { get; set; }
        public string MAUSAC { get; set; }
        public string NHASANXUAT { get; set; }
        public int? SOLUONG { get; set; }
        public string NGUOITAO { get; set; }
        public DateTime? NGAYTAO { get; set; }
        public string NGUOICAPNHAT { get; set; }
        public DateTime? NGAYCAPNHAT { get; set; }
        public int TRANGTHAI { get; set; }
        public decimal GIABAN { get; set; }
        public string LINKHINHANH { get; set; }
        public string CHUONGTRINHKHUYENMAI { get; set; }
        public int? LUOTXEM { get; set; }
        public List<ImagesModel> HINHANH { get; set; }
        public int NHAP { get; set; }
        public int XUAT { get; set; }
        public int TON { get;set; }
        public int PhanTram { get; set; }
    }
}