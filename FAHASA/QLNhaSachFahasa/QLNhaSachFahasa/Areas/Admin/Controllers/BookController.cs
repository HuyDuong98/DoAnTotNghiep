﻿using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Areas.Admin.Models;
using QLNhaSachFahasa.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {
        // GET: Admin/Book
        [HasCredential(RoleId = "VIEW_BOOK")]
        public ActionResult Index()
        {
            return View();
        }
        [HasCredential(RoleId = "CREATE_BOOK")]
        public ActionResult Create()
        {
            SetViewBagNgonNgu(null);
            SetViewBagPhanLoai(null);
            SetViewBagHinhThuc(null);
            return View();
        }
        public ActionResult AddImage()
        {
            return View();
        }
        public void SetViewBagNgonNgu(string ma)
        {
            var dao = new GroupNgonNguDao();
            if (string.IsNullOrEmpty(ma))
            {
                ViewBag.MANGONNGU = new SelectList(dao.ListAll(), "MANGONNGU", "TENNGONNGU", null);
            }
            else
            {
                ViewBag.MANGONNGU = new SelectList(dao.ListAll(), "MANGONNGU", "TENNGONNGU", ma);
            }

        }
        private static List<PhanLoaiModel> FillRecursive(List<PHANLOAI> flatObjects, string parentCode)
        {
            return (flatObjects.Where(x => x.MAPHANLOAI.Trim() == parentCode.Trim()).Select(item => new PhanLoaiModel
            {
                id = item.MAPHANLOAI,
                text = item.TENPHANLOAI,
                items = FillRecursiveChil(flatObjects, item.MAPHANLOAI)
            })).ToList();
        }

        private static List<PhanLoaiModel> FillRecursiveChil(List<PHANLOAI> flatObjects, string parentCode)
        {
            return (flatObjects.Where(x => x.MAPHANLOAICHA != null && x.MAPHANLOAICHA.Trim() == parentCode.Trim()).Select(item => new PhanLoaiModel
            {
                id = item.MAPHANLOAI,
                text = item.TENPHANLOAI,
                items = FillRecursiveChil(flatObjects, item.MAPHANLOAI)
            })).ToList();
        }
        // Lấy danh sách phân loại dạng cây===========================================================================
        public ActionResult GetDataPhanLoai()
        {
            var list = new GroupPhanLoaiDao().ListAll();
            var model = FillRecursive(list, "SACH");
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        //============================================================================================================
        public ActionResult GetDataPhanLoaiVPP()
        {
            var list = new GroupPhanLoaiDao().ListAll();
            var model = FillRecursive(list, "VPP");
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public void SetViewBagPhanLoai(string ma)
        {
            var list = new GroupPhanLoaiDao().ListAll();
            //var model = FillRecursive(list, "SACH");
            List<PhanLoaiModel> items = new List<PhanLoaiModel>();
            foreach (var i in list)
            {
                items.Add(new PhanLoaiModel
                {
                    id = i.MAPHANLOAI,
                    parentId = i.MAPHANLOAICHA,
                    text = i.TENPHANLOAI
                });
            }
            if (string.IsNullOrEmpty(ma))
            {
                ViewBag.MAPHANLOAISACH = new SelectList(items, "MAPHANLOAI", "TENPHANLOAI", null);
            }
            else
            {
                ViewBag.MAPHANLOAISACH = new SelectList(items, "MAPHANLOAI", "TENPHANLOAI", ma);
            }
        }

        public void SetViewBagHinhThuc(string ma)
        {
            var dao = new GroupHinhThucDao();


            if (string.IsNullOrEmpty(ma))
            {
                ViewBag.MAHINHTHUC = new SelectList(dao.ListAll(), "MAHINHTHUC", "HINHTHUC", null);
            }
            else
            {
                ViewBag.MAHINHTHUC = new SelectList(dao.ListAll(), "MAHINHTHUC", "HINHTHUC", ma);
            }
        }

        public ActionResult InfoBook(string id)
        {
            var book = new BookDao().ViewDetail(id);
            var model = new BookModel();
            model.MASACH = book.MASANPHAM;
            model.IDLOAI = book.PHANLOAI;
            //model.MANGONNGU = book.MANGONNGU;
            //model.MAPHANLOAISACH = book.MAPHANLOAISACH;
            //model.MAHINHTHUC = book.MAHINHTHUC;
            model.TENSACH = book.TENSANPHAM;
            model.TACGIA = book.TACGIA;
            model.GIASACH = book.DONGIA;
            model.TRONGLUONG = book.TRONGLUONG;
            model.SOTRANG = book.SOTRANG;
            model.KICHTHUOC = book.KICHTHUOC;
            model.TOMTAC = book.GHICHU;
            model.NHAXUATBAN = book.NHAXUATBAN;
            SetViewBagHinhThuc(book.HINHTHUC);
            SetViewBagNgonNgu(book.NGONNGU);
            //SetViewBagPhanLoai(book.MAPHANLOAISACH);
            return PartialView("~/Areas/Admin/Views/Book/_InfoBook.cshtml", model);
        }
        [HttpGet]
        public ActionResult EditBook(string id)
        {
            var book = new BookDao().ViewDetail(id);
            var model = new BookModel();
            model.MASACH = book.MASANPHAM;
            model.IDLOAI = book.PHANLOAI;
            model.MANGONNGU = book.NGONNGU;
            //model.MAPHANLOAISACH = book.MAPHANLOAISACH;
            model.MAHINHTHUC = book.HINHTHUC;
            SetViewBagHinhThuc(model.MAHINHTHUC);
            SetViewBagNgonNgu(model.MANGONNGU);
            //SetViewBagPhanLoai(model.MAPHANLOAISACH);
            model.MAPHANLOAISACH = book.PHANLOAI;
            model.TENSACH = book.TENSANPHAM;
            model.TACGIA = book.TACGIA;
            model.GIASACH = book.DONGIA;
            model.TRONGLUONG = book.TRONGLUONG;
            model.SOTRANG = book.SOTRANG;
            model.KICHTHUOC = book.KICHTHUOC;
            model.TOMTAC = System.Web.HttpUtility.HtmlDecode(book.GHICHU);
            model.NHAXUATBAN = book.NHAXUATBAN;
            return PartialView("~/Areas/Admin/Views/Book/_EditBook.cshtml", model);
        }
        public ActionResult UploadImage(string id)
        {
            ViewBag.ID = id;
            return PartialView("~/Areas/Admin/Views/Book/_UploadImage.cshtml");
        }
        [HttpPost]

        private static List<PhanLoaiModel> FillAll(List<PHANLOAI> flatObjects, string parentCode)
        {
            List<PhanLoaiModel> model = new List<PhanLoaiModel>();
            foreach (var item in flatObjects)
            {
                if (item.MAPHANLOAI.Trim() == parentCode.Trim())
                {
                    model.Add(new PhanLoaiModel()
                    {
                        id = item.MAPHANLOAI,
                        text = item.TENPHANLOAI
                    });
                    model = FillAllChill(flatObjects, model, item.MAPHANLOAI);
                }
            }
            return model.ToList();
        }

        private static List<PhanLoaiModel> FillAllChill(List<PHANLOAI> flatObjects, List<PhanLoaiModel> model, string parentCode)
        {
            foreach (var item in flatObjects)
            {
                if (item.MAPHANLOAICHA != null && item.MAPHANLOAICHA.Trim() == parentCode.Trim())
                {
                    model.Add(new PhanLoaiModel()
                    {
                        id = item.MAPHANLOAI,
                        text = item.TENPHANLOAI
                    });
                    model = FillAllChill(flatObjects, model, item.MAPHANLOAI);
                }
            }
            return model.ToList();
        }
        public ActionResult GetList(string keywork)
        {
            var list = new SanPhamDao().getDataPhanLoai();
            var listPL = FillAll(list, "SACH");
            var res = new BookDao().GetDataBook(keywork);
            var model = new List<BookModel>();
            foreach (var item in listPL)
            {
                var product = res.Where(x => x.PHANLOAI == item.id).ToList();
                
                foreach (var x in product)
                {
                    var giaban = new SanPhamDao().getGiaBan(x.MASANPHAM);
                    var gia = x.DONGIA;
                    if(giaban != null)
                    {
                        gia = giaban.DONGIABAN;
                    }
                    model.Add(new BookModel
                    {
                        MASACH = x.MASANPHAM,
                        TENSACH = x.TENSANPHAM,
                        TACGIA = x.TACGIA,
                        GIABAN = gia,
                        GIASACH = x.DONGIA,
                        TRONGLUONG = x.TRONGLUONG,
                        SOTRANG = x.SOTRANG,
                        KICHTHUOC = x.KICHTHUOC,
                        TOMTAC = x.GHICHU,
                        NHAXUATBAN = x.NHAXUATBAN,
                        IDLOAI = item.text,
                        MANGONNGU = x.NGONNGU,
                    });
                }

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCreateBook(BookModel inputData, HttpPostedFileBase[] fileImages)
        {
            string path = Server.MapPath("~/UploadFile/");
            string path2 = "C:\\xampp\\htdocs\\apiFahasa\\image\\";
            int result;
            var dao = new BookDao();
            var phanloaidao = new GroupPhanLoaiDao();
            if (dao.CheckBookExist(inputData.TENSACH, inputData.NHAXUATBAN))
            {
                result = -1;
            }
            else
            {
                var book = new SANPHAM();
                var session = (UserLogin)Session[QLNhaSachFahasa.Common.CommonConstants.USER_SEESION];

                book.MASANPHAM = dao.CreateIDAuto("SH");
                book.TENSANPHAM = inputData.TENSACH;
                book.PHANLOAI = inputData.MAPHANLOAISACH.Trim();
                book.TRANGTHAI = 1;
                book.NGONNGU = inputData.MANGONNGU;
                book.HINHTHUC = inputData.MAHINHTHUC;
                book.TACGIA = inputData.TACGIA;
                book.DONGIA = inputData.GIASACH;
                book.TRONGLUONG = inputData.TRONGLUONG;
                book.SOTRANG = inputData.SOTRANG;
                book.KICHTHUOC = inputData.KICHTHUOC;
                book.GHICHU = inputData.TOMTAC;
                book.NHAXUATBAN = inputData.NHAXUATBAN;
                book.NGAYTAO = DateTime.Now;
                book.NGAYCAPNHAT = DateTime.Now;
                book.NGUOITAO = session.UserID;
                book.SOLUONG = 0;
                book.LUOTXEM = 0;
                book.SOLUONG = inputData.SoLuong;
                book.NHACUNGCAP = inputData.NHACUNGCAP;
                result = dao.InserBook(book);
                decimal gia = inputData.GIASACH;
                if (!string.IsNullOrEmpty(inputData.GIABAN.ToString()) && inputData.GIABAN != 0)
                {
                    gia = inputData.GIABAN;
                }
                var updateGiaBan = new SanPhamDao().UpdateGiaBan(book.MASANPHAM, gia, book.NGUOITAO);
                // Upload file lên server
                if (fileImages != null)
                {
                    foreach (var file in fileImages)
                    {
                        if (file != null)
                        {
                            var images = new HINHANH();
                            var imageDao = new UploadHinhAnhSanPhamDao();
                            string extensionName = System.IO.Path.GetExtension(file.FileName);
                            var fileInfo = new FileInfo(file.FileName);
                            string finalFileName = DateTime.Now.Ticks.ToString() + extensionName;
                            file.SaveAs(path + finalFileName);
                            file.SaveAs(path2 + finalFileName);
                            //Insert database
                            images.LINKHINHANH = finalFileName;
                            images.MASANPHAM = book.MASANPHAM;
                            images.TENHINHANH = file.FileName;

                            result = imageDao.Insert(images);
                        }
                    }
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateVPP(ProductModel inputData, HttpPostedFileBase[] fileImages)
        {
            string path = Server.MapPath("~/UploadFile/");
            string path2 = "C:\\xampp\\htdocs\\apiFahasa\\image\\";
            var session = (UserLogin)Session[QLNhaSachFahasa.Common.CommonConstants.USER_SEESION];
            int res;
            var product = new SANPHAM()
            {
                MASANPHAM = new SanPhamDao().CreateIDVPPAuto("VPP"),
                TENSANPHAM = inputData.TenSanPham,
                PHANLOAI = inputData.PhanLoai,
                SOLUONG = inputData.SoLuong,
                CHATLIEU = inputData.ChatLieu,
                MAUSAC = inputData.MauSac,
                TRONGLUONG = inputData.TrongLuong,
                KICHTHUOC = inputData.KichThuoc,
                NHASANXUAT = inputData.NhaSanXuat,
                NHACUNGCAP = inputData.NhaCungCap,
                QUOCGIA = inputData.QuocGia,
                DONGIA = inputData.DonGia,
                GHICHU = inputData.GhiChu,
                LUOTXEM = 0,
                NGAYTAO = DateTime.Now,
                NGAYCAPNHAT = DateTime.Now,
                NGUOITAO = session.UserID,
                TRANGTHAI =1
            };
            res = new SanPhamDao().InsertProduct(product);
            decimal gia = inputData.DonGia;
            if (!string.IsNullOrEmpty(inputData.GiaBan.ToString()) && inputData.GiaBan != 0)
            {
                gia = inputData.GiaBan;
            }
            var updateGiaBan = new SanPhamDao().UpdateGiaBan(product.MASANPHAM, gia, product.NGUOITAO);
            if (fileImages != null)
            {
                foreach (var file in fileImages)
                {
                    if (file != null)
                    {
                        var images = new HINHANH();
                        var imageDao = new UploadHinhAnhSanPhamDao();
                        string extensionName = System.IO.Path.GetExtension(file.FileName);
                        var fileInfo = new FileInfo(file.FileName);
                        string finalFileName = DateTime.Now.Ticks.ToString() + extensionName;
                        file.SaveAs(path + finalFileName);
                        file.SaveAs(path2 + finalFileName);
                        //Insert database
                        images.LINKHINHANH = finalFileName;
                        images.MASANPHAM = product.MASANPHAM;
                        images.TENHINHANH = file.FileName;

                        res = imageDao.Insert(images);
                    }
                }
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EditBook(BookModel book)
        {

            var dao = new BookDao();
            var model = new SANPHAM()
            {
                MASANPHAM = book.MASACH,
                TENSANPHAM = book.TENSACH,
                TACGIA = book.TACGIA,
                NHAXUATBAN = book.NHAXUATBAN,
                TRONGLUONG = book.TRONGLUONG,
                SOTRANG = book.SOTRANG,
                KICHTHUOC = book.KICHTHUOC,
                NGONNGU = book.MANGONNGU,
                PHANLOAI = book.MAPHANLOAISACH,
                HINHTHUC = book.MAHINHTHUC,
                GHICHU = book.TOMTAC,
            };
            var result = dao.UpdateBook(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }  
        public ActionResult Delete(string id)
        {
            var result = new BookDao().Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Stationery()
        {
            return View();
        }
        public ActionResult CreateStationery()
        {
            return View();
        }
        public ActionResult GetDataNSX()
        {
            var nsx = new SanPhamDao().DataNSX();
            var model = new List<NhaSanXuatModel>();
            foreach(var item in nsx)
            {
                model.Add(new NhaSanXuatModel
                {
                    MaNSX = item.MANHASANXUAT,
                    TenNSX = item.TENNHASANXUAT,
                    DiaChi = item.DIACHINHASANXUAT,
                    ThongTinThem = item.THONGTINTHEM
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDataNCC()
        {
            var ncc = new SanPhamDao().DataNCC();
            var model = new List<NhaCungCapModel>();
            foreach (var item in ncc)
            {
                model.Add(new NhaCungCapModel
                {
                    MaNCC = item.MANHACUNGCAP,
                    TenNCC = item.TENNHACUNGCAP,
                    DiaChi = item.DIACHINHACUNGCAP,
                    Email = item.EMAIL,
                    SDT = item.SDT,
                    ThongTinThem = item.THONGTINTHEM
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDataQG()
        {
            var qg = new SanPhamDao().DataQG();
            var model = new List<QuocGiaModel>();
            foreach (var item in qg)
            {
                model.Add(new QuocGiaModel
                {
                    MaQG = item.MAQUOCGIA,
                    TenQG = item.TENQUOCGIA
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadFileImage(string id, HttpPostedFileBase[] fileImages)
        {
            var message = 0;
            string path = Server.MapPath("~/UploadFile/");
            string path2 = "C:\\xampp\\htdocs\\apiFahasa\\image\\";
            var delete = new BookDao().DeleteImage(id);
            if (fileImages != null)
            {
                foreach (var file in fileImages)
                {
                    if (file != null)
                    {
                        var images = new HINHANH();
                        var imageDao = new UploadHinhAnhSanPhamDao();
                        string extensionName = System.IO.Path.GetExtension(file.FileName);
                        var fileInfo = new FileInfo(file.FileName);
                        string finalFileName = DateTime.Now.Ticks.ToString() + extensionName;
                        file.SaveAs(path + finalFileName);
                        file.SaveAs(path2 + finalFileName);
                        //Insert database
                        images.LINKHINHANH = finalFileName;
                        images.MASANPHAM = id;
                        images.TENHINHANH = file.FileName;

                        message = imageDao.Insert(images);
                    }
                }
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetListDataVPP(string keyword)
        {
            var list = new SanPhamDao().getDataPhanLoai();
            var listPL = FillAll(list, "VPP");
            var res = new BookDao().GetDataBook(keyword);
            var model = new List<VPPModel>();
            foreach (var item in listPL)
            {
                var product = res.Where(x => x.PHANLOAI == item.id).ToList();
                foreach (var x in product)
                {
                    var ncc = new SanPhamDao().GetItemNCC(x.NHACUNGCAP);
                    var giaban = new SanPhamDao().getGiaBan(x.MASANPHAM);
                    var gia = x.DONGIA;
                    if(giaban!= null)
                    {
                        gia = giaban.DONGIABAN;
                    }
                    string tenNCC = "";
                    string tenNSX = "";
                    if(ncc != null)
                    {
                        tenNCC = ncc.TENNHACUNGCAP;
                    } 
                    var nsx = new SanPhamDao().GetItemNSX(x.NHASANXUAT);
                    if (nsx != null)
                    {
                        tenNSX = nsx.TENNHASANXUAT;
                    }
                    model.Add(new VPPModel
                    {
                        MASP = x.MASANPHAM,
                        TENSP = x.TENSANPHAM,
                        MAUSAC = x.MAUSAC,
                        DONGIA = x.DONGIA,
                        GIABAN = gia,
                        TRONGLUONG = x.TRONGLUONG,
                        CHATLIEU = x.CHATLIEU,
                        KICHTHUOC = x.KICHTHUOC,
                        GHICHU = x.GHICHU,
                        NCC = tenNCC,
                        IDLOAI = x.PHANLOAI,
                        THUONGHIEU  = tenNSX,
                    });
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditVPP(string id)
        {
            var product = new SanPhamDao().getProduct(id);
            var model = new ProductModel()
            {
                MaSanPham = product.MASANPHAM,
                TenSanPham = product.TENSANPHAM,
                PhanLoai = product.PHANLOAI,
                ChatLieu = product.CHATLIEU,
                MauSac = product.MAUSAC,
                TrongLuong = (double)product.TRONGLUONG,
                KichThuoc = product.KICHTHUOC,
                NhaSanXuat = product.NHASANXUAT,
                NhaCungCap = product.NHACUNGCAP,
                QuocGia = product.QUOCGIA,
                DonGia = product.DONGIA,
                GhiChu = System.Web.HttpUtility.HtmlDecode(product.GHICHU),
            };
            return PartialView("_EditVPP",model);
        }

        public ActionResult SaveEditVPP(ProductModel product)
        {
            var model = new SANPHAM()
            {
                MASANPHAM = product.MaSanPham,
                TENSANPHAM = product.TenSanPham,
                CHATLIEU = product.ChatLieu,
                MAUSAC = product.MauSac,
                TRONGLUONG = product.TrongLuong,
                NHASANXUAT = product.NhaSanXuat,
                KICHTHUOC = product.KichThuoc,
                NHACUNGCAP = product.NhaCungCap,
                PHANLOAI = product.PhanLoai,
                QUOCGIA = product.QuocGia,
                GHICHU = product.GhiChu,
            };
            var result = new BookDao().UpdateVPP(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdatedQuantily(string id)
        {
            var product = new SanPhamDao().getProduct(id);
            var model = new BookModel()
            {
                MASACH = id,
                TENSACH = product.TENSANPHAM,
                SoLuong = (int)product.SOLUONG,
            };
            return PartialView("_UpdatedQuantily", model);
        }
        public ActionResult UpdateQuantity(string id, int sl)
        {
            var message = new SanPhamDao().UpdateQuantily(id, sl);
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdatedPrice(string id)
        {
            var product = new SanPhamDao().getProduct(id);
            var giaban = new SanPhamDao().getGiaBan(id);
            decimal gia = product.DONGIA;
            if(giaban != null)
            {
                gia = giaban.DONGIABAN;
            }
            
            var model = new BookModel()
            {
                MASACH = id,
                TENSACH = product.TENSANPHAM,
                GIABAN = gia,
            };
            return PartialView("_UpdatedPrice", model);
        }
        public ActionResult SaveUpdatePrice(string id, decimal gia)
        {
            var session = (UserLogin)Session[QLNhaSachFahasa.Common.CommonConstants.USER_SEESION];
            var message = new SanPhamDao().UpdateGiaBan(id, gia,session.UserID);
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}