namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CT_HOADON = new HashSet<CT_HOADON>();
        }

        [Key]
        [StringLength(20)]
        public string IDHOADON { get; set; }

        [StringLength(20)]
        public string MAKH { get; set; }

        [StringLength(20)]
        public string MAKHO { get; set; }

        [StringLength(20)]
        public string MAPT { get; set; }

        public DateTime NGAYLAPHD { get; set; }

        [Column(TypeName = "money")]
        public decimal TONGTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }

        public virtual PHUONGTHUCTHANHTOAN PHUONGTHUCTHANHTOAN { get; set; }

        public virtual KHOHANG KHOHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
