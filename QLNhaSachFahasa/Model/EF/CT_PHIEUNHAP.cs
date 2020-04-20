namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUNHAP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string IDHDNHAP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ID { get; set; }

        public int SOLUONGNHAP { get; set; }

        public virtual MATHANGKINHDOANH MATHANGKINHDOANH { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }
    }
}
