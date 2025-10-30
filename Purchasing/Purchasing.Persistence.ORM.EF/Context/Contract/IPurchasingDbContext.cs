using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Context.Contract
{
    public interface IPurchasingDbContext : Commercial.Persistence.ORM.EF.Context.Contract.ICommercialDbContext, Governance.Persistence.ORM.EF.Context.Contract.IGovernanceDbContext
    {
        public DbSet<LegalProviderBudget> LegalProviderBudgets { get; set; }
        public DbSet<LegalProviderBudgetProductBridge> LegalProviderBudgetProductBridge { get; set; }
        public DbSet<LegalProviderBudgetServiceBridge> LegalProviderBudgetServiceBridge { get; set; }
        public DbSet<NaturalProviderBudget> NaturalProviderBudgets { get; set; }
        public DbSet<NaturalProviderBudgetProductBridge> NaturalProviderBudgetProductBridges { get; set; }
        public DbSet<NaturalProviderBudgetServiceBridge> NaturalProviderBudgetServiceBridges { get; set; }
        public DbSet<Role> PurchasingRoles { get; set; }
        public DbSet<PurchaseSpent> PurchaseSpents { get; set; }
        public DbSet<PurchaseZone> PurchaseZones { get; set; }
        public DbSet<PurchaseZoneSpentBridge> PurchaseZoneSpentBridges { get; set; }
        public DbSet<PurchaseZoneLegalProviderBridge> LegalProviderPurchaseZoneBridges { get; set; }
        public DbSet<PurchaseZoneNaturalProviderBridge> NaturalProviderPurchaseZoneBridges { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseEmployeeBridge> PurchaseEmployeeBridges { get; set; }
        public DbSet<PurchaseColaboratorBridge> PurchaseColaboratorBridges { get; set; }
        public DbSet<PurchaseProductLegalProviderBridge> PurchaseProductLegalProviderBridges { get; set; }
        public DbSet<PurchaseProductNaturalProviderBridge> PurchaseProductNaturalProviderBridges { get; set; }
        public DbSet<PurchasePurchaseSpentBridge> PurchasePurchaseSpentBridges { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestProductBridge> PurchaseRequestProductBridges { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderProductResultBridge> PurchaseOrderProductResultBridges { get; set; }
        public DbSet<PurchaseOrderProductSpentBridge> PurchaseOrderProductSpentBridges { get; set; }
        public DbSet<PurchaseOrderLegalProviderBridge> PurchasePlanLegalProviderBridges { get; set; }
        public DbSet<PurchaseOrderNaturalProviderBridge> PurchasePlanNaturalProviderBridges { get; set; }
        public DbSet<PurchaseCashAdvance> PurchaseCashAdvances { get; set; }
        public DbSet<PurchaseOrderDeparture> PurchasePlanDepartures { get; set; }
        public DbSet<PurchaseReception> PurchaseReceptions { get; set; }
        public DbSet<PurchaseReceptionProductWeightBridge> PurchaseReceptionProductWeightBridges { get; set; }
    }
}

