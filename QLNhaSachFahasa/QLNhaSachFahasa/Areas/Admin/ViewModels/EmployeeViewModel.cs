using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            //GetCategory();
        }
        public EmployeeViewModel(string id, string name, string diaChi, string sdt, string email, DateTime? ngayTao, bool trangThai)
        {
            MANV = id;
            TENNV = name;
            DIACHINV = diaChi;
            SDTNV = sdt;
            EMAIL = email;
            NGAYTAO = ngayTao;
            if(trangThai)
            {
                TRANGTHAI = "Làm việc";
            }
            else
            {
                TRANGTHAI = "Thôi việc";
            }
           
        }
        public string MANV { get; set; }
        [Display(Name = "Tên nhân viên")]
        public string TENNV { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DIACHINV { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDTNV { get; set; }
        [Display(Name = "Email")]
        public string EMAIL { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? NGAYTAO { get; set; }
        public String TRANGTHAI { get; set; }
    }
}