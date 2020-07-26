using log4net;
using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Common;
using QLNhaSachFahasa.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Controllers
{
    public class VNPayController : Controller
    {
        // GET: VNPay
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index()
        {
            log.InfoFormat("Begin VNPAY Return, URL={0}", Request.RawUrl);
            if (Request.QueryString.Count > 0)
            {
                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat
                var vnpayData = Request.QueryString;
                VnPayLibrary vnpay = new VnPayLibrary();
                //if (vnpayData.Count > 0)
                //{
                foreach (string s in vnpayData)
                {
                    //get all querystring data
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(s, vnpayData[s]);
                    }
                }
                // }

                //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
                long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
                //vnp_TransactionNo: Ma GD tai he thong VNPAY
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                //vnp_SecureHash: MD5 cua du lieu tra ve
                String vnp_SecureHash = Request.QueryString["vnp_SecureHash"];
                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00")
                    {
                        //Thanh toan thanh cong
                        var id = "";
                        var idDH = "";
                        var cart = (List<CartModel>)Session[CartSession.CartSesstion];
                        var info = (InfoOrderModel)Session[CartSession.OrderSesstion];
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
                            MAPHUONGTHUCTHANHTOAN = "2",
                            TRANGTHAI = 0,
                            GHICHU = "Thanh toán qua VNPay",
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


                        ViewBag.Message = "Thanh toán thành công";
                        log.InfoFormat("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", orderId, vnpayTranId);

                        return RedirectToAction("OrderSuccess","Cart", new { id = idDH });
                    }
                    else
                    {
                        //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                        ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                        log.InfoFormat("Thanh toan loi, OrderId={0}, VNPAY TranId={1},ResponseCode={2}", orderId, vnpayTranId, vnp_ResponseCode);
                    }
                }
                else
                {
                    log.InfoFormat("Invalid signature, InputData={0}", Request.RawUrl);
                    ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý";
                }
            }

        
            return RedirectToAction("Index", "Home"); 
        }
        public ActionResult SaveOrder()
        {
            int message = 0;
            var info = (InfoOrderModel)Session[CartSession.OrderSesstion];
            if (info == null)
            {
                message = 0;
            }
            else
            {
                message = 1;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

            public ActionResult PaymentByVNPay()
        {
            try
            {
                //Get Config Info
                //string vnp_Returnurl = ConfigurationManager.AppSettings["/VNPay/Index"]; //URL nhan ket qua tra ve 
                //string vnp_Url = ConfigurationManager.AppSettings["http://sandbox.vnpayment.vn/paymentv2/vpcpay.html"]; //URL thanh toan cua VNPAY 
                //string vnp_TmnCode = ConfigurationManager.AppSettings["V44NHFT4"]; //Ma website
                //string vnp_HashSecret = ConfigurationManager.AppSettings["YXYUPGHVVOYZGQQBUBUJCLSEUMIUPMKI"]; //Chuoi bi mat

                string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
                string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
                string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma website
                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat
                if (string.IsNullOrEmpty(vnp_TmnCode) || string.IsNullOrEmpty(vnp_HashSecret))
                {
                    //lblMessage.Text = "Vui lòng cấu hình các tham số: vnp_TmnCode,vnp_HashSecret trong file web.config";
                    //return;
                }
                //Get payment input
                var cart = (List<CartModel>)Session[CartSession.CartSesstion];
                Decimal Amount = 0;
                foreach (var item in cart)
                {
                    Amount += item.SOLUONG * item.SANPHAM.GIABAN;
                }
                if (Amount < 300000)
                {
                    Amount += 30000;
                }
                OrderInfo order = new OrderInfo();
                //Save order to db
                order.OrderId = DateTime.Now.Ticks;
                order.Amount = Convert.ToInt64(Amount);
                order.OrderDescription = "abc";
                order.CreatedDate = DateTime.Now;
                //string locale = cboLanguage.SelectedItem.Value;
                //Build URL for VNPAY
                VnPayLibrary vnpay = new VnPayLibrary();

                vnpay.AddRequestData("vnp_Version", "2.0.0");
                vnpay.AddRequestData("vnp_Command", "pay");
                vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
                vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
                //if (cboBankCode.SelectedItem != null && !string.IsNullOrEmpty(cboBankCode.SelectedItem.Value))
                //{
                //    vnpay.AddRequestData("vnp_BankCode", cboBankCode.SelectedItem.Value);
                //}
                vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", "VND");
                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());


                //if (!string.IsNullOrEmpty(locale))
                //{
                //    vnpay.AddRequestData("vnp_Locale", locale);
                //}
                //else
                //{
                //    vnpay.AddRequestData("vnp_Locale", "vn");
                //}
                vnpay.AddRequestData("vnp_Locale", "vn");
                vnpay.AddRequestData("vnp_OrderInfo", order.OrderDescription);
                vnpay.AddRequestData("vnp_OrderType", "other"); //default value: 
                vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
                vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());

                string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
                log.InfoFormat("VNPAY URL: {0}", paymentUrl);
                return Redirect(paymentUrl);
            }
            catch
            {
                return View("Index");
            }
        }
    }
}