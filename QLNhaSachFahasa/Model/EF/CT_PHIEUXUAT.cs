namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUXUAT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string IDSANPHAM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string IDXUAT { get; set; }

        public int SOLUONG { get; set; }

        public virtual PHIEUXUAT PHIEUXUAT { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
