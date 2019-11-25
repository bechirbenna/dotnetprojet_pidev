namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevrh.objective")]
    public partial class objectiveModels
    {
       
        

        [StringLength(255)]
        public string category { get; set; }

        [StringLength(255)]
        public string dateBegin { get; set; }

        [StringLength(255)]
        public string dateEnd { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string name { get; set; }

       
     
    }
}
