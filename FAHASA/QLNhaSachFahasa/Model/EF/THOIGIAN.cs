namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THOIGIAN")]
    public partial class THOIGIAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THOIGIAN()
        {
            CHUONGTRINH_KHUYENMAI = new HashSet<CHUONGTRINH_KHUYENMAI>();
        }

        [Key]
        [StringLength(20)]
        public string MATHOIGIAN { get; set; }

        public DateTime THOIGIANBATDAU { get; set; }

        public DateTime THOIGIANKETTHUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUONGTRINH_KHUYENMAI> CHUONGTRINH_KHUYENMAI { get; set; }
    }
}
