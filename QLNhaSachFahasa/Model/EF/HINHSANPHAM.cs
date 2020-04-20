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
        public string MASACH { get; set; }

        [StringLength(20)]
        public string MASP { get; set; }

        [StringLength(200)]
        public string TENHINHANH { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual VANPHONGPHAM VANPHONGPHAM { get; set; }
    }
}
