namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("test.employe")]
    public partial class employe
    {
        public int id { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [Column(TypeName = "bit")]
        public bool? isActif { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public int numtelephone { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        public float salaire { get; set; }
    }
}
