namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MASANPHAM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MAHOADON { get; set; }

        public int SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal THANHTIEN { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual DONHANG DONHANG { get; set; }
    }
}
