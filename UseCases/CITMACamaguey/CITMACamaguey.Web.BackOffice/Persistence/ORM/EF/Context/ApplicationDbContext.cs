using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities.Contract;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Security.Personal.Persistence.Entities;

namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Context
{
    public class ApplicationDbContext :
        Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext,
        Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Contract.IModulePersistenceDbContext,
        Framework.Guama.Location.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Framework.Guama.Media.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Framework.Guama.Security.Personal.Persistence.ORM.EF.Contract.IPersistenceDbContext,
        Framework.Decisor.HumanResources.Persistence.ORM.EF.Context.Contract.IHumanResourcesDbContext
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
        public DbSet<Schooling> Schoolings { get; set; }
        public DbSet<SalaryStandard> SalaryStandards { get; set; }
        public DbSet<WorkPositionKind> WorkPositionKinds { get; set; }
        public DbSet<WorkPosition> WorkPositions { get; set; }
        public DbSet<WorkPositionResponsability> WorkPositionResponsabilities { get; set; }
        public DbSet<Workforce> Workforces { get; set; }
        public DbSet<WorkforceOrganizationalUnity> WorkforceOrganizationalUnities { get; set; }
        public DbSet<Vacant> Vacants { get; set; }
        public DbSet<VacantPostulation> VacantPostulations { get; set; }
        public DbSet<VacantPostulationOcupation> VacantPostulationOcupations { get; set; }
        public DbSet<VacantPostulationDocumentBridge> VacantPostulationDocumentBridges { get; set; }
        public DbSet<OcupationCandidate> OcupationCandidates { get; set; }
        public DbSet<AdmitionPropousal> AdmitionPropousals { get; set; }
        public DbSet<AbstractEmploymentContract> EmploymentContracts { get; set; }
        public DbSet<NamingEmploymentContract> NamingEmploymentContracts { get; set; }
        public DbSet<AdmitionEmploymentContract> AdmitionEmploymentContracts { get; set; }
        public DbSet<NamingResolution> NamingResolutions { get; set; }
        public DbSet<RemotionResolution> RemotionResolutions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffWorkforceBridge> StaffWorkforceBridges { get; set; }
        public DbSet<Ocupation> Ocupations { get; set; }
        public DbSet<EmployeeDailyChecking> EmployeeDailyCheckings { get; set; }
        public DbSet<DecisionMakingGroup> DecisionMakingGroups { get; set; }
        public DbSet<DecisionMakingGroupEmployeeBridge> DecisionMakingGroupEmployeeBridges { get; set; }
        public DbSet<DecisionMakingGroupContactBridge> DecisionMakingGroupContactBridges { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingEmployeeBridge> MeetingEmployeeBridges { get; set; }
        public DbSet<MeetingContactBridge> MeetingContactBridges { get; set; }
        public DbSet<MeetingDocumentBridge> MeetingDocumentBridges { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Statement> Statements { get; set; }
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
    }
}

