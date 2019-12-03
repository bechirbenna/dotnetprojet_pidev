using data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pidev.Models
{
    public class missionModels
    {

        [Key]
        public int idmission { get; set; }

     
        public DateTime? datedebut { get; set; }

        
        public DateTime? datefin { get; set; }

       
        public string destination { get; set; }

     
        public string etat { get; set; }

     
        public string objectif { get; set; }

   
        public string territoire { get; set; }


    
    }
}
