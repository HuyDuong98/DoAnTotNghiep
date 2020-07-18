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
        public EmployeeViewModel(string id, string name,string userName,string passWord, string diaChi, string sdt, string email, DateTime? ngayTao, bool trangThai)
        {
            MANV = id;
            TENNV = name;
            DIACHINV = diaChi;
            SDTNV = sdt;
            EMAIL = email;
            NGAYTAO = ngayTao;
            USERNAME = userName;
            PASSWORD = passWord;
            TRANGTHAI = trangThai;
            if (trangThai)
            {
                StringTRANGTHAI = "Làm việc";
            }
            else
            {
                StringTRANGTHAI = "Thôi việc";
            }

        }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
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
        public bool TRANGTHAI { get; set; }
        public String StringTRANGTHAI { get; set; }
    }
}