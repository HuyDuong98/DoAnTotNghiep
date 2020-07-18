using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class AdminLoginModel
    {
        //[Key]
        //public string ID { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string UseeName { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Mật không được để trống")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}