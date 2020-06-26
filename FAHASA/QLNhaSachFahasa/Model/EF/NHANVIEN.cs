namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            DONHANGs = new HashSet<DONHANG>();
            DONHANGs1 = new HashSet<DONHANG>();
            GIABANs = new HashSet<GIABAN>();
            PHIEUNHAPs = new HashSet<PHIEUNHAP>();
            PHIEUNHAPs1 = new HashSet<PHIEUNHAP>();
            PHIEUNHAPs2 = new HashSet<PHIEUNHAP>();
            PHIEUXUATs = new HashSet<PHIEUXUAT>();
            SANPHAMs = new HashSet<SANPHAM>();
            SANPHAMs1 = new HashSet<SANPHAM>();
        }

        [Key]
        [StringLength(20)]
        public string MANHANVIEN { get; set; }

        [Required]
        [StringLength(100)]
        public string TENNHANVIEN { get; set; }

        [StringLength(30)]
        public string TENDANGNHAPNHANVIEN { get; set; }

        [StringLength(1024)]
        public string MATKHAUNHANVIEN { get; set; }

        [StringLength(1024)]
        public string DIACHINHANVIEN { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(500)]
        public string EMAIL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYTAO { get; set; }

        public bool TRANGTHAI { get; set; }

        [StringLength(20)]
        public string MANHOMNGUOIDUNG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        [StringLength(12)]
        public string CMND { get; set; }

        [StringLength(900)]
        public string HINHANH { get; set; }

        [StringLength(500)]
        public string LOAIHINHCONGVIEC { get; set; }

        [StringLength(500)]
        public string CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIABAN> GIABANs { get; set; }

        public virtual NHOMNGUOIDUNG NHOMNGUOIDUNG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUATs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs1 { get; set; }
    }
}
