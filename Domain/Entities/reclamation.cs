namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.reclamation")]
    public partial class reclamation
    {
        [Key]
        public int idreclamation { get; set; }

        [StringLength(255)]
        public string descriptif { get; set; }

        public int idemp { get; set; }

        [StringLength(255)]
        public string type { get; set; }
    }
}
