namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("imputation.conge")]
    public partial class conge
    {
        public int id { get; set; }

        public int nbrjrs { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime startdate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime enddate { get; set; }
    }
}
