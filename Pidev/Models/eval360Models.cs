namespace data
{
    using Pidev.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevrh.eval360")]
    public partial class eval360Models
    {


        public long id { get; set; }



        [StringLength(255)]
        public string evalDetails { get; set; }

        public int sommeMark { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public concernedEmployee concernedEmployee { get; set; }



    }
}
