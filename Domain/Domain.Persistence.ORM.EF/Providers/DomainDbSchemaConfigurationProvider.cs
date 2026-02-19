using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Providers;

public class DomainDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
{
    public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
    {
        get
        {
            return
            [
                new BaseEntityTypeConfigurator<Entities.ChangeNotification>(),
                new Configurators.ChangeNotificationUserBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.LegalBusinessKind>(),
                new BaseEntityTypeConfigurator<Entities.NaturalBusinessKind>(),
                new Configurators.CentralStateStructureEntityTypeConfigurator(),
                new Configurators.ColaboratorEntityTypeConfigurator(),
                new Configurators.OrganizationContactEntityTypeConfigurator(),
                new Configurators.PersonContactEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.PropertyKind>(),
                new Configurators.PropertyEntityTypeConfigurator(),
                new Configurators.PropertyImageBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.PropertySpace>(),
                new BaseEntityTypeConfigurator<Entities.Brand>(),
                new BaseEntityTypeConfigurator<Entities.VehicleKind>(),
                new BaseEntityTypeConfigurator<Entities.VehicleEngineKind>(),
                new Configurators.VehicleEntityTypeConfigurator(),
                new Configurators.VehicleImageBridgeEntotyTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.AdministrativeEntityKind>(),
                new BaseEntityTypeConfigurator<Entities.OrganizationalUnit>(),
                new BaseEntityTypeConfigurator<Entities.OrganizationalStructure>(),
                new BaseEntityTypeConfigurator<Entities.OrganizationalStructuringUnit>(),
                new BaseEntityTypeConfigurator<Entities.AdministrativeEntity>(),
                new Configurators.EmployeeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.UnitMeasurement>(),
                new Configurators.UnitMeasurementConversionBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.KnowledgeArea>()
            ];
        }
    }

    public string DefaultPersistenceSchema => "decisorframework_domain";
}
