namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MANHINHTRANGCHU")]
    public partial class MANHINHTRANGCHU
    {
        [Key]
        [StringLength(20)]
        public string MAITEM { get; set; }

        [StringLength(1024)]
        public string LINK { get; set; }

        [StringLength(200)]
        public string TITLE { get; set; }

        [StringLength(1024)]
        public string ICON { get; set; }

        [StringLength(1024)]
        public string DESCRIPTION { get; set; }

        public bool? ADMIN { get; set; }

        public bool? MEMBER { get; set; }

        public bool? LEADER { get; set; }
    }
}
