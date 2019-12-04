using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pidev.Models
{
    public class FormationModel
    {


        [Key]
        public int id { get; set; }
        public string type { get; set; }
        public string nomFormation { get; set; }
        public string description { get; set; }
        public string duration { get; set; }
        public int nbPlaceDispo { get; set; }
    }
}