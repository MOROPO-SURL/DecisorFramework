using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Context
{
    public interface ISalesDbContext : Commercial.Persistence.ORM.EF.Context.Contract.ICommercialDbContext
    {
        public DbSet<Entities.Contract.AbstractSale> Sales { get; set; }
        public DbSet<Entities.LegalClientWholesaleSale> LegalClientWholesaleSales { get; set; }
        public DbSet<Entities.NaturalClientWholesaleSale> NaturalClientWholesaleSales { get; set; }
    }
}

