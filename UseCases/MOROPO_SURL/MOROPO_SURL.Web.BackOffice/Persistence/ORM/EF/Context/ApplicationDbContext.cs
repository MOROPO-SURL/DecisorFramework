using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Security.Personal.Persistence.Entities;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities.Contract;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Decisor.Essential.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities.Contract;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Context
{
    public class ApplicationDbContext :
        Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext,
        Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Contract.IModulePersistenceDbContext,
        Framework.Guama.Location.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Framework.Guama.Media.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Framework.Guama.Security.Personal.Persistence.ORM.EF.Contract.IPersistenceDbContext,
        Framework.Decisor.Production.Persistence.ORM.EF.Context.Contract.IProductionDbContext,
        Framework.Decisor.Purchasing.Persistence.ORM.EF.Context.Contract.IPurchasingDbContext,
        Framework.Decisor.Leasing.Persistence.ORM.EF.Context.Contract.ILeasingDbContext
    {
        public ApplicationDbContext(System.Collections.Generic.IEnumerable<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade> dbSchemaConfigurationProviders, DbContextOptions options) : base(dbSchemaConfigurationProviders, options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermissionBridge> RolePermissionBridges { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<StateLocation> StateLocations { get; set; }
        public DbSet<MunicipalityLocation> MunicipalityLocations { get; set; }
        public DbSet<LocalityLocation> LocalityLocations { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleBridge> UserRoleBridges { get; set; }
        public DbSet<PersonIdentity> PersonIdentities { get; set; }
        public DbSet<OrganizationIdentity> OrganizationIdentities { get; set; }
        public DbSet<OrganizationPersonMembershipBridge> OrganizationPersonMembershipBridges { get; set; }
        public DbSet<EmailContactItem> EmailContactItems { get; set; }
        public DbSet<PhoneContactItem> PhoneContactItems { get; set; }
        public DbSet<SocialContactItem> SocialContactItems { get; set; }
        public DbSet<WebSiteContactItem> WebSiteContactItems { get; set; }
        public DbSet<PostalContactItem> PostalContactItems { get; set; }
        public DbSet<PersonEmailContactItemBridge> PersonEmailContactItemBridges { get; set; }
        public DbSet<PersonPhoneContactItemBridge> PersonPhoneContactItemBridges { get; set; }
        public DbSet<PersonPostalContactItemBridge> PersonPostalContactItemBridges { get; set; }
        public DbSet<PersonSocialContactItemBridge> PersonSocialContactItemBridges { get; set; }
        public DbSet<PersonWebSiteContactItemBridge> PersonWebSiteContactItemBridges { get; set; }
        public DbSet<OrganizationEmailContactItemBridge> OrganizationEmailContactItemBridges { get; set; }
        public DbSet<OrganizationPhoneContactItemBridge> OrganizationPhoneContactItemBridges { get; set; }
        public DbSet<OrganizationPostalContactItemBridge> OrganizationPostalContactItemBridges { get; set; }
        public DbSet<OrganizationSocialContactItemBridge> OrganizationSocialContactItemBridges { get; set; }
        public DbSet<OrganizationWebSiteContactItemBridge> OrganizationWebSiteContactItemBridges { get; set; }
        public DbSet<LegalBusinessKind> LegalBusinessKinds { get; set; }
        public DbSet<NaturalBusinessKind> NaturalBusinessKinds { get; set; }
        public DbSet<AbstractContact> Contacts { get; set; }
        public DbSet<OrganizationContact> OrganizationContacts { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
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
        public DbSet<CustomAttribute> CustomAttributes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<ProductCustomAttributeBridge> ProductCustomAttributeBridges { get; set; }
        public DbSet<ProductWarehousingDecreaseKindBridge> ProductWarehousingDecreaseKindBridges { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehousingArea> WarehousingAreas { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<TransferReception> TransferReceptions { get; set; }
        public DbSet<AbstractDeparture> Departures { get; set; }
        public DbSet<DepartureBatchBridge> DepartureBatchBridges { get; set; }
        public DbSet<ReceptionBatchBridge> ReceptionBatchBridges { get; set; }
        public DbSet<UnitMeasurement> UnitMeasurements { get; set; }
        public DbSet<UnitMeasurementConversionBridge> UnitMeasurementConversionBridges { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BankAgency> BankAgencies { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankDebitCard> BankDebitCards { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<PropertyKind> PropertyKinds { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImageBridge> PropertyImageBridges { get; set; }
        public DbSet<PropertySpace> PropertySpaces { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<VehicleKind> VehicleKinds { get; set; }
        public DbSet<VehicleEngineKind> VehicleEngineKinds { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleImageBridge> VehicleImageBridges { get; set; }
        public DbSet<StructureKind> StructureKinds { get; set; }
        public DbSet<OrganizationalUnity> OrganizationalUnities { get; set; }
        public DbSet<StructureOrganizationalUnityBridge> StructureOrganizationalUnityBridges { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<Schooling> Schoolings { get; set; }
        public DbSet<WorkPositionKind> WorkPositionKinds { get; set; }
        public DbSet<WorkPosition> WorkPositions { get; set; }
        public DbSet<SalaryStandard> SalaryStandards { get; set; }
        public DbSet<Workforce> Workforces { get; set; }
        public DbSet<WorkforceOrganizationalUnityBridge> WorkforceOrganizationalUnityBridges { get; set; }
        public DbSet<Vacant> Vacants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmploymentContract> EmploymentContracts { get; set; }
        public DbSet<NamingResolution> NamingResolutions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffWorkforceBridge> StaffWorkforceBridges { get; set; }
        public DbSet<Ocupation> Ocupations { get; set; }
        public DbSet<Tag> ClauseTags { get; set; }
        public DbSet<Clause> Clauses { get; set; }
        public DbSet<ClauseTagBridge> ClauseTagBridges { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Proforma> Proformas { get; set; }
        public DbSet<ProformaClauseBridge> ProformaSectionClauseBridges { get; set; }
        public DbSet<ProclamationKind> ProclamationKinds { get; set; }
        public DbSet<Proclamation> Proclamations { get; set; }
        public DbSet<CentralStateStructure> CentralStateStructures { get; set; }
        public DbSet<RegulationKind> RegulationKinds { get; set; }
        public DbSet<Regulation> Regulations { get; set; }
        public DbSet<Disposition> Dispositions { get; set; }
        public DbSet<DispositionTagBridge> DispositionTagBridges { get; set; }
        public DbSet<Elaboration> Elaborations { get; set; }
        public DbSet<ElaborationInputProductBridge> ElaborationInputProductBridges { get; set; }
        public DbSet<ElaborationInputProductClassificationBridge> ElaborationInputProductClassificationBridges { get; set; }
        public DbSet<ElaborationOutputProductBridge> ElaborationOutputProductBridges { get; set; }
        public DbSet<ElaborationStep> ElaborationSteps { get; set; }
        public DbSet<ElaborationStepWorkPositionBridge> ElaborationStepWorkPositionBridges { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ProductionColaboratorBridge> ProductionColaboratorBridges { get; set; }
        public DbSet<ProductionEmployeeBridge> ProductionEmployeeBridges { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<ProductionOrderDeparture> ProductionOrderDepartures { get; set; }
        public DbSet<ProductionProductBridge> ProductionProductBridges { get; set; }
        public DbSet<ProductionReception> ProductionReceptions { get; set; }
        public DbSet<PropertyLeasePropousal> PropertyLeasePropousals { get; set; }
        public DbSet<PropertySpaceLeasePropousal> PropertySpaceLeasePropousals { get; set; }
        public DbSet<VehicleLeasePropousal> VehicleLeasePropousals { get; set; }
        public DbSet<PropertyLeaseOffer> PropertyLeaseOffers { get; set; }
        public DbSet<VehicleLeaseOffer> VehicleLeaseOffers { get; set; }
        public DbSet<VehicleLeaseOrganizationPostulation> VehicleLeaseOrganizationPostulations { get; set; }
        public DbSet<VehicleLeaseOrganizationPostulationDocumentBridge> VehicleLeaseOrganizationPostulationDocumentBridges { get; set; }
        public DbSet<VehicleLeasePersonPostulation> VehicleLeasePersonPostulations { get; set; }
        public DbSet<VehicleLeasePersonPostulationDocumentBridge> VehicleLeasePersonPostulationDocumentBridges { get; set; }
        public DbSet<PropertyLeaseOrganizationPostulation> PropertyLeaseOrganizationPostulations { get; set; }
        public DbSet<PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge> PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridges { get; set; }
        public DbSet<PropertyLeaseOrganizationPostulationDocumentBridge> PropertyLeaseOrganizationPostulationDocumentBridges { get; set; }
        public DbSet<PropertyLeasePersonPostulation> PropertyLeasePersonPostulations { get; set; }
        public DbSet<PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge> PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridges { get; set; }
        public DbSet<PropertyLeasePersonPostulationDocumentBridge> PropertyLeasePersonPostulationDocumentBridges { get; set; }
        public DbSet<Colaborator> Colaborators { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.Role> PurchasingRoles { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseSpent> PurchaseSpents { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseZone> PurchaseZones { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseZoneSpentBridge> PurchaseZoneSpentBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseZoneLegalProviderBridge> LegalProviderPurchaseZoneBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseZoneNaturalProviderBridge> NaturalProviderPurchaseZoneBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.Purchase> Purchases { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseEmployeeBridge> PurchaseEmployeeBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseColaboratorBridge> PurchaseColaboratorBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseProductLegalProviderBridge> PurchaseProductLegalProviderBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseProductNaturalProviderBridge> PurchaseProductNaturalProviderBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchasePurchaseSpentBridge> PurchasePurchaseSpentBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchasePlan> PurchasePlans { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchasePlanLegalProviderBridge> PurchasePlanLegalProviderBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchasePlanNaturalProviderBridge> PurchasePlanNaturalProviderBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchasePlanOutputProductBridge> PurchasePlanOutputProductBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchasePlanInputProductBridge> PurchasePlanInputProductBridges { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseCashAdvance> PurchaseCashAdvances { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchasePlanDeparture> PurchasePlanDepartures { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseReception> PurchaseReceptions { get; set; }
        public DbSet<Framework.Decisor.Purchasing.Persistence.Entities.PurchaseReceptionProductWeightBridge> PurchaseReceptionProductWeightBridges { get; set; }
        public DbSet<DecisionMakingGroup> DecisionMakingGroups { get; set; }
        public DbSet<DecisionMakingGroupEmployeeBridge> DecisionMakingGroupEmployeeBridges { get; set; }
        public DbSet<DecisionMakingGroupContactBridge> DecisionMakingGroupContactBridges { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingEmployeeBridge> MeetingEmployeeBridges { get; set; }
        public DbSet<MeetingContactBridge> MeetingContactBridges { get; set; }
        public DbSet<MeetingDocumentBridge> MeetingDocumentBridges { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Statement> Statements { get; set; }
    }
}

