namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.skilljob")]
    public partial class skilljob
    {
        public long id { get; set; }

        public sbyte skillJobScore { get; set; }

        public long? job_jobId { get; set; }

        public long? skill_skillId { get; set; }

        public virtual job job { get; set; }

        public virtual skill skill { get; set; }
    }
}
