using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.Production.Persistence.ORM.EF.Providers;

public class ProductionDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
{
    public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
    {
        get
        {
            return
            [
                new BaseEntityTypeConfigurator<Entities.ProductionQualityCheck>()
            ];
        }
    }

    public string DefaultPersistenceSchema => "decisoriscamaguey_production";
}