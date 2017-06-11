using _2014150654_ENT.Entities;
using _2014150654_ENT.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014150654_PER.Repositories
{
    public class ATMRepository : Repository<ATM>, IATMRepository
    {

        public ATMRepository(_2014150654DbContext context)
            : base(context)
        {

        }

        /*private readonly _2014150654DbContext _Context;

        public ATMRepository(_2014150654DbContext context)
        {
            _Context = context;
        }
        private ATMRepository()
        {

        }
        */
    }
}
