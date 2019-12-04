namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.formation")]
    public partial class formation
    {

        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string duration { get; set; }

        public int nbPlaceDispo { get; set; }

        [StringLength(255)]
        public string nomFormation { get; set; }

        [StringLength(255)]
        public string type { get; set; }
    }
}
