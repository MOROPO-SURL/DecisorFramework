using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Providers
{
    public class ServicingDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new BaseEntityTypeConfigurator<Entities.TrainingService>(),
                    new Configurators.TrainingServiceEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.TrainingServiceDocumentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.TrainingServiceStep>(),
                    new Configurators.TrainingServiceStepWorkPositionBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.SampleAnalysisService>(),
                    new Configurators.SampleAnalysisServiceEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.SampleAnalysisServiceDocumentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.SampleAnalysisServiceStep>(),
                    new Configurators.SampleAnalysisServiceStepWorkPositionBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.GroundIntegralStudyService>(),
                    new Configurators.GroundIntegralStudyServiceEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.GroundIntegralStudyServiceDocumentBridgesEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.GroundIntegralStudyServiceStep>(),
                    new Configurators.GroundIntegralStudyServiceStepWorkPositionBridgesEntityTypeConfigurator(),
                    new Configurators.ServiceOrderEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientTrainingServiceOrder>(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientSampleAnalysisServiceOrder>(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientGroundIntegralStudyServiceOrder>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientTrainingServiceOrder>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientSampleAnalysisServiceOrder>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientGroundIntegralStudyServiceOrder>()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisoriscamaguey_servicing";
    }
}
