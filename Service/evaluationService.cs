using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ServicePattern;
using Data.Infrastructure;

namespace Service
{
   public class evaluationService : Service<evaluation> , IServiceEvaluation
    {
        private PidevContext ctx;
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork unitOfWork = new UnitOfWork(dbf);
        public evaluationService() : base(unitOfWork)
        {
           
        }
    }
}
