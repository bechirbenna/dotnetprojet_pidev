namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.skill")]
    public partial class skill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public skill()
        {
            skillmatrices = new HashSet<skillmatrix>();
            skilljobs = new HashSet<skilljob>();
        }

        public long skillId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? skillDate { get; set; }

        [StringLength(255)]
        public string skillDesc { get; set; }

        [StringLength(255)]
        public string skillName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skillmatrix> skillmatrices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skilljob> skilljobs { get; set; }
    }
}
