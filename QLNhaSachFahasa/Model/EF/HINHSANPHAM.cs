namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HINHSANPHAM")]
    public partial class HINHSANPHAM
    {
        [Key]
        [StringLength(900)]
        public string LINKHINHANH { get; set; }

        [StringLength(20)]
        public string IDSANPHAM { get; set; }

        [StringLength(1024)]
        public string TENHINHANH { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
