using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Providers
{
	public class PurchasingDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator[]
                {
                    new BaseEntityTypeConfigurator<Entities.PurchaseZone>(),
                    new Configurators.PurchaseZoneLegalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseZoneNaturalProviderBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Purchase>(),
                    new Configurators.PurchaseColaboratorBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseProductLegalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseProductNaturalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePurchaseSpentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PurchasePlan>(),
                    new Configurators.PurchasePlanInputProductBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePlanLegalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePlanNaturalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePlanOutputProductBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PurchaseCashAdvance>(),
                    new BaseEntityTypeConfigurator<Entities.PurchasePlanDeparture>(),
                    new BaseEntityTypeConfigurator<Entities.PurchaseReception>(),
                    new Configurators.PurchaseReceptionProductWeightBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PurchaseSpent>(),
                    new Configurators.PurchaseZoneSpentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Role>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_purchasing";
    }
}

