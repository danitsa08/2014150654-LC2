﻿using _2014150654_ENT.Entities;
using _2014150654_ENT.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014150654_PER.Repositories
{
    public class PantallaRepository : Repository<Pantalla>, IPantallaRepository
    {

        public PantallaRepository(_2014150654DbContext context)
            : base(context)
        {

        }



        /*private readonly _2014118265DbContext _Context;

        public PantallaRepository(_2014118265DbContext context)
        {
            _Context = context;
        }
        private PantallaRepository()
        {

        }
        */
    }
}
