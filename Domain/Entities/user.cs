 namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevrh.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            eval360 = new HashSet<eval360>();
            evaluations = new HashSet<evaluation>();
            feedbacks = new HashSet<feedback>();
            missions = new HashSet<mission>();
            teams = new HashSet<team>();
            tickets = new HashSet<ticket>();
        }

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

        [StringLength(255)]
        public string statusEval360 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        public long? team_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eval360> eval360 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evaluation> evaluations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mission> missions { get; set; }

        public virtual team team { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<team> teams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> tickets { get; set; }
    }
}
