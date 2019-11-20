using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class pidevContext : DbContext
    {
        public pidevContext() : base("Name=Alias")
        {

        }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
