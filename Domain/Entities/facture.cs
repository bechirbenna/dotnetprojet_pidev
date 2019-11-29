namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.facture")]
    public partial class facture
    {
        [Key]
        public int idfacture { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int somme { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int mission_idmission { get; set; }

        public int? partenariat_idpartenaire { get; set; }

        public virtual mission mission { get; set; }

        public virtual partenariat partenariat { get; set; }
    }
}
