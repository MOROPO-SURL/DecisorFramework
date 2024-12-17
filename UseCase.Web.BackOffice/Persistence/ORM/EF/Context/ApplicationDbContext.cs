using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Decisor.Sales.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Security.Personal.Persistence.Entities;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities.Contract;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;
using MOROPO.Framework.Decisor.Sales.Persistence.Entities.Contract;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract;

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Context
{
    public class ApplicationDbContext :
        Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext,
        Guama.Core.Security.Common.Persistence.ORM.EF.Contract.IModulePersistenceDbContext,
        Guama.Location.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Guama.Media.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Guama.Security.Personal.Persistence.ORM.EF.Contract.IPersistenceDbContext,
        Purchasing.Persistence.ORM.EF.Context.Contract.IPurchasingDbContext,
        Sales.Persistence.ORM.EF.Context.ISalesDbContext
    {
        public ApplicationDbContext(System.Collections.Generic.IEnumerable<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade> dbSchemaConfigurationProviders, DbContextOptions options) : base(dbSchemaConfigurationProviders, options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Guama.Core.Security.Common.Persistence.Entities.Role> Roles { get; set; }
        public DbSet<RolePermissionBridge> RolePermissionBridges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleBridge> UserRoleBridges { get; set; }

        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<StateLocation> StateLocations { get; set; }
        public DbSet<MunicipalityLocation> MunicipalityLocations { get; set; }
        public DbSet<LocalityLocation> LocalityLocations { get; set; }

        public DbSet<PersonIdentity> PersonIdentities { get; set; }
        public DbSet<OrganizationPostalContactItemBridge> OrganizationPostalContactItemBridges { get; set; }
        public DbSet<OrganizationPhoneContactItemBridge> OrganizationPhoneContactItemBridges { get; set; }
        public DbSet<OrganizationEmailContactItemBridge> OrganizationEmailContactItemBridges { get; set; }
        public DbSet<PersonWebSiteContactItemBridge> PersonWebSiteContactItemBridges { get; set; }
        public DbSet<PersonSocialContactItemBridge> PersonSocialContactItemBridges { get; set; }
        public DbSet<PersonPostalContactItemBridge> PersonPostalContactItemBridges { get; set; }
        public DbSet<PersonPhoneContactItemBridge> PersonPhoneContactItemBridges { get; set; }
        public DbSet<PersonEmailContactItemBridge> PersonEmailContactItemBridges { get; set; }
        public DbSet<PostalContactItem> PostalContactItems { get; set; }
        public DbSet<WebSiteContactItem> WebSiteContactItems { get; set; }
        public DbSet<SocialContactItem> SocialContactItems { get; set; }
        public DbSet<PhoneContactItem> PhoneContactItems { get; set; }
        public DbSet<EmailContactItem> EmailContactItems { get; set; }
        public DbSet<OrganizationPersonMembershipBridge> OrganizationPersonMembershipBridges { get; set; }
        public DbSet<OrganizationIdentity> OrganizationIdentities { get; set; }
        public DbSet<OrganizationSocialContactItemBridge> OrganizationSocialContactItemBridges { get; set; }
        public DbSet<OrganizationWebSiteContactItemBridge> OrganizationWebSiteContactItemBridges { get; set; }
        public DbSet<Purchasing.Persistence.Entities.Role> PurchasingRoles { get; set; }
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
        public DbSet<PurchasePlan> PurchasePlans { get; set; }
        public DbSet<PurchasePlanLegalProviderBridge> PurchasePlanLegalProviderBridges { get; set; }
        public DbSet<PurchasePlanNaturalProviderBridge> PurchasePlanNaturalProviderBridges { get; set; }
        public DbSet<PurchasePlanOutputProductBridge> PurchasePlanOutputProductBridges { get; set; }
        public DbSet<PurchasePlanInputProductBridge> PurchasePlanInputProductBridges { get; set; }
        public DbSet<PurchaseCashAdvance> PurchaseCashAdvances { get; set; }
        public DbSet<PurchasePlanDeparture> PurchasePlanDepartures { get; set; }
        public DbSet<PurchaseReception> PurchaseReceptions { get; set; }
        public DbSet<PurchaseReceptionProductWeightBridge> PurchaseReceptionProductWeightBridges { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BankAgency> BankAgencies { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankDebitCard> BankDebitCards { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<PropertyKind> PropertyKinds { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImageBridge> PropertyImageBridges { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<VehicleEngineKind> VehicleEngineKinds { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleImageBridge> VehicleImageBridges { get; set; }
        public DbSet<StructureKind> StructureKinds { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmploymentContract> EmploymentContracts { get; set; }
        public DbSet<NamingResolution> NamingResolutions { get; set; }
        public DbSet<Tag> ClauseTags { get; set; }
        public DbSet<Clause> Clauses { get; set; }
        public DbSet<ClauseTagBridge> ClauseTagBridges { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Proforma> Proformas { get; set; }
        public DbSet<ProformaClauseBridge> ProformaSectionClauseBridges { get; set; }
        public DbSet<AbstractSale> Sales { get; set; }
        public DbSet<CustomAttribute> CustomAttributes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCustomAttributeBridge> ProductCustomAttributeBridges { get; set; }
        public DbSet<ProductWarehousingDecreaseKindBridge> ProductWarehousingDecreaseKindBridges { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<AbstractReception> Receptions { get; set; }
        public DbSet<AbstractDeparture> Departures { get; set; }
        public DbSet<DepartureBatchBridge> DepartureBatchBridges { get; set; }
        public DbSet<ReceptionBatchBridge> ReceptionBatchBridges { get; set; }
        public DbSet<UnitMeasurement> UnitMeasurements { get; set; }
        public DbSet<UnitMeasurementConversionBridge> UnitMeasurementConversionBridges { get; set; }
        public DbSet<RequestableService> Services { get; set; }
        public DbSet<LegalBusinessKind> LegalBusinessKinds { get; set; }
        public DbSet<NaturalBusinessKind> NaturalBusinessKinds { get; set; }
        public DbSet<AbstractContact> Contacts { get; set; }
        public DbSet<LegalContact> LegalContacts { get; set; }
        public DbSet<NaturalContact> NaturalContacts { get; set; }
        public DbSet<ContactProductBridge> ContactProductBridges { get; set; }
        public DbSet<ContactServiceBridge> ContactServiceBridges { get; set; }
        public DbSet<LegalContactBudget> LegalContactBudgets { get; set; }
        public DbSet<NaturalContactBudget> NaturalContactBudgets { get; set; }
        public DbSet<BudgetProductBridge> BudgetProductBridges { get; set; }
        public DbSet<BudgetServiceBridge> BudgetServiceBridges { get; set; }
        public DbSet<LegalProvider> LegalProviders { get; set; }
        public DbSet<LegalProviderPurchasingContract> LegalProviderPurchasingContracts { get; set; }
        public DbSet<NaturalProvider> NaturalProviders { get; set; }
        public DbSet<NaturalProviderPurchasingContract> NaturalProviderPurchasingContracts { get; set; }
        public DbSet<LegalClient> LegalClients { get; set; }
        public DbSet<LegalClientSaleContract> LegalClientSaleContracts { get; set; }
        public DbSet<NaturalClient> NaturalClients { get; set; }
        public DbSet<NaturalClientSaleContract> NaturalClientSaleContracts { get; set; }
        public DbSet<LegalClientWholesaleSale> LegalClientWholesaleSales { get; set; }
        public DbSet<NaturalClientWholesaleSale> NaturalClientWholesaleSales { get; set; }
    }
}

