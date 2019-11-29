namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.mission")]
    public partial class mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mission()
        {
            facture = new HashSet<facture>();
        }

        [Key]
        public int idmission { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datedebut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datefin { get; set; }

        [StringLength(255)]
        public string destination { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string objectif { get; set; }

        [StringLength(255)]
        public string territoire { get; set; }

        public long? emp_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<facture> facture { get; set; }

        public virtual user user { get; set; }
    }
}
