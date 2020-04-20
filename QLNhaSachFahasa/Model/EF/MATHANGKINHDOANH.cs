namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATHANGKINHDOANH")]
    public partial class MATHANGKINHDOANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATHANGKINHDOANH()
        {
            CT_CHUONGTRINH_KHUYENMAI = new HashSet<CT_CHUONGTRINH_KHUYENMAI>();
            CT_HOADON = new HashSet<CT_HOADON>();
            CT_PHIEUNHAP = new HashSet<CT_PHIEUNHAP>();
            CT_PHIEUXUAT = new HashSet<CT_PHIEUXUAT>();
            SACHes = new HashSet<SACH>();
            VANPHONGPHAMs = new HashSet<VANPHONGPHAM>();
        }

        [StringLength(20)]
        public string ID { get; set; }

        [Required]
        [StringLength(500)]
        public string TENMATHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_CHUONGTRINH_KHUYENMAI> CT_CHUONGTRINH_KHUYENMAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAP> CT_PHIEUNHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUXUAT> CT_PHIEUXUAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VANPHONGPHAM> VANPHONGPHAMs { get; set; }
    }
}
