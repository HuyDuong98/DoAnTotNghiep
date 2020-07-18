namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAPQUYEN")]
    [Serializable]
    public partial class CAPQUYEN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MANHOMNGUOIDUNG { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MAVAITRO { get; set; }
    }
}
