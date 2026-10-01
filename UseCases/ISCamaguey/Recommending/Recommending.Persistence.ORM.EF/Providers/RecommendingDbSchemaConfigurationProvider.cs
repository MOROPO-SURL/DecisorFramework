using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Persistence.ORM.EF.Providers;

public sealed class RecommendingDbSchemaConfigurationProvider : IDbSchemaConfigurationProviderFacade
{
    public string DefaultPersistenceSchema => "decisoriscamaguey_recommending";

    public ICollection<IEntityTypeConfigurator> EntityTypeConfigurators
    {
        get
        {
            return
            [
                new BaseEntityTypeConfigurator<Entities.RecomendationReport>(),
                new Configurators.RecomendationReportEmployeeBridgeEntityTypeConfigurator()
            ];
        }
    }
}
