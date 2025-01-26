using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Providers
{
    public class ProductionDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new BaseEntityTypeConfigurator<Entities.Elaboration>(),
                    new Configurators.ElaborationInputProductBridgeEntityTypeConfigurator(),
                    new Configurators.ElaborationOutputProductBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ElaborationStep>(),
                    new Configurators.ElaborationStepProductionRoleBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Production>(),
                    new Configurators.ProductionColaboratorBridgeEntityTypeConfigurator(),
                    new Configurators.ProductionEmployeeBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ProductionPlan>(),
                    new BaseEntityTypeConfigurator<Entities.ProductionPlanDeparture>(),
                    new Configurators.ProductionProductBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ProductionReception>(),
                    new BaseEntityTypeConfigurator<Entities.ProductionRole>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_production";
    }
}
