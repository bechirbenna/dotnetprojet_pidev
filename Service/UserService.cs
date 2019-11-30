using data;
using Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : Service<user>, IServiceUser
    {

        //private PidevContext ctx;
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork unitOfWork = new UnitOfWork(dbf);

        public UserService() : base(unitOfWork)
        {
        }
    }
}
