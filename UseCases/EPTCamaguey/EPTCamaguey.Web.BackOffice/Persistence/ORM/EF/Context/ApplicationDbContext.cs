using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities.Contract;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities.Contract;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Security.Personal.Persistence.Entities;

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Context
{
    public class ApplicationDbContext :
        Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext,
        Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Contract.IModulePersistenceDbContext,
        Framework.Guama.Location.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Framework.Guama.Media.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Framework.Guama.Security.Personal.Persistence.ORM.EF.Contract.IPersistenceDbContext,
        Framework.Decisor.Commercial.Persistence.ORM.EF.Context.Contract.ICommercialDbContext,
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
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<RequestableService> RequestableServices { get; set; }
        public DbSet<ProvisionableService> ProvisionableServices { get; set; }
        public DbSet<ProductValueProposition> ProductValuePropositions { get; set; }
        public DbSet<ProductValuePropositionRate> ProductValuePropositionRates { get; set; }
        public DbSet<ProductValuePropositionImageBridge> ProductValuePropositionImageBridges { get; set; }
        public DbSet<ServiceValueProposition> ServiceValuePropositions { get; set; }
        public DbSet<ServiceValuePropositionRate> ServiceValuePropositionRates { get; set; }
        public DbSet<ServiceValuePropositionImageBridge> ServiceValuePropositionImageBridges { get; set; }
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
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BankAgency> BankAgencies { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankDebitCard> BankDebitCards { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Tag> ClauseTags { get; set; }
        public DbSet<Clause> Clauses { get; set; }
        public DbSet<ClauseTagBridge> ClauseTagBridges { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Proforma> Proformas { get; set; }
        public DbSet<ProformaClauseBridge> ProformaSectionClauseBridges { get; set; }
        public DbSet<ProclamationKind> ProclamationKinds { get; set; }
        public DbSet<Proclamation> Proclamations { get; set; }
        public DbSet<RegulationKind> RegulationKinds { get; set; }
        public DbSet<Regulation> Regulations { get; set; }
        public DbSet<Disposition> Dispositions { get; set; }
        public DbSet<DispositionTagBridge> DispositionTagBridges { get; set; }
        public DbSet<LegalBusinessKind> LegalBusinessKinds { get; set; }
        public DbSet<NaturalBusinessKind> NaturalBusinessKinds { get; set; }
        public DbSet<CentralStateStructure> CentralStateStructures { get; set; }
        public DbSet<OrganizationContact> OrganizationContacts { get; set; }
        public DbSet<Colaborator> Colaborators { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UnitMeasurement> UnitMeasurements { get; set; }
        public DbSet<UnitMeasurementConversionBridge> UnitMeasurementConversionBridges { get; set; }
        public DbSet<PropertyLeasePropousal> PropertyLeasePropousals { get; set; }
        public DbSet<PropertySpaceLeasePropousal> PropertySpaceLeasePropousals { get; set; }
        public DbSet<VehicleLeasePropousal> VehicleLeasePropousals { get; set; }
        public DbSet<PropertyLeaseOffer> PropertyLeaseOffers { get; set; }
        public DbSet<VehicleLeaseOffer> VehicleLeaseOffers { get; set; }
        public DbSet<VehicleLeaseOrganizationPostulation> VehLeasOrgPostulations { get; set; }
        public DbSet<VehicleLeaseOrganizationPostulationDocumentBridge> VehLeasOrgPostDocumentBridges { get; set; }
        public DbSet<VehicleLeasePersonPostulation> VehLeasPersonPostulations { get; set; }
        public DbSet<VehicleLeasePersonPostulationDocumentBridge> VehLeasPersonPostDocumentBridges { get; set; }
        public DbSet<PropertyLeaseOrganizationPostulation> PropLeasOrgPostulations { get; set; }
        public DbSet<PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge> PropLeaseOrgPostSpacePropousalBridges { get; set; }
        public DbSet<PropertyLeaseOrganizationPostulationDocumentBridge> PropLeasOrgPostDocumentBridges { get; set; }
        public DbSet<PropertyLeasePersonPostulation> PropLeasPersonPostulations { get; set; }
        public DbSet<PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge> PropLeasPersPostSpacePropBridges { get; set; }
        public DbSet<PropertyLeasePersonPostulationDocumentBridge> PropertyLeasePersonPostulationDocumentBridges { get; set; }
        public DbSet<AbstractLeaseContract> LeaseContracts { get; set; }
        public DbSet<LegalClientPropertyLeaseContract> LegalClientPropertyLeaseContracts { get; set; }
        public DbSet<NaturalClientPropertyLeaseContract> NaturalClientPropertyLeaseContracts { get; set; }
        public DbSet<LegalClientPropertyLeaseContractSpaceBridge> LegClientPropLeasContractSpaceBridges { get; set; }
        public DbSet<NaturalClientPropertyLeaseContractSpaceBridge> NatClientPropeLeasContractSpaceBridges { get; set; }
        public DbSet<LegalClientVehicleLeaseContract> LegalClientVehicleLeaseContracts { get; set; }
        public DbSet<NaturalClientVehicleLeaseContract> NaturalClientVehicleLeaseContracts { get; set; }
        public DbSet<LegalClientVehicleLeasing> LegalClientVehicleLeasings { get; set; }
        public DbSet<LegalClientVehicleLeasingPersonContactBridge> LegClientVehLeasPersonContactBridges { get; set; }
        public DbSet<NaturalClientVehicleLeasing> NaturalClientVehicleLeasings { get; set; }
        public DbSet<NaturalClientVehicleLeasingPersonContactBridge> NatClientVehLeasPersonContactBridges { get; set; }
        public DbSet<LegalClientPropertyLeasing> LegalClientPropertyLeasings { get; set; }
        public DbSet<LegalClientPropertyLeasingPersonContactBridge> LegClientPropLeasPersonContactBridges { get; set; }
        public DbSet<NaturalClientPropertyLeasing> NaturalClientPropertyLeasings { get; set; }
        public DbSet<NaturalClientPropertyLeasingPersonContactBridge> NatClientPropLeasPersonContactBridges { get; set; }
        public DbSet<SupervisionGroup> SupervisionGroups { get; set; }
        public DbSet<SupervisionGroupEmployeeBridge> SupervisionGroupEmployeeBridges { get; set; }
        public DbSet<LegalClientPropertySupervisionControlAction> LegClientPropSupervControlActions { get; set; }
        public DbSet<NaturalClientPropertySupervisionControlAction> NatClientPropSupervControlActions { get; set; }
        public DbSet<LegalClientVehicleSupervisionControlAction> LegClientVehSupervControlActions { get; set; }
        public DbSet<NaturalClientVehicleSupervisionControlAction> NatClientVehSupervControlActions { get; set; }
        public DbSet<LegalClientPropertyLeasingCompensation> LegalClientPropertyLeasingCompensations { get; set; }
        public DbSet<LegalClientPropertyLeasingCompensationDocumentBridge> LegClientPropLeasCompDocumentBridges { get; set; }
        public DbSet<NaturalClientPropertyLeasingCompensation> NaturalClientPropertyLeasingCompensations { get; set; }
        public DbSet<NaturalClientPropertyLeasingCompensationDocumentBridge> NatClientPropLeasCompDocumentBridges { get; set; }
        public DbSet<LegalClientVehicleLeasingCompensation> LegalClientVehicleLeasingCompensations { get; set; }
        public DbSet<LegalClientVehicleLeasingCompensationDocumentBridge> LegClientVehLeasCompDocumentBridges { get; set; }
        public DbSet<NaturalClientVehicleLeasingCompensation> NaturalClientVehicleLeasingCompensations { get; set; }
        public DbSet<NaturalClientVehicleLeasingCompensationDocumentBridge> NatClientVehLeasCompDocumentBridges { get; set; }
        public DbSet<LegalClientPropertyLeasingCollect> LegClientPropLeasCollects { get; set; }
        public DbSet<LegalClientVehicleLeasingCollect> LegClientVehLeasCollects { get; set; }
        public DbSet<NaturalClientPropertyLeasingCollect> NatClientPropLeasCollects { get; set; }
        public DbSet<NaturalClientVehicleLeasingCollect> NatClientVehLeasCollects { get; set; }
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

