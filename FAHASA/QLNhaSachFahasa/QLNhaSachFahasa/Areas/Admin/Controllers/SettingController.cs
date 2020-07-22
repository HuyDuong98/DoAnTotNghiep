using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class SettingController : BaseController
    {
        // GET: Admin/Setting
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Classification()
        {
            return View();
        }
        // Select list tree phân loại theo parent code---------------------------------------------------------------------------
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

        // Select Array phân loại theo parent code---------------------------------------------------------------------------
        private static List<PhanLoaiModel> FillAll(List<PHANLOAI> flatObjects, string parentCode)
        {
            List<PhanLoaiModel> model = new List<PhanLoaiModel>();
            foreach (var item in flatObjects)
            {
                if(item.MAPHANLOAI.Trim() == parentCode.Trim())
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

        public ActionResult GetDataTreeView()
        {
            var list = new SanPhamDao().getDataPhanLoai();
            //var model = FillAll(list, "SACH");
            List<PhanLoaiModel> items = new List<PhanLoaiModel>();
            foreach (var i in list)
            {
                items.Add(new PhanLoaiModel
                {
                    id = i.MAPHANLOAI,
                    text = i.TENPHANLOAI,
                    parentId = i.MAPHANLOAICHA
                });
            }

            Action<PhanLoaiModel> SetChildren = null;
            SetChildren = parent =>
            {
                parent.items = items.Where(childItem => childItem.parentId == parent.id).ToList();

                //Recursively call the SetChildren method for each child.
                parent.items.ForEach(SetChildren);
            };
            List<PhanLoaiModel> hierarchicalItems = items.Where(rootItem => rootItem.parentId == null).ToList();
            hierarchicalItems.ForEach(SetChildren);
            return Json(hierarchicalItems, JsonRequestBehavior.AllowGet);
           
        }
        public ActionResult AddPLView(string idParent)
        {

            ViewBag.idParent = idParent;
            return PartialView("_AddNewPL");
        }
        public ActionResult AddPL(string idParent,string text)
        {
            var add = new SanPhamDao().ThemPhanLoai(idParent, text);
            return Json(add, JsonRequestBehavior.AllowGet);
        }
    }
}