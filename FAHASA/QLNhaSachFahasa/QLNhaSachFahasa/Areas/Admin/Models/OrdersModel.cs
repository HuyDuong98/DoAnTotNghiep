using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class OrdersModel
    {
        public string MaDDH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public decimal PhiShip { get; set; }
        public decimal TongTien { get; set; }
        public decimal TongNhap { get; set; }
        public int? TrangThai { get; set; }
        public string TenNguoiCapNhat { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string HinhThucThanhToan { get; set; }
    }
    public class OrderDetailModel
    {
        public string MaDDH { get; set; }
        public string MaSanPham  { get; set; }
        public string TenSanPham { get; set; }
        public string MauSac { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }
        public string Link { get; set; }
    }
}