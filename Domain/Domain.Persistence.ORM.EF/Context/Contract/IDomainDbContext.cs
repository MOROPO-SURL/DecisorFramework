namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Context.Contract
{
    public interface IDomainDbContext : HumanResources.Persistence.ORM.EF.Context.Contract.IHumanResourcesDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.PropertyKind> PropertyKinds { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Property> Properties { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.PropertyImageBridge> PropertyImageBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.VehicleCategory> VehicleCategories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.VehicleEngineKind> VehicleEngineKinds { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Vehicle> Vehicles { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.VehicleImageBridge> VehicleImageBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.StructureKind> StructureKinds { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.OrganizationalUnity> OrganizationalUnities { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.StructureOrganizationalUnityBridge> StructureOrganizationalUnityBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Structure> Structures { get; set; }
    }
}