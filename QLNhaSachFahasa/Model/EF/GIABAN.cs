namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIABAN")]
    public partial class GIABAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIABAN()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        [StringLength(20)]
        public string IDGIA { get; set; }

        [Column(TypeName = "money")]
        public decimal GIAGIABAN { get; set; }

        public DateTime NGAYCAPNHATGIA { get; set; }

        public int VAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
    }
}
