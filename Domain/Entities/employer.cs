namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.employer")]
    public partial class employer
    {
        [Key]
        public int idEmployer { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
