namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGONNGU")]
    public partial class NGONNGU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGONNGU()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        [StringLength(20)]
        public string MANGONNGU { get; set; }

        [Column("NGONNGU")]
        [Required]
        [StringLength(20)]
        public string NGONNGU1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
    }
}
