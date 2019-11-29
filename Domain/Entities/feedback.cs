namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.feedback")]
    public partial class feedback
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idEval360 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idGivenByEmployee { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        public DateTime? feedbackDate { get; set; }

        public virtual eval360 eval360 { get; set; }

        public virtual user user { get; set; }
    }
}
