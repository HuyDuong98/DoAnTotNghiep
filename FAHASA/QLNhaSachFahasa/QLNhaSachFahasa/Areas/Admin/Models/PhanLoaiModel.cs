using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaSachFahasa.Areas.Admin.Models
{
    public class PhanLoaiModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string parentId { get; set; }
        public List<PhanLoaiModel> items = new List<PhanLoaiModel>();
        //public PhanLoaiModel(string ID, string ParentId, string Name)
        //{
        //    id = ID;
        //    parentId = ParentId;
        //    text = Name;
        //}
    }
    public class MenuPhanLoai : PhanLoaiModel
    {
        public string title { get; set; }
    }
}