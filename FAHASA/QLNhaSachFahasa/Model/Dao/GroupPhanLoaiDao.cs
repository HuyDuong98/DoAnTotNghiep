using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class GroupPhanLoaiDao
    {
        QLNhaSachFahasaDBContext db = null;
        public GroupPhanLoaiDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<PHANLOAI> ListAll()
        {
            return db.PHANLOAIs.ToList();
        }
        public List<PHANLOAI> ListPhanLoaiTheoSP( string parentID)
        {
            var temp = new List<PHANLOAI>();
            var dao = db.PHANLOAIs.ToList();
            //var list = new GroupPhanLoaiDao().ListAll();
            //var model = FillRecursive(list, "SACH");
            //foreach (var item in dao)
            //{
            //    if(item.MAPHANLOAI == parentID)
            //    {
            //        temp.Add(new PHANLOAI()
            //        {
            //            MAPHANLOAI = item.MAPHANLOAI,
            //            MAPHANLOAICHA = item.MAPHANLOAICHA,
            //            TENPHANLOAI = item.TENPHANLOAI
            //        });
            //    }    
            //}


            //foreach(var item in dao)
            //{
            //    int isParentID = 0;
            //    for(int i=0; i < dao.Count; i++)
            //    {
            //        if(item.MAPHANLOAI == dao[i].MAPHANLOAICHA)
            //        {
            //            isParentID++;
            //        }
            //    }
            //    if (isParentID == 0)
            //    {
            //        temp.Add(item);
            //    }
            //}
            //var list = dao.Where(x=>x.MAPHANLOAICHA == parentID).Select(x=>temp.AddRange(ListPhanLoaiTheoSP(x.MAPHANLOAICHA))).;
            return dao;
        }
        public int InserPhanLoaiSach(PHANLOAI entity)
        {
            try
            {
                db.PHANLOAIs.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
