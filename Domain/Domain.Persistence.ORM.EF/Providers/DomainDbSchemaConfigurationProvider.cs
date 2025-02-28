using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Providers
{
    public class DomainDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new BaseEntityTypeConfigurator<Entities.LegalBusinessKind>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalBusinessKind>(),
                    new Configurators.OrganizationContactEntityTypeConfigurator(),
                    new Configurators.PersonContactEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PropertyKind>(),
                    new Configurators.PropertyEntityTypeConfigurator(),
                    new Configurators.PropertyImageBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.VehicleBrand>(),
                    new BaseEntityTypeConfigurator<Entities.VehicleCategory>(),
                    new BaseEntityTypeConfigurator<Entities.VehicleEngineKind>(),
                    new Configurators.VehicleEntityTypeConfigurator(),
                    new Configurators.VehicleImageBridgeEntotyTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.StructureKind>(),
                    new BaseEntityTypeConfigurator<Entities.OrganizationalUnity>(),
                    new Configurators.StructureOrganizationalUnityBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Structure>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_domain";
    }
}
