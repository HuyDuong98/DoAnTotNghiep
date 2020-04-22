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
            SACHes = new HashSet<SACH>();
            SANPHAMs = new HashSet<SANPHAM>();
            VANPHONGPHAMs = new HashSet<VANPHONGPHAM>();
        }

        [Key]
        [StringLength(20)]
        public string IDLOAI { get; set; }

        [Required]
        [StringLength(500)]
        public string LOAIMATHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VANPHONGPHAM> VANPHONGPHAMs { get; set; }
    }
}
