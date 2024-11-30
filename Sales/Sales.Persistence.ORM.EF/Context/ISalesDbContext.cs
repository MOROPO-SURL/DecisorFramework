using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Context
{
    public interface ISalesDbContext : Inventory.Persistence.ORM.EF.Context.Contract.IInventoryDbContext, Servicing.Persistence.ORM.EF.Context.Contract.IServicingDbContext
    {
        public DbSet<Entities.LegalClient> LegalClients { get; set; }
        public DbSet<Entities.NaturalClient> NaturalClients { get; set; }
        public DbSet<Entities.Contract.AbstractBudget> Budgets { get; set; }
        public DbSet<Entities.NaturalClientBudget> NaturalClientBudgets { get; set; }
        public DbSet<Entities.BudgetProductBridge> BudgetProductBridges { get; set; }
        public DbSet<Entities.BudgetServiceBridge> BudgetServiceBridges { get; set; }
        public DbSet<Entities.Contract.AbstractSale> Sales { get; set; }
    }
}

