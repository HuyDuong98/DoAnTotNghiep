namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VANPHONGPHAM")]
    public partial class VANPHONGPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VANPHONGPHAM()
        {
            HINHSANPHAMs = new HashSet<HINHSANPHAM>();
        }

        [Key]
        [StringLength(20)]
        public string MASP { get; set; }

        [StringLength(20)]
        public string MANCC { get; set; }

        [StringLength(20)]
        public string MANSX { get; set; }

        [StringLength(20)]
        public string ID { get; set; }

        [Column(TypeName = "money")]
        public decimal DONGIAVPP { get; set; }

        public double? TRONGLUONG { get; set; }

        [StringLength(200)]
        public string KICHTHUOC { get; set; }

        [Required]
        [StringLength(500)]
        public string TENSP { get; set; }

        [StringLength(1024)]
        public string GIOITHIEUSP { get; set; }

        [StringLength(200)]
        public string CHATLIEU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HINHSANPHAM> HINHSANPHAMs { get; set; }

        public virtual MATHANGKINHDOANH MATHANGKINHDOANH { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
