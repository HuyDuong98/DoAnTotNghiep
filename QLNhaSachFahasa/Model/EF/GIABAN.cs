namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIABAN")]
    public partial class GIABAN
    {
        [Key]
        [StringLength(20)]
        public string IDGIA { get; set; }

        [StringLength(20)]
        public string IDSANPHAM { get; set; }

        [Column(TypeName = "money")]
        public decimal DONGIABAN { get; set; }

        public DateTime NGAYCAPNHATGIA { get; set; }

        public int VAT { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
