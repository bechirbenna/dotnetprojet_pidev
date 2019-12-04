namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.recommendation")]
    public partial class recommendation
    {
        [Key]
        public long recId { get; set; }

        [Required]
        [StringLength(255)]
        public string recDesc { get; set; }

        [Column(TypeName = "date")]
        public DateTime recDate { get; set; }
    }
}
