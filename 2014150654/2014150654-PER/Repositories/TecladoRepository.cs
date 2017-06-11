using _2014150654_ENT.Entities;
using _2014150654_ENT.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014150654_PER.Repositories
{
    public class TecladoRepository : Repository<Teclado>, ITecladoRepository
    {
        public TecladoRepository(_2014150654DbContext context)
            : base(context)
        {

        }


        /* private readonly _2014150654DbContext _Context;

        public TecladoReposi50654tory(_2014118265DbContext context)
        {
            _Context = context;
        }

        private TecladoRepository()
        {

        }
        */
    }
}
