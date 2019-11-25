namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.skillmatrix")]
    public partial class skillmatrix
    {
        public long id { get; set; }

        public sbyte skillScore { get; set; }

        public long? employee_id { get; set; }

        public long? skill_skillId { get; set; }

        public virtual skill skill { get; set; }

        public virtual user user { get; set; }
    }
}
