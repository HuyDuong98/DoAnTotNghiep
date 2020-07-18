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
            CHITIETPHIEUXUATs = new HashSet<CHITIETPHIEUXUAT>();
        }

        [Key]
        [StringLength(20)]
        public string MAPHIEUXUAT { get; set; }

        [StringLength(20)]
        public string MANHANVIEN { get; set; }

        public DateTime NGAYXUAT { get; set; }

        public int? SOLUONGXUAT { get; set; }

        [Column(TypeName = "money")]
        public decimal? TONGGIAXUAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUXUAT> CHITIETPHIEUXUATs { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
