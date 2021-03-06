namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.ticket")]
    public partial class ticket
    {
        [Key]
        public int idTicket { get; set; }

        [Column(TypeName = "bit")]
        public bool? archive { get; set; }

        public DateTime? dateBegin { get; set; }

        public DateTime? dateEnd { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string difficulty { get; set; }

        [Column(TypeName = "bit")]
        public bool? doing { get; set; }

        [Column(TypeName = "bit")]
        public bool? done { get; set; }

        public double duration { get; set; }

        public double estimatedHours { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [Column(TypeName = "bit")]
        public bool? toDo { get; set; }

        [Column(TypeName = "bit")]
        public bool? toDoList { get; set; }

        public long? employesTicket_id { get; set; }

        public int? projet_id { get; set; }

        public int? team_id { get; set; }

        public virtual projet projet { get; set; }

        public virtual user employesTicket { get; set; }
    }
}
