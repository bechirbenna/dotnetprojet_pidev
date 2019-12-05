using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pidev.Models
{
    public class JobModel
    {
        public long jobId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? jobDate { get; set; }
        public string jobDesc { get; set; }
        public string jobName { get; set; }
    }
}