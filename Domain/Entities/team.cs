namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevrh.team")]
    public partial class team
    {
       

        public long id { get; set; }

        public DateTime? dateCreation { get; set; }

        [StringLength(255)]
        public string departement { get; set; }

        [StringLength(255)]
        public string nameTeam { get; set; }
        
    }
}
