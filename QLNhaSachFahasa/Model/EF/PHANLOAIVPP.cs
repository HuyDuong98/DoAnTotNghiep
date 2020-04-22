namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANLOAIVPP")]
    public partial class PHANLOAIVPP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHANLOAIVPP()
        {
            VANPHONGPHAMs = new HashSet<VANPHONGPHAM>();
        }

        [Key]
        [StringLength(20)]
        public string MAPLVPP { get; set; }

        [StringLength(10)]
        public string TENPLVPP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VANPHONGPHAM> VANPHONGPHAMs { get; set; }
    }
}
