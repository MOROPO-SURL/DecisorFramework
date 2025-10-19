using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Providers
{
    public class ServicingDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new BaseEntityTypeConfigurator<Entities.TrainingService>(),
                    new BaseEntityTypeConfigurator<Entities.TrainingServiceStep>(),
                    new Configurators.TrainingServiceStepWorkPositionBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.SampleAnalysisService>(),
                    new BaseEntityTypeConfigurator<Entities.SampleAnalysisServiceStep>(),
                    new Configurators.SampleAnalysisServiceStepWorkPositionBridgeEntityTypeConfigurator(),
                    new Configurators.ServiceOrderEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientTrainingServiceOrder>(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientSampleAnalysisServiceOrder>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientTrainingServiceOrder>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientSampleAnalysisServiceOrder>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisoriscamaguey_servicing";
    }
}
