using data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Models
{
    public class ticketModel
    {

      

        

        [StringLength(255)]
        public string description { get; set; }
        public  TeamModel team { get; set; }
        public userModel user { get; set; }

        public String difficulty { get; set; }


        public double estimatedHours { get; set; }

        
        [StringLength(255)]
        public string title { get; set; }

        

        }
}