using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pidev.Models
{
    public class userModel
    {

        public int id { get; set; }
        public String lastName { get; set; }
        public String firstName { get; set; }
        public String email { get; set; }
        public String phoneNumber { get; set; }
        public String userName { get; set; }
        public String password { get; set; }

        public String role { get; set; }
    }
}