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
        public ActionResult SearchOrder()
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
                    order.DeliveryCharges = 0;
                    order.Total += order.Provisional;
                }
                else
                {
                    order.DeliveryCharges = 30000;
                    order.Total = order.Provisional + 30000;
                }
            }
            else
            {
                order.Provisional = 0;
                order.DeliveryCharges = 0;
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
                    order.id = customer.MAKHACHHANG;
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
        public ActionResult GetInforDetailOrder(string idDH)
        {
            var order = new DonHangDao().GetDonHang(idDH);
            var listCT_DonHang = new DonHangDao().getListCTDH(idDH);
            var customer = new CustomerModel();
            decimal phiShip = 0;
            decimal tong = 0;
            foreach(var item in listCT_DonHang)
            {
                tong += item.SOLUONG * item.THANHTIEN;
            }
            if (tong < 300000)
            {
                phiShip = 30000;
            }
            if (order != null)
            {
                var cusdetail = new CustomerDao().ViewDetail(order.MAKHACHHANG);
                var pttt = new OrdersDao().GetPhuongThucThanhToan(order.MAPHUONGTHUCTHANHTOAN);
                customer.MAKH = cusdetail.MAKHACHHANG;
                customer.TENKH = cusdetail.TENKHACHHANG;
                customer.DIACHI = cusdetail.DIACHI;
                customer.DIENTHOAI = cusdetail.DIENTHOAI;
                customer.EMAIL = cusdetail.EMAIL;
                customer.NgayTaoDon = order.NGAYLAP;
                customer.PhuongThucThanhToan = pttt.TENPHUONGTHUCTHANHTOAN;
                customer.Ship = phiShip;
            }
            return Json(customer, JsonRequestBehavior.AllowGet);
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
                        DONGIA = item.SANPHAM.DONGIA,
                        CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai,
                        PhanTram = item.SANPHAM.PhanTram
                    });
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddIItem(string maSanPham, int soluong)
        {
            var dao = new BookDao().ViewDetail(maSanPham);
            var ctkm = new SanPhamDao().getCTKM(maSanPham);
            int phanTram = 0;
            string chuongtrinhkhuyenmai = "";
          
            var giaban = new SanPhamDao().getGiaBan(maSanPham);
            var dongiaban = dao.DONGIA;
            if (giaban != null)
            {
                dongiaban = giaban.DONGIABAN;
            }
            if (ctkm != null)
            {
                phanTram = (int)ctkm.MUCGIAMGIA;
                chuongtrinhkhuyenmai = ctkm.TENCHUONGTRINHKHUYENMAI;
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
                DONGIA = dongiaban,
                NHAXUATBAN = dao.NHAXUATBAN,
                MAUSAC = dao.MAUSAC,
                SOLUONG = (int)dao.SOLUONG,
                GIABAN = dongiaban - dongiaban * phanTram / 100,
                LINKHINHANH = hinhanh[0].LINKHINHANH,
                CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai,
                PhanTram = phanTram,
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
                    item.SOLUONG += soluong;
                    list.Add(item);
                }
                Session.Add(CartSession.CartSesstion, list);
            }
            else
            {
                var item = new CartModel();
                item.SANPHAM = model;
                item.SOLUONG = soluong;
                item.SANPHAM.GIABAN = model.GIABAN;
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
            if(cart != null)
            {
                foreach (var item in cart)
                {
                    if (item.SANPHAM.MASANPHAM == id)
                    {
                        item.SOLUONG = quantity;
                        res = 1;
                    }
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
            return PartialView("_UpdateInfoOrder", model);
        }
        public ActionResult UpdateInfo(CustomerModel model)
        {
            var isEmail = new UserDao().CheckEmail(model.EMAIL);
            var message = 0;
            if (isEmail)
            {
                message = -1;
            }
            else
            {
                var info = new InfoOrderModel()
                {
                    Name = model.TENKH,
                    PhoneNumber = model.DIENTHOAI,
                    Address = model.DIACHI,
                    Email = model.EMAIL
                };
                Session.Add(CartSession.OrderSesstion, info);
                message = 1;
            }
           
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveOrder()
        {
            int message = 0;
            var info = (InfoOrderModel)Session[CartSession.OrderSesstion];
            var cart = (List<CartModel>)Session[CartSession.CartSesstion];
            var id = "";
            var idDH = "";
            if (info == null)
            {
                message = 0;
            }
            else
            {
                if (info.id == null)
                {
                    id = new UserDao().CreateIDAuto("KH");
                    KHACHHANG cus = new KHACHHANG()
                    {
                        MAKHACHHANG = id,
                        TENKHACHHANG = info.Name,
                        HOKHACHHANG = "Temp",
                        DIENTHOAI = info.PhoneNumber,
                        DIACHI = info.Address,
                        EMAIL = info.Email,
                        TRANGTHAI = 0
                    };
                    var result = new UserDao().Insert(cus);
                }
                else
                {
                    id = info.id;
                }
                idDH = new SanPhamDao().IdDonHangAuto("DH");
                var order = new DONHANG()
                {
                    MAHOADON = idDH,
                    MAKHACHHANG = id,
                    NGAYLAP = DateTime.Now,
                    NGAYCAPNHAT = DateTime.Now,
                    TRANGTHAI = 0,
                    MAPHUONGTHUCTHANHTOAN = "0",
                    GHICHU = "",
                };
                var a = new SanPhamDao().InsertDonHang(order);

                foreach (var item in cart)
                {
                    var detailorder = new CHITIETDONHANG()
                    {
                        MAHOADON = idDH,
                        MASANPHAM = item.SANPHAM.MASANPHAM,
                        SOLUONG = item.SOLUONG,
                        THANHTIEN = item.SANPHAM.GIABAN
                    };
                    int res = new SanPhamDao().InsertCTDonHang(detailorder);
                }
                //Gửi mail
                string smtpUserName = "duongngochuy.hufi@gmail.com";
                string smtpPassword = "NgocHuy@123";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;

                string emailTo = info.Email;
                string subject = "Đơn hàng vừa mua";
                string body = string.Format("Bạn vừa nhận được liên hê từ: <b>{0}</b><br/>Email: {1}<br/>Cảm ơn bạn đã mua hàng tại website Fahasa.<br/> Mã đơn hàng của bạn là: " + idDH + ".<br/>Dùng mã đơn hàng để tra cứu đơn hàng trực tiếp trên website. <br/>Đơn hàng của bạn đang được xử lý.", "Admin ", "");

                EmailService service = new EmailService();
                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);
                Session[CartSession.CartSesstion] = null;
                message = 1;
            }
            var oModel = new
            {
                message = message,
                ID = idDH
            };
            return Json(oModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProcessOrder()
        {
            return View();
        }
        public ActionResult OrderSuccess(string id)
        {
            ViewBag.ID = id;
            return View();
        }
        public ActionResult GetListDH(string id)
        {
            var donhang = new DonHangDao().GetDonHang(id);
            var listCT_DonHang = new DonHangDao().getListCTDH(id);
            var model = new List<DonHangModel>();
            decimal total = 0;
            foreach (var item in listCT_DonHang)
            {
                var product = new SanPhamDao().getProduct(item.MASANPHAM);
                var img = new SanPhamDao().getListImages(item.MASANPHAM);
                model.Add(new DonHangModel()
                {
                    idDonHang = id,
                    idProduct = item.MASANPHAM,
                    idCustomer = donhang.MAKHACHHANG,
                    soluong= item.SOLUONG,
                    thanhtien = item.THANHTIEN,
                    nameProduct = product.TENSANPHAM,
                    linkImage = img[0].LINKHINHANH,
                });
                total += (item.THANHTIEN * item.SOLUONG);
            }
            int status = 4;
            var ship = 0;
            if (donhang != null)
            {
                status = (int)donhang.TRANGTHAI;
                if (total < 300000)
                {
                    total += 30000;
                    ship = 30000;
                }
            }
           
            var oModel = new
            {
                model = model,
                total =total,
                status = status,
                ship = ship
            };
            return Json(oModel, JsonRequestBehavior.AllowGet);
        }

    }
}