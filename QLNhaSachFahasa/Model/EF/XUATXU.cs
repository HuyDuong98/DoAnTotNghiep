namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XUATXU")]
    public partial class XUATXU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XUATXU()
        {
            VANPHONGPHAMs = new HashSet<VANPHONGPHAM>();
        }

        [Key]
        [StringLength(20)]
        public string MAQUOCGIA { get; set; }

        [Required]
        [StringLength(1024)]
        public string TENQUOCGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VANPHONGPHAM> VANPHONGPHAMs { get; set; }
    }
}
