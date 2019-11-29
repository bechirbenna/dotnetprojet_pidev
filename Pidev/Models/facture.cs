using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pidev.Models
{
    public class facture
    {
        [Key]
        public int idfacture { get; set; }

 
        public string image { get; set; }

        public int somme { get; set; }

        public string type { get; set; }
    }
}