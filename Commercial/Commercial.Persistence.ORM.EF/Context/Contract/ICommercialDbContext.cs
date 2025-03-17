using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Context.Contract
{
    public interface ICommercialDbContext : Inventory.Persistence.ORM.EF.Context.Contract.IInventoryDbContext
    {
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<RequestableService> RequestableServices { get; set; }
        public DbSet<ProvisionableService> ProvisionableServices { get; set; }
        public DbSet<ProductValueProposition> ProductValuePropositions { get; set; }
        public DbSet<ProductValuePropositionRate> ProductValuePropositionRates { get; set; }
        public DbSet<ProductValuePropositionImageBridge> ProductValuePropositionImageBridges { get; set; }
        public DbSet<ServiceValueProposition> ServiceValuePropositions { get; set; }
        public DbSet<ServiceValuePropositionRate> ServiceValuePropositionRates { get; set; }
        public DbSet<ServiceValuePropositionImageBridge> ServiceValuePropositionImageBridges { get; set; }
        public DbSet<OrganizationContactBudget> OrganizationContactBudgets { get; set; }
        public DbSet<PersonContactBudget> PersonContactBudgets { get; set; }
        public DbSet<BudgetProductBridge> BudgetProductBridges { get; set; }
        public DbSet<BudgetServiceBridge> BudgetServiceBridges { get; set; }
        public DbSet<LegalProvider> LegalProviders { get; set; }
        public DbSet<LegalProviderBankAccountBridge> LegalProviderBankAccountBridges { get; set; }
        public DbSet<LegalProviderDocumentBridge> LegalProviderDocumentBridges { get; set; }
        public DbSet<LegalProviderPurchasingContract> LegalProviderPurchasingContracts { get; set; }
        public DbSet<NaturalProvider> NaturalProviders { get; set; }
        public DbSet<NaturalProviderBankAccountBridge> NaturalProviderBankAccountBridges { get; set; }
        public DbSet<NaturalProviderPurchasingContract> NaturalProviderPurchasingContracts { get; set; }
        public DbSet<LegalClient> LegalClients { get; set; }
        public DbSet<LegalClientBankAccountBridge> LegalClientBankAccountBridges { get; set; }
        public DbSet<LegalClientDocumentBridge> LegalClientDocumentBridges { get; set; }
        public DbSet<LegalClientSaleContract> LegalClientSaleContracts { get; set; }
        public DbSet<NaturalClient> NaturalClients { get; set; }
        public DbSet<NaturalClientBankAccountBridge> NaturalClientBankAccountBridges { get; set; }
        public DbSet<NaturalClientSaleContract> NaturalClientSaleContracts { get; set; }
    }
}
