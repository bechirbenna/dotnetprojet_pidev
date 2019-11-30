using data;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace Service
{
    public class ServiceCalendar : Service<calendar>, IServiceCalendar
    {

        private PidevContext ctx;
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork unitOfWork = new UnitOfWork(dbf);

        public ServiceCalendar() : base(unitOfWork)
        {
        }
    }
}
