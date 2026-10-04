using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Providers
{
    public class LabDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new Configurators.SampleEntityTypeConfigurator(),
                    new Configurators.AnalysisEntityTypeConfigurator(),
                    new Configurators.AnalysisQualityCheckEntityTypeConfigurator(),
                    new Configurators.AnalysisQualityCheckCubanStandardBridgeEntityTypeConfigurator(),
                    new Configurators.AnalysisQualityCheckIsoStandardBridgeEntityTypeConfigurator(),
                    new Configurators.AssessmentEntityTypeConfigurator(),
                    new Configurators.AssessmentQualityCheckEntityTypeConfigurator(),
                    new Configurators.AssessmentQualityCheckCubanStandardBridgeEntityTypeConfigurator(),
                    new Configurators.AssessmentQualityCheckIsoStandardBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ProductionSample>(),
                    new BaseEntityTypeConfigurator<Entities.ResearchSample>(),
                    new BaseEntityTypeConfigurator<Entities.ServiceOrderSample>(),
                    new BaseEntityTypeConfigurator<Entities.WorkingGroup>(),
                    new Configurators.WorkingGroupEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.WorkingGroupTechniqueBridgeEntityTypeConfigurator(),
                    new Configurators.WorkPlanEntityTypeConfigurator(),
                    new Configurators.WorkPlanServiceOrderSampleBridgeEntityTypeConfigurator(),
                    new Configurators.WorkPlanResearchSampleBridgeEntityTypeConfigurator(),
                    new Configurators.WorkPlanProductionSampleBridgeEntityTypeConfigurator()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisoriscamaguey_lab";
    }
}
