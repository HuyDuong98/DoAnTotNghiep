namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHUONGTRINH_KHUYENMAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUONGTRINH_KHUYENMAI()
        {
            CT_CHUONGTRINH_KHUYENMAI = new HashSet<CT_CHUONGTRINH_KHUYENMAI>();
        }

        [Key]
        [StringLength(20)]
        public string MACHUONGTRINHKHUYENMAI { get; set; }

        [StringLength(20)]
        public string MATHOIGIAN { get; set; }

        [Required]
        [StringLength(1024)]
        public string TENCHUONGTRINHKHUYENMAI { get; set; }

        public virtual THOIGIAN THOIGIAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_CHUONGTRINH_KHUYENMAI> CT_CHUONGTRINH_KHUYENMAI { get; set; }
    }
}
