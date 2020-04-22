namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUXUAT")]
    public partial class PHIEUXUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUXUAT()
        {
            CT_PHIEUXUAT = new HashSet<CT_PHIEUXUAT>();
        }

        [Key]
        [StringLength(20)]
        public string IDXUAT { get; set; }

        [StringLength(20)]
        public string MANV { get; set; }

        public DateTime NGAYXUATHD { get; set; }

        public int? TONGSLXUAT { get; set; }

        [Column(TypeName = "money")]
        public decimal? TONGGIAHD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUXUAT> CT_PHIEUXUAT { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
