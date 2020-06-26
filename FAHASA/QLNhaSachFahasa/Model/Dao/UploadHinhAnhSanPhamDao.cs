using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UploadHinhAnhSanPhamDao
    {
        QLNhaSachFahasaDBContext db = null;
        public UploadHinhAnhSanPhamDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public int Insert(HINHANH entity)
        {
            try
            {
                db.HINHANHs.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -2;
            }
        }
    }
}
