namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.partenariat")]
    public partial class partenariat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public partenariat()
        {
            facture = new HashSet<facture>();
        }

        [Key]
        public int idpartenaire { get; set; }

        [StringLength(255)]
        public string adressepartenaire { get; set; }

        [StringLength(255)]
        public string domainepartenaire { get; set; }

        [StringLength(255)]
        public string emailpartenaire { get; set; }

        public int nbreop { get; set; }

        [StringLength(255)]
        public string nompartenaire { get; set; }

        public int numtelpartenaire { get; set; }

        public int pourcentagereduction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<facture> facture { get; set; }
    }
}
