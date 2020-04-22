namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(20)]
        public string MAKH { get; set; }

        [StringLength(20)]
        public string IDGROUP { get; set; }

        [Required]
        [StringLength(1024)]
        public string HOKH { get; set; }

        [Required]
        [StringLength(1024)]
        public string TENKH { get; set; }

        [Required]
        [StringLength(500)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(10)]
        public string DIENTHOAI { get; set; }

        [StringLength(1024)]
        public string QUOCGIA { get; set; }

        [StringLength(1024)]
        public string THANHPHO { get; set; }

        [StringLength(1024)]
        public string QUAN { get; set; }

        [StringLength(300)]
        public string PHUONG { get; set; }

        [StringLength(1024)]
        public string DIACHI { get; set; }

        [StringLength(30)]
        public string USERNAME { get; set; }

        [StringLength(1024)]
        public string PASSWORD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYTAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        public virtual USERGROUP USERGROUP { get; set; }
    }
}
