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

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy,hh:mm:ss}")]
        public DateTime? datedebut { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy,hh:mm:ss}")]
        public DateTime? datefin { get; set; }

       
        public string destination { get; set; }

     
        public string etat { get; set; }

     
        public string objectif { get; set; }

   
        public string territoire { get; set; }


        [JsonIgnore]
        public long? emp_id { get; set; }

       
        public virtual user user { get; set; }
    }
}
