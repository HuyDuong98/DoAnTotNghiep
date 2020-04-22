namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VANPHONGPHAM")]
    public partial class VANPHONGPHAM
    {
        [Key]
        [StringLength(20)]
        public string MASP { get; set; }

        [StringLength(20)]
        public string IDLOAI { get; set; }

        [StringLength(20)]
        public string MAQUOCGIA { get; set; }

        [StringLength(20)]
        public string MAPLVPP { get; set; }

        [Required]
        [StringLength(1024)]
        public string TENSP { get; set; }

        public double? TRONGLUONG { get; set; }

        [StringLength(1024)]
        public string KICHTHUOC { get; set; }

        [StringLength(1024)]
        public string GIOITHIEUSP { get; set; }

        [StringLength(1024)]
        public string CHATLIEU { get; set; }

        [StringLength(20)]
        public string MAUSAC { get; set; }

        public virtual MATHANGKINHDOANH MATHANGKINHDOANH { get; set; }

        public virtual PHANLOAIVPP PHANLOAIVPP { get; set; }

        public virtual XUATXU XUATXU { get; set; }
    }
}
