using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pidev.Models
{
    public class partenariat
    {
        public class Partenariat
        {
            [Key]
            public int idpartenaire { get; set; }
            public String nompartenaire { get; set; }
            public String adressepartenaire { get; set; }
            public String domainepartenaire { get; set; }
            public int numtelpartenaire { get; set; }
            public int pourcentagereduction { get; set; }

            public String emailpartenaire { get; set; }
            public int nbreop { get; set; }
        }
    }
}