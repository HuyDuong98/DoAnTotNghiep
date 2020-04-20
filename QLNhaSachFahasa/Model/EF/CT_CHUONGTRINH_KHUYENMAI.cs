namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_CHUONGTRINH_KHUYENMAI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string IDCTKM { get; set; }

        public int? SOLUONG { get; set; }

        public virtual CHUONGTRINH_KHUYENMAI CHUONGTRINH_KHUYENMAI { get; set; }

        public virtual MATHANGKINHDOANH MATHANGKINHDOANH { get; set; }
    }
}
