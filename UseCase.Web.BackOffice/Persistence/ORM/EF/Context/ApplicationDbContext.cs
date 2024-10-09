using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Core.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Security.Personal.Persistence.Entities;

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Context
{
    public class ApplicationDbContext :
        Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext,
        Guama.Core.Security.Common.Persistence.ORM.EF.Contract.IModulePersistenceDbContext,
        Guama.Location.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Guama.Media.Persistence.ORM.EF.Context.IPersistenceDbContext,
        Guama.Security.Personal.Persistence.ORM.EF.Contract.IPersistenceDbContext,
        Core.Persistence.ORM.EF.Context.Contract.IEssentialDbContext,
        Core.Persistence.ORM.EF.Context.Contract.IBusinessRelationshipDbContext,
        Core.Persistence.ORM.EF.Context.Contract.IPurchasingDbContext,
        Core.Persistence.ORM.EF.Context.Contract.ISalesDbContext
    {
        public ApplicationDbContext(System.Collections.Generic.IEnumerable<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade> dbSchemaConfigurationProviders, DbContextOptions options) : base(dbSchemaConfigurationProviders, options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
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

        // Globals
        public DbSet<Employee> Employees { get; set; }

        // Relationship
        public DbSet<LegalBusinessKind> LegalBusinessKinds { get; set; }
        public DbSet<NaturalBusinessKind> NaturalBusinessKinds { get; set; }

        // Purchasing
        public DbSet<LegalProvider> LegalProviders { get; set; }
        public DbSet<NaturalProvider> NaturalProviders { get; set; }

        // Sales
        public DbSet<LegalClient> LegalClients { get; set; }
        public DbSet<NaturalClient> NaturalClients { get; set; }
    }
}

