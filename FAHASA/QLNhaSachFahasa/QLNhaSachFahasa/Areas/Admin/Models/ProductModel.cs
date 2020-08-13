using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class ProductModel
    {
        public string MaSanPham { get; set; }
        public string PhanLoai { get; set; }
        public string HinhThuc { get; set; }
        public string TenSanPham { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiaBan { get; set; }
        public double TrongLuong { get; set; }
        public string KichThuoc { get; set; }
        public string QuocGia { get; set; }
        public string ChatLieu { get; set; }
        public string MauSac { get; set; }
        public string NhaSanXuat { get; set; }
        public string NhaCungCap { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }
        public int TrangThai { get; set; }
        public int LuotXem { get; set; }
        public bool select { get; set; }
    }
}