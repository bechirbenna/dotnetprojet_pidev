using Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data;
namespace Service
{
    public class TicketOCRService : Service<TicketOcr>, ITicketOCRService
    {
      
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork unitOfWork = new UnitOfWork(dbf);
        public TicketOCRService() : base(unitOfWork)
        {

        }
    }
}
