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
            CT_PHIEUNHAP = new HashSet<CT_PHIEUNHAP>();
        }

        [Key]
        [StringLength(20)]
        public string IDHDNHAP { get; set; }

        [StringLength(20)]
        public string MAKHO { get; set; }

        public DateTime NGAYNHAP { get; set; }

        public int? TONGSLNHAP { get; set; }

        [Column(TypeName = "money")]
        public decimal? TONGGIANHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAP> CT_PHIEUNHAP { get; set; }

        public virtual KHOHANG KHOHANG { get; set; }
    }
}
