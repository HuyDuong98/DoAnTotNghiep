namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAP()
        {
            CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
        }

        [Key]
        [StringLength(20)]
        public string MAHOADONNHAP { get; set; }

        [StringLength(20)]
        public string MANHACUNGCAP { get; set; }

        [StringLength(20)]
        public string MANHANVIEN { get; set; }

        public DateTime NGAYNHAP { get; set; }

        public int? TONGSOLUONGNHAP { get; set; }

        [Column(TypeName = "money")]
        public decimal? TONGGIANHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual NHANVIEN NHANVIEN1 { get; set; }

        public virtual NHANVIEN NHANVIEN2 { get; set; }
    }
}
