using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Models
{
    [Serializable]
    public class CartModel
    {
        public SanPhamModel SANPHAM { get; set; }
        public int SOLUONG { get; set; }
    }
}