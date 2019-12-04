namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.centres")]
    public partial class centres
    {
        [Key]
        public int id { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }

        public int number { get; set; }
    }
}
