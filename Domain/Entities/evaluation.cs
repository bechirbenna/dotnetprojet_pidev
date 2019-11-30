namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.evaluation")]
    public partial class evaluation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idEmploye { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idObjective { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public float mark { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public virtual user user { get; set; }

        public virtual objective objective { get; set; }
    }
}
