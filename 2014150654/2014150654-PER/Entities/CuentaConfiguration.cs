using _2014150654_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014150654_PER.Entities
{
    public class CuentaConfiguration : EntityTypeConfiguration<Cuenta>
    {
        public CuentaConfiguration()
        {
            ToTable("Cuenta");
            HasKey(c => c.Pin);
            Property(c => c.NumeroCuenta);
        }
    }
}
