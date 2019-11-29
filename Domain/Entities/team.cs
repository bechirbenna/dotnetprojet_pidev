namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.team")]
    public partial class team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public team()
        {
            user = new HashSet<user>();
        }

        public long id { get; set; }

        public DateTime? creationDateTime { get; set; }

        [StringLength(255)]
        public string departement { get; set; }

        [StringLength(255)]
        public string teamName { get; set; }

        public long? manager_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> user { get; set; }

        public virtual user user1 { get; set; }
    }
}
