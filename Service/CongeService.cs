using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class congeervice : Service<conge>
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbfactory);
        public congeervice() : base(ut)
        {

        }
    }
}
