using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Areas.Admin.Models;
using QLNhaSachFahasa.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public void SetViewBagPhanLoai(string ma)
        {
            var dao = new GroupPhanLoaiDao();

            if (string.IsNullOrEmpty(ma))
            {
                ViewBag.MAPHANLOAISACH = new SelectList(dao.ListAll(), "MAPHANLOAI", "TENPHANLOAI", null);
            }
            else
            {
                ViewBag.MAPHANLOAISACH = new SelectList(dao.ListAll(), "MAPHANLOAI", "TENPHANLOAI", ma);
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
            SetViewBagPhanLoai(model.MAPHANLOAISACH);
            model.TENSACH = book.TENSANPHAM;
            model.TACGIA = book.TACGIA;
            model.GIASACH = book.DONGIA;
            model.TRONGLUONG = book.TRONGLUONG;
            model.SOTRANG = book.SOTRANG;
            model.KICHTHUOC = book.KICHTHUOC;
            model.TOMTAC = book.GHICHU;
            model.NHAXUATBAN = book.NHAXUATBAN;
            return PartialView("~/Areas/Admin/Views/Book/_EditBook.cshtml", model);
        }
        [HttpPost]
        public ActionResult GetList(string keywork)
        {
            var res = new BookDao().GetDataBook(keywork);
            return Json(res.Select(x => new
            {
                MASANPHAM = x.MASANPHAM,
                TENSACH = x.TENSANPHAM,
                TACGIA = x.TACGIA,
                GIASACH = x.DONGIA,
                TRONGLUONG = x.TRONGLUONG,
                SOTRANG = x.SOTRANG,
                KICHTHUOC = x.KICHTHUOC,
                TOMTAC = x.GHICHU,
                NHAXUATBAN = x.NHAXUATBAN,
                IDLOAI = x.PHANLOAI,
                MANGONNGU = x.NGONNGU,
                //MAPHANLOAISACH = x.MAPHANLOAISACH,
            }
            ), JsonRequestBehavior.AllowGet);
        }
      
        public ActionResult GetCreateBook(BookModel inputData, HttpPostedFileBase[] fileImages)
        {
            string path = Server.MapPath("~/UploadFile/");
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
                book.PHANLOAI = "SACH";
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
                book.NGUOITAO = session.UserID;
                book.SOLUONG = 0;
                result = dao.InserBook(book);

                // Upload file lên server
                if(fileImages!=null)
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



        [HttpPost]
        public ActionResult EditBook(SANPHAM book)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookDao();
                var result = dao.UpdateBook(book);
                if (result)
                {
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công.");
                }
            }
            return RedirectToAction("Index", "Book");
        }
        public ActionResult Delete(string id)
        {
            var result = new BookDao().Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}