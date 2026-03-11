using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Context.Contract;

public interface IDomainDbContext
{
    public DbSet<ChangeNotification> ChangeNotifications { get; set; }
    public DbSet<ChangeNotificationUserBridge> ChangeNotificationUserBridges { get; set; }
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
    public DbSet<AdministrativeEntityKind> AdministrativeEntityKinds { get; set; }
    public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
    public DbSet<OrganizationalStructure> OrganizationalStructures { get; set; }
    public DbSet<OrganizationalStructuringUnit> OrganizationalStructuringUnits { get; set; }
    public DbSet<AdministrativeEntity> AdministrativeEntities { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<UnitMeasurement> UnitMeasurements { get; set; }
    public DbSet<UnitMeasurementConversionBridge> UnitMeasurementConversionBridges { get; set; }
    public DbSet<KnowledgeArea> KnowledgeAreas { get; set; }
    public DbSet<AcademicAchievement> AcademicAchievements { get; set; }
    public DbSet<AcademicAchievementKnowledgeAreaBridge> AcademicAchievementKnowledgeAreaBridges { get; set; }
}