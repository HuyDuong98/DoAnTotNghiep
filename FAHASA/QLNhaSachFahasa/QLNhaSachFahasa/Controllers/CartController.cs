using Model.Dao;
using QLNhaSachFahasa.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNhaSachFahasa.Common;
using Model.EF;

namespace QLNhaSachFahasa.Controllers
{
    public class CartController : FahasaController
    {
        //private const string CartSesstion = "CartSesstion";
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataOrderBox()
        {
            var cart = (List<CartModel>)Session[CartSession.CartSesstion];
            ProductOrderModel order = new ProductOrderModel();
            if (cart != null && cart.Count != 0)
            {
                foreach (var item in cart)
                {
                    order.Provisional += item.SOLUONG * item.SANPHAM.GIABAN;
                }
                if (order.Provisional > 300000)
                {
                    order.DeliveryCharges = "Free";
                    order.Total += order.Provisional;
                }
                else
                {
                    order.DeliveryCharges = "30000 ₫";
                    order.Total = order.Provisional + 30000;
                }
            }
            else
            {
                order.Provisional = 0;
                order.DeliveryCharges = "Free";
                order.Total = 0;
            }
            return Json(order, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDataInfoCustomerOrder()
        {
            var infor = (InfoOrderModel)Session[CartSession.OrderSesstion];
            var session = (UserLogin)Session[CommonConstants.USER_SEESION];
            InfoOrderModel order = new InfoOrderModel();
            if (infor == null)
            {
                if (session != null)
                {
                    var customer = new UserDao().GetById(session.UserName);
                    order.Name = customer.TENKHACHHANG;
                    order.PhoneNumber = customer.DIENTHOAI;
                    order.Address = customer.DIACHI;
                    order.Email = customer.EMAIL;
                    Session.Add(CartSession.OrderSesstion, order);
                }
            }
            else
            {
                order.Name = infor.Name;
                order.PhoneNumber = infor.PhoneNumber;
                order.Address = infor.Address;
                order.Email = infor.Email;
            }
            return Json(order, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderBox()
        {
            return PartialView("_OrderBox");
        }
        public ActionResult GetListCart()
        {
            var cart = (List<CartModel>)Session[CartSession.CartSesstion];
            var list = new List<CartItemViewModel>();
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    string chuongtrinhkhuyenmai = new SanPhamDao().getChuongTrinhKhuyenMai(item.SANPHAM.MASANPHAM);
                    list.Add(new CartItemViewModel
                    {
                        
                        MASANPHAM = item.SANPHAM.MASANPHAM,
                        TENSANPHAM = item.SANPHAM.TENSANPHAM,
                        LOAIMATHANG = item.SANPHAM.LOAIMATHANG,
                        GIABAN = item.SANPHAM.GIABAN,
                        MAUSAC = item.SANPHAM.MAUSAC,
                        LINKHINHANH = item.SANPHAM.LINKHINHANH,
                        SOLUONGMUA = item.SOLUONG,
                        SOLUONGTON = item.SANPHAM.SOLUONG,
                        TACGIA = item.SANPHAM.TACGIA,
                        DONGIA = item.SANPHAM.GIABAN,
                        CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai
                    });
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddIItem(string maSanPham, int soluong)
        {
            var dao = new BookDao().ViewDetail(maSanPham);
            var giaban = new SanPhamDao().getGiaBan(maSanPham);
            var dongiaban = dao.DONGIA;
            string chuongtrinhkhuyenmai = new SanPhamDao().getChuongTrinhKhuyenMai(maSanPham);
            if (giaban != null)
            {
                dongiaban = giaban.DONGIABAN;
            }
            var hinhanh = new SanPhamDao().getListImages(maSanPham);
            var model = new SanPhamModel()
            {
                MASANPHAM = dao.MASANPHAM,
                TENSANPHAM = dao.TENSANPHAM,
                LOAIMATHANG = dao.PHANLOAI,
                NGONNGU = dao.NGONNGU,
                HINHTHUC = dao.HINHTHUC,
                TACGIA = dao.TACGIA,
                DONGIA = dao.DONGIA,
                NHAXUATBAN = dao.NHAXUATBAN,
                MAUSAC = dao.MAUSAC,
                SOLUONG = (int)dao.SOLUONG,
                GIABAN = dongiaban,
                LINKHINHANH = hinhanh[0].LINKHINHANH,
                CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai
            };
            var cart = Session[CartSession.CartSesstion];
            if (cart != null)
            {
                var list = (List<CartModel>)cart;
                if (list.Exists(x => x.SANPHAM.MASANPHAM == maSanPham))
                {
                    foreach (var item in list)
                    {
                        if (item.SANPHAM.MASANPHAM == maSanPham)
                        {
                            item.SOLUONG += soluong;
                        }
                    }
                }
                else
                {
                    var item = new CartModel();
                    item.SANPHAM = model;
                    item.SOLUONG = soluong;
                    list.Add(item);
                }
                Session.Add(CartSession.CartSesstion, list);
            }
            else
            {
                var item = new CartModel();
                item.SANPHAM = model;
                item.SOLUONG = soluong;
                var list = new List<CartModel>();
                list.Add(item);
                //Session[CartSession.CartSesstion] = list;
                Session.Add(CartSession.CartSesstion, list);
            }
            //return RedirectToAction("Index");
            var res = (List<CartModel>)Session[CartSession.CartSesstion];
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateQuantity(int quantity, string id)
        {
            var cart = (List<CartModel>)Session[CartSession.CartSesstion];
            int res = 0;
            foreach (var item in cart)
            {
                if (item.SANPHAM.MASANPHAM == id)
                {
                    item.SOLUONG = quantity;
                    res = 1;
                }
            }
            Session.Add(CartSession.CartSesstion, cart);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteProductInSession(string idProduct)
        {
            var cart = (List<CartModel>)Session[CartSession.CartSesstion];
            var itemCart = cart.Single(x => x.SANPHAM.MASANPHAM == idProduct);
            cart.Remove(itemCart);
            Session.Add(CartSession.CartSesstion, cart);
            var list = new List<CartItemViewModel>();
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    list.Add(new CartItemViewModel
                    {
                        MASANPHAM = item.SANPHAM.MASANPHAM,
                        TENSANPHAM = item.SANPHAM.TENSANPHAM,
                        LOAIMATHANG = item.SANPHAM.LOAIMATHANG,
                        GIABAN = item.SANPHAM.GIABAN,
                        MAUSAC = item.SANPHAM.MAUSAC,
                        LINKHINHANH = item.SANPHAM.LINKHINHANH,
                        SOLUONGMUA = item.SOLUONG,
                        SOLUONGTON = item.SANPHAM.SOLUONG,
                        TACGIA = item.SANPHAM.TACGIA,
                        DONGIA = item.SANPHAM.GIABAN,
                        CHUONGTRINHKHUYENMAI = item.SANPHAM.CHUONGTRINHKHUYENMAI
                    });
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateInfoOrderView()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SEESION];
            CustomerModel model = new CustomerModel();
            if (session != null)
            {
                var customer = new UserDao().GetById(session.UserName);
                model = new CustomerModel()
                {
                    MAKH = customer.MAKHACHHANG,
                    TENKH = customer.TENKHACHHANG,
                    DIACHI = customer.DIACHI,
                    EMAIL = customer.EMAIL,
                    DIENTHOAI = customer.DIENTHOAI
                };
            }
            return PartialView("_UpdateInfoOrder",model);
        }
        public ActionResult UpdateInfo(CustomerModel model)
        {
            var info = new InfoOrderModel()
            {
                Name = model.TENKH,
                PhoneNumber = model.DIENTHOAI,
                Address = model.DIACHI,
                Email = model.EMAIL
            };
            Session.Add(CartSession.OrderSesstion, info);
            return Json(info, JsonRequestBehavior.AllowGet);

        }
    }
}