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
        [Key]
        [StringLength(20)]
        public string MASACH { get; set; }

        [StringLength(20)]
        public string IDLOAI { get; set; }

        [StringLength(20)]
        public string MANGONNGU { get; set; }

        [StringLength(20)]
        public string MAPLSACH { get; set; }

        [StringLength(20)]
        public string MAHINHTHUC { get; set; }

        [Required]
        [StringLength(1024)]
        public string TENSACH { get; set; }

        [StringLength(1024)]
        public string TACGIA { get; set; }

        [Column(TypeName = "money")]
        public decimal GIASACH { get; set; }

        public double? TRONGLUONG { get; set; }

        public int? SOTRANG { get; set; }

        [StringLength(1024)]
        public string KICHTHUOC { get; set; }

        [StringLength(1024)]
        public string TOMTAC { get; set; }

        [StringLength(1024)]
        public string NHAXUATBAN { get; set; }

        public virtual HINHTHUCSACH HINHTHUCSACH { get; set; }

        public virtual MATHANGKINHDOANH MATHANGKINHDOANH { get; set; }

        public virtual NGONNGU NGONNGU { get; set; }

        public virtual PHANLOAISACH PHANLOAISACH { get; set; }
    }
}
