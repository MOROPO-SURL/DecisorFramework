using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Context.Contract
{
    public interface IDomainDbContext : HumanResources.Persistence.ORM.EF.Context.Contract.IHumanResourcesDbContext
    {
        public DbSet<LegalBusinessKind> LegalBusinessKinds { get; set; }
        public DbSet<NaturalBusinessKind> NaturalBusinessKinds { get; set; }
        public DbSet<OrganizationContact> OrganizationContacts { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
        public DbSet<PropertyKind> PropertyKinds { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImageBridge> PropertyImageBridges { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<VehicleEngineKind> VehicleEngineKinds { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleImageBridge> VehicleImageBridges { get; set; }
        public DbSet<StructureKind> StructureKinds { get; set; }
        public DbSet<OrganizationalUnity> OrganizationalUnities { get; set; }
        public DbSet<StructureOrganizationalUnityBridge> StructureOrganizationalUnityBridges { get; set; }
        public DbSet<Structure> Structures { get; set; }
    }
}