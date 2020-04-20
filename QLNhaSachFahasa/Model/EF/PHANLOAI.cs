namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANLOAI")]
    public partial class PHANLOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHANLOAI()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        [StringLength(20)]
        public string MAPL { get; set; }

        [StringLength(20)]
        public string IDGROUPPL { get; set; }

        [Required]
        [StringLength(500)]
        public string TENPL { get; set; }

        public virtual GROUPPHANLOAI GROUPPHANLOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
    }
}
