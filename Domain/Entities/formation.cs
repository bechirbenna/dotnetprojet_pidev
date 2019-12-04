namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.formation")]
    public partial class formation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formation()
        {
            planifications = new HashSet<planification>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string duration { get; set; }

        public int nbPlaceDispo { get; set; }

        [StringLength(255)]
        public string nomFormation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planification> planifications { get; set; }
    }
}
