namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        [StringLength(20)]
        public string MAKHACHHANG { get; set; }

        [StringLength(20)]
        public string MANHOMNGUOIDUNG { get; set; }

        [Required]
        [StringLength(1024)]
        public string HOKHACHHANG { get; set; }

        [Required]
        [StringLength(1024)]
        public string TENKHACHHANG { get; set; }

        [Required]
        [StringLength(500)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(10)]
        public string DIENTHOAI { get; set; }

        [StringLength(1024)]
        public string QUOCGIA { get; set; }

        [StringLength(1024)]
        public string THANHPHO { get; set; }

        [StringLength(1024)]
        public string QUAN { get; set; }

        [StringLength(300)]
        public string PHUONG { get; set; }

        [StringLength(1024)]
        public string DIACHI { get; set; }

        [StringLength(30)]
        public string TENDANGNHAPKHACHHANG { get; set; }

        [StringLength(1024)]
        public string MATKHAUKHACHHANG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYTAO { get; set; }
        public int  TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }

        public virtual NHOMNGUOIDUNG NHOMNGUOIDUNG { get; set; }
    }
}
