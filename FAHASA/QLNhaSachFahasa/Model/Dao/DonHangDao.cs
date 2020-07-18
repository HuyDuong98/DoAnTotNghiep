using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DonHangDao
    {
        QLNhaSachFahasaDBContext db = null;
        public DonHangDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public DONHANG GetDonHang (string id)
        {
            return db.DONHANGs.Where(x => x.MAHOADON == id).FirstOrDefault();
        }
        public List<CHITIETDONHANG> getListCTDH(string id)
        {
            return db.CHITIETDONHANGs.Where(x => x.MAHOADON == id).ToList();
        }
    }
}
