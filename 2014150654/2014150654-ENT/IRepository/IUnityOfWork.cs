﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014150654_ENT.IRepository
{
    public interface IUnityOfWork : IDisposable
    {
        IATMRepository ATM { get; }
        IBasedeDatosRepository BasedeDatos { get; }
        ICuentaRepository Cuenta { get; }
        IPantallaRepository Pantalla { get; }
        IRanuraDepositoRepository RanuraDeposito { get; }
        IRetiroRepository Retiro { get; }
        ITecladoRepository Teclado { get; }
        IDispensadorEfectivoRepository DispensadorEfectivo { get; }

        int SaveChanges();

        void StateModified(object entity);
    }
}
