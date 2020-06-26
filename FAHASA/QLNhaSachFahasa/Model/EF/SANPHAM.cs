namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
            CHITIETPHIEUXUATs = new HashSet<CHITIETPHIEUXUAT>();
            CT_CHUONGTRINH_KHUYENMAI = new HashSet<CT_CHUONGTRINH_KHUYENMAI>();
            GIABANs = new HashSet<GIABAN>();
            HINHANHs = new HashSet<HINHANH>();
        }

        [Key]
        [StringLength(20)]
        public string MASANPHAM { get; set; }

        [StringLength(20)]
        public string PHANLOAI { get; set; }

        [StringLength(20)]
        public string NGONNGU { get; set; }

        [StringLength(20)]
        public string HINHTHUC { get; set; }

        [Required]
        [StringLength(1024)]
        public string TENSANPHAM { get; set; }

        [StringLength(1024)]
        public string TACGIA { get; set; }

        [Column(TypeName = "money")]
        public decimal DONGIA { get; set; }

        public double? TRONGLUONG { get; set; }

        public int? SOTRANG { get; set; }

        [StringLength(1024)]
        public string KICHTHUOC { get; set; }

        [StringLength(1024)]
        public string NHAXUATBAN { get; set; }

        public string GHICHU { get; set; }

        [StringLength(20)]
        public string QUOCGIA { get; set; }

        [StringLength(1024)]
        public string CHATLIEU { get; set; }

        [StringLength(20)]
        public string MAUSAC { get; set; }

        [StringLength(20)]
        public string NHASANXUAT { get; set; }

        public int? SOLUONG { get; set; }
        public int? LUOTXEM { get; set; }
        [StringLength(20)]
        public string NGUOITAO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYTAO { get; set; }

        [StringLength(20)]
        public string NGUOICAPNHAT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYCAPNHAT { get; set; }

        public int? TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUXUAT> CHITIETPHIEUXUATs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_CHUONGTRINH_KHUYENMAI> CT_CHUONGTRINH_KHUYENMAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIABAN> GIABANs { get; set; }

        public virtual HINHTHUCSACH HINHTHUCSACH { get; set; }

        public virtual NGONNGU NGONNGU1 { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual NHANVIEN NHANVIEN1 { get; set; }

        public virtual NHASANXUAT NHASANXUAT1 { get; set; }

        public virtual PHANLOAI PHANLOAI1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HINHANH> HINHANHs { get; set; }

        public virtual XUATXU XUATXU { get; set; }
    }
}
