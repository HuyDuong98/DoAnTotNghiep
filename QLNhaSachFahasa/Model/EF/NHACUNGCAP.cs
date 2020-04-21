namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            SACHes = new HashSet<SACH>();
            VANPHONGPHAMs = new HashSet<VANPHONGPHAM>();
        }

        [Key]
        [StringLength(20)]
        public string MANCC { get; set; }

        [Required]
        [StringLength(200)]
        public string TENNCC { get; set; }

        [StringLength(1024)]
        public string DIACHINSX { get; set; }

        [StringLength(500)]
        public string EMAIL { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VANPHONGPHAM> VANPHONGPHAMs { get; set; }
    }
}