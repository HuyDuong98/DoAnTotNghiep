using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Models
{
    public class ForgotPasswordModel
    {
        public string email { get; set; }
        public int code { get; set; }
    }
}