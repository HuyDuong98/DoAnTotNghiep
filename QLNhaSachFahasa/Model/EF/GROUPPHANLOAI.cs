namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GROUPPHANLOAI")]
    public partial class GROUPPHANLOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GROUPPHANLOAI()
        {
            PHANLOAIs = new HashSet<PHANLOAI>();
        }

        [Key]
        [StringLength(20)]
        public string IDGROUPPL { get; set; }

        [Required]
        [StringLength(500)]
        public string TENGROUPTHELOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANLOAI> PHANLOAIs { get; set; }
    }
}
