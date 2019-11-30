using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Models
{
    public class evaluationModel
    {
        public virtual user user { get; set; }
        public long idEmploye { get; set; }


        public virtual objective objective { get; set; }
        public long idObjective { get; set; }

        public IEnumerable<SelectListItem> Objectives { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

        public DateTime? date { get; set; }


        public string description { get; set; }

        public float mark { get; set; }


        public string status { get; set; }


    }
}