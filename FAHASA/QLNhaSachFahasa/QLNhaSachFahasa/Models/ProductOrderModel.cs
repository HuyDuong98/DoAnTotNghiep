using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Models
{
    public class ProductOrderModel
    {
        public decimal Provisional { get; set; }
        public string DeliveryCharges { get; set; }
        public decimal Total { get; set; }
    }
}