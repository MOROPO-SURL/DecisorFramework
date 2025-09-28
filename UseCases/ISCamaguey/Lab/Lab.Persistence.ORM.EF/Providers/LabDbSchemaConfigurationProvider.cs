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
                    new BaseEntityTypeConfigurator<Entities.Analysis>(),
                    new BaseEntityTypeConfigurator<Entities.AnalysisOrder>(),
                    new BaseEntityTypeConfigurator<Entities.Assessment>(),
                    // TODO Uncomment required line!!
                    //new BaseEntityTypeConfigurator<Entities.ProductionSample>(),
                    new BaseEntityTypeConfigurator<Entities.ResearchSample>(),
                    new BaseEntityTypeConfigurator<Entities.SampleKind>(),
                    new BaseEntityTypeConfigurator<Entities.ServiceOrderSample>(),
                    new BaseEntityTypeConfigurator<Entities.WorkingGroup>(),
                    new BaseEntityTypeConfigurator<Entities.WorkPlan>(),
                    new Configurators.WorkingGroupEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.WorkingGroupTechniqueBridgeEntityTypeConfigurator()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisoriscamaguey_lab";
    }
}
