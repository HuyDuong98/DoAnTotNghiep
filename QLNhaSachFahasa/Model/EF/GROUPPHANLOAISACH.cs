namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GROUPPHANLOAISACH")]
    public partial class GROUPPHANLOAISACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GROUPPHANLOAISACH()
        {
            PHANLOAISACHes = new HashSet<PHANLOAISACH>();
        }

        [Key]
        [StringLength(20)]
        public string IDGROUPPL { get; set; }

        [Required]
        [StringLength(500)]
        public string TENGROUPTHELOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANLOAISACH> PHANLOAISACHes { get; set; }
    }
}
