namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.formateur")]
    public partial class formateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formateur()
        {
            planifications = new HashSet<planification>();
        }

        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool? disponibilite { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int number { get; set; }

        [StringLength(255)]
        public string specialite { get; set; }

        [Column(TypeName = "tinyblob")]
        public byte[] formateurs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planification> planifications { get; set; }
    }
}
