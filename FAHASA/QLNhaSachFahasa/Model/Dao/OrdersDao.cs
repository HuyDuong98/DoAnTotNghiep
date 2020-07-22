using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrdersDao
    {
        QLNhaSachFahasaDBContext db = null;
        public OrdersDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }

        public List<DONHANG> GetListDonHang(string keyword,int? status)
        {
            if (status == null && string.IsNullOrEmpty(keyword))
            {
                return db.DONHANGs.OrderByDescending(x => x.NGAYCAPNHAT).ToList();
                
            }else if (status == null && string.IsNullOrEmpty(keyword))
            {
                return db.DONHANGs.Where(x => x.MAHOADON == keyword).OrderByDescending(x => x.NGAYCAPNHAT).ToList();
            }else if (status != null && string.IsNullOrEmpty(keyword))
            {
                return db.DONHANGs.Where(x => x.TRANGTHAI == status).OrderByDescending(x => x.NGAYCAPNHAT).ToList();
            }
            else
            {
                return db.DONHANGs.Where(x => x.TRANGTHAI == status && x.MAHOADON == keyword).OrderByDescending(x => x.NGAYCAPNHAT).ToList();
            }
        }
        public List<CHITIETDONHANG> GetOrderDetail(string idDDH)
        {
            return db.CHITIETDONHANGs.Where(x=>x.MAHOADON== idDDH).ToList();
        }
        public List<CHITIETDONHANG> GetOrderDetailByIDProduct(string idProduct)
        {
            return db.CHITIETDONHANGs.Where(x => x.MASANPHAM == idProduct).ToList();
        }
        public int SaveChangeStatus(string id, int status, string idNV)
        {
            try
            {
                var order = db.DONHANGs.Find(id);
                order.NGUOICAPNHAT = idNV;
                order.TRANGTHAI = status;
                order.NGAYCAPNHAT = DateTime.Now;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public List<DONHANG> GetListOrderForMonth(DateTime month)
        {
            return db.DONHANGs.Where(x => x.NGAYCAPNHAT.Month == month.Month && x.NGAYCAPNHAT.Year== month.Year && (x.TRANGTHAI == 1 || x.TRANGTHAI == -1)).ToList();
        }
    }
}
