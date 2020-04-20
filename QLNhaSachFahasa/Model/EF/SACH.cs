namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            HINHSANPHAMs = new HashSet<HINHSANPHAM>();
        }

        [Key]
        [StringLength(20)]
        public string MASACH { get; set; }

        [StringLength(20)]
        public string MAPL { get; set; }

        [StringLength(20)]
        public string MANGONNGU { get; set; }

        [StringLength(20)]
        public string ID { get; set; }

        [StringLength(20)]
        public string MANSX { get; set; }

        [StringLength(20)]
        public string MANCC { get; set; }

        [StringLength(20)]
        public string IDGIA { get; set; }

        [StringLength(20)]
        public string MAHINHTHUC { get; set; }

        [Required]
        [StringLength(200)]
        public string TENSACH { get; set; }

        [StringLength(100)]
        public string TACGIA { get; set; }

        [Column(TypeName = "money")]
        public decimal GIASACH { get; set; }

        public double? TRONGLUONG { get; set; }

        public int? SOTRANG { get; set; }

        [StringLength(200)]
        public string KICHTHUOC { get; set; }

        [StringLength(500)]
        public string TOMTAC { get; set; }

        public virtual GIABAN GIABAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HINHSANPHAM> HINHSANPHAMs { get; set; }

        public virtual HINHTHUCSACH HINHTHUCSACH { get; set; }

        public virtual MATHANGKINHDOANH MATHANGKINHDOANH { get; set; }

        public virtual NGONNGU NGONNGU { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }

        public virtual PHANLOAI PHANLOAI { get; set; }
    }
}
