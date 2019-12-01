namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.planification")]
    public partial class planification
    {
        public int id { get; set; }

        public DateTime? dateDebut { get; set; }

        public DateTime? deateFin { get; set; }

        public int numberP { get; set; }

        public int? idFormateur { get; set; }

        public int? idFormation { get; set; }

        public DateTime? dateFin { get; set; }

        public virtual formateur formateur { get; set; }

        public virtual formation formation { get; set; }
    }
}
