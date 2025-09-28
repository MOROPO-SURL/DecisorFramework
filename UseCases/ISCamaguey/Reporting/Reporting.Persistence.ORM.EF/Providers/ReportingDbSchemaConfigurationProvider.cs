using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.Reporting.Persistence.ORM.EF.Providers
{
    public class ReportingDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new BaseEntityTypeConfigurator<Entities.SampleAnalysisReport>(),
                    new BaseEntityTypeConfigurator<Entities.SampleAnalysisServiceReport>()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisoriscamaguey_reporting";
    }
}
