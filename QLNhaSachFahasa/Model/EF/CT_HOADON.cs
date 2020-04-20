namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_HOADON
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string IDHOADON { get; set; }

        public int SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal THANHTIEN { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual MATHANGKINHDOANH MATHANGKINHDOANH { get; set; }
    }
}
