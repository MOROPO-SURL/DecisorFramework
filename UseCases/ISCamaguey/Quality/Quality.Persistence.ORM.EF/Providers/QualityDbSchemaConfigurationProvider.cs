using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.ORM.EF.Providers
{
    public class QualityDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new Configurators.CubanStandardEntityTypeConfigurator(),
                    new Configurators.IsoStandardEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Certification>(),
                    new Configurators.CertificationCubanStandardBridgeEntityTypeConfigurator(),
                    new Configurators.CertificationIsoStandardBridgeEntityTypeConfigurator()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisoriscamaguey_quality";
    }
}
