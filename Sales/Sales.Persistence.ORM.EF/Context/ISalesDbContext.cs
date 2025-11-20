using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Context
{
    public interface ISalesDbContext : Commercial.Persistence.ORM.EF.Context.Contract.ICommercialDbContext
    {
        public DbSet<Entities.LegalClientBudget> LegalClientBudgets { get; set; }
        public DbSet<Entities.LegalClientBudgetProductBridge> LegalClientBudgetProductBridge { get; set; }
        public DbSet<Entities.LegalClientBudgetServiceBridge> LegalClientBudgetServiceBridge { get; set; }
        public DbSet<Entities.NaturalClientBudget> NaturalClientBudgets { get; set; }
        public DbSet<Entities.NaturalClientBudgetProductBridge> NaturalClientBudgetProductBridges { get; set; }
        public DbSet<Entities.NaturalClientBudgetServiceBridge> NaturalClientBudgetServiceBridges { get; set; }
        public DbSet<Entities.Contract.AbstractSale> Sales { get; set; }
        public DbSet<Entities.LegalClientWholesaleSale> LegalClientWholesaleSales { get; set; }
        public DbSet<Entities.NaturalClientWholesaleSale> NaturalClientWholesaleSales { get; set; }
    }
}

