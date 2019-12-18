namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.team")]
    public partial class team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public team()
        {
            users = new HashSet<user>();
        }

        public long id { get; set; }

        public DateTime? creationDateTime { get; set; }

        [StringLength(255)]
        public string departement { get; set; }

        [StringLength(255)]
        public string nameTeam { get; set; }

        public long? manager_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }

        public virtual user user { get; set; }
    }
}
