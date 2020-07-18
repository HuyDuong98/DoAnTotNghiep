namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VAITRO")]
    public partial class VAITRO
    {
        [Key]
        [StringLength(20)]
        public string MAVAITRO { get; set; }

        [Required]
        [StringLength(500)]
        public string TENVAITRO { get; set; }
    }
}
