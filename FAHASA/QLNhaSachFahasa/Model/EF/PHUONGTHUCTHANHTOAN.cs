namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHUONGTHUCTHANHTOAN")]
    public partial class PHUONGTHUCTHANHTOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHUONGTHUCTHANHTOAN()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        [StringLength(20)]
        public string MAPHUONGTHUCTHANHTOAN { get; set; }

        [Required]
        [StringLength(1024)]
        public string TENPHUONGTHUCTHANHTOAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
