using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Context.Contract
{
    public interface IPurchasingDbContext : Financial.Persistence.ORM.EF.Context.Contract.IFinancialDbContext
    {
        public DbSet<Role> PurchasingRoles { get; set; }
        public DbSet<LegalProvider> LegalProviders { get; set; }
        public DbSet<NaturalProvider> NaturalProviders { get; set; }
        public DbSet<PurchaseSpent> PurchaseSpents { get; set; }
        public DbSet<PurchaseZone> PurchaseZones { get; set; }
        public DbSet<PurchaseZoneSpentBridge> PurchaseZoneSpentBridges { get; set; }
        public DbSet<LegalProviderPurchaseZoneBridge> LegalProviderPurchaseZoneBridges { get; set; }
        public DbSet<NaturalProviderPurchaseZoneBridge> NaturalProviderPurchaseZoneBridges { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseEmployeeBridge> PurchaseEmployeeBridges { get; set; }
        public DbSet<PurchaseColaboratorBridge> PurchaseColaboratorBridges { get; set; }
        public DbSet<PurchaseProductLegalProviderBridge> PurchaseProductLegalProviderBridges { get; set; }
        public DbSet<PurchaseProductNaturalProviderBridge> PurchaseProductNaturalProviderBridges { get; set; }
        public DbSet<PurchasePurchaseSpentBridge> PurchasePurchaseSpentBridges { get; set; }
        public DbSet<PurchasePlan> PurchasePlans { get; set; }
        public DbSet<PurchasePlanLegalProviderBridge> PurchasePlanLegalProviderBridges { get; set; }
        public DbSet<PurchasePlanNaturalProviderBridge> PurchasePlanNaturalProviderBridges { get; set; }
        public DbSet<PurchasePlanOutputProductBridge> PurchasePlanOutputProductBridges { get; set; }
        public DbSet<PurchasePlanInputProductBridge> PurchasePlanInputProductBridges { get; set; }
        public DbSet<PurchaseCashAdvance> PurchaseCashAdvances { get; set; }
        public DbSet<PurchasePlanDeparture> PurchasePlanDepartures { get; set; }
        public DbSet<PurchaseReception> PurchaseReceptions { get; set; }
        public DbSet<PurchaseReceptionProductWeightBridge> PurchaseReceptionProductWeightBridges { get; set; }
    }
}

