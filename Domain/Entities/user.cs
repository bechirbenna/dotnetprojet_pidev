namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.user")]
    public partial class user
    {

        [Required]
        [StringLength(31)]
        public string user_role { get; set; }

        public long id { get; set; }

        public DateTime? creationDate { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstName { get; set; }

        public DateTime? lastLogin { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string cvDetails { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateOfBirth { get; set; }

        [StringLength(255)]
        public string gitLink { get; set; }

        [StringLength(255)]
        public string phoneNumber { get; set; }

        public float? salary { get; set; }

        public long? job_jobId { get; set; }

        [StringLength(255)]
        public string cin { get; set; }

        public virtual job job { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skillmatrix> skillmatrices { get; set; }
        
    }
}
