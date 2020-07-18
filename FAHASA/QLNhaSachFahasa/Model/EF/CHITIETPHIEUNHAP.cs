namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUNHAP")]
    public partial class CHITIETPHIEUNHAP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MAHOADONNHAP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MASANPHAM { get; set; }

        public int SOLUONGNHAP { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }
    }
}
