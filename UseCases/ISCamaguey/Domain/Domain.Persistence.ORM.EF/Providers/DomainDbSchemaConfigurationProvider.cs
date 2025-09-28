using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.ORM.EF.Providers
{
    public class DomainDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new BaseEntityTypeConfigurator<Entities.Technique>(),
                    new Configurators.TechniqueCubanStandardBridgeEntityTypeConfigurator(),
                    new Configurators.TechniqueIsoStandardBridgeEntityTypeConfigurator()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisoriscamaguey_domain";
    }
}
