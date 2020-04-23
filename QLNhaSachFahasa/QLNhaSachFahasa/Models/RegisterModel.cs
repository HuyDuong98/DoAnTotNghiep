using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Models
{
    public class RegisterModel
    {
        [Key]
        public string MAKH { get; set; }
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Họ không được để trống")]
        public string HoKH { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string TenKH { get; set; }
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Tên đăng nhập không được để trống")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength = 6,ErrorMessage ="Độ dài mật khẩu ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage ="Xác nhận mật khẩu không đúng.")]
        public string ConfimPassword { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ email")]
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Quốc gia")]
        public string QuocGia { get; set; }
        [Display(Name = "Thành phố")]
        public string ThanhPho { get; set; }
        [Display(Name = "Quận")]
        public string Quan { get; set; }
        [Display(Name = "Phường")]
        public string Phuong { get; set; }

    }
}