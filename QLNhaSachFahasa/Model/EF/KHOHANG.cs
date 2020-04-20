namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOHANG")]
    public partial class KHOHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOHANG()
        {
            HOADONs = new HashSet<HOADON>();
            PHIEUNHAPs = new HashSet<PHIEUNHAP>();
            PHIEUXUATs = new HashSet<PHIEUXUAT>();
        }

        [Key]
        [StringLength(20)]
        public string MAKHO { get; set; }

        [Required]
        [StringLength(200)]
        public string TENKHO { get; set; }

        [Required]
        [StringLength(1024)]
        public string DIACHIKHO { get; set; }

        public int? SUCCHUA { get; set; }

        public int? SLHANGTRONGKHO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUATs { get; set; }
    }
}
