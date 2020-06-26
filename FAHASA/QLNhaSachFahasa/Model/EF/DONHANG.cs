namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [StringLength(20)]
        public string MAHOADON { get; set; }

        [StringLength(20)]
        public string MAKHACHHANG { get; set; }

        [StringLength(20)]
        public string NGUOICAPNHAT { get; set; }

        [StringLength(20)]
        public string MAPHUONGTHUCTHANHTOAN { get; set; }

        public DateTime NGAYLAP { get; set; }

        public int? TRANGTHAI { get; set; }

        public string GHICHU { get; set; }

        public DateTime? NGAYCAPNHAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual PHUONGTHUCTHANHTOAN PHUONGTHUCTHANHTOAN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual NHANVIEN NHANVIEN1 { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
