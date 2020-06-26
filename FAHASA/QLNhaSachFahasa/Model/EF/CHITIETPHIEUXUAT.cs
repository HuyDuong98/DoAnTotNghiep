namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUXUAT")]
    public partial class CHITIETPHIEUXUAT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MASANPHAM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MAPHIEUXUAT { get; set; }

        public int SOLUONG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual PHIEUXUAT PHIEUXUAT { get; set; }
    }
}
