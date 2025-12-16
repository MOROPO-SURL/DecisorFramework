using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Providers
{
	public class PurchasingDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new BaseEntityTypeConfigurator<Entities.PurchaseZone>(),
                    new Configurators.PurchaseZoneLegalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseZoneNaturalProviderBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Purchase>(),
                    new Configurators.PurchaseColaboratorBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseProductLegalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseProductNaturalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePurchaseSpentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PurchaseRequest>(),
                    new Configurators.PurchaseRequestExpectedProductAdquisitionEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PurchaseOrder>(),
                    new Configurators.PurchaseOrderExpectedProductResultEntityTypeConfigurator(),
                    new Configurators.PurchaseOrderPlannedProductSpentEntityTypeConfigurator(),
                    new Configurators.PurchaseOrderLegalProviderBudgetBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseOrderNaturalProviderBudgetBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PurchaseCashAdvance>(),
                    new BaseEntityTypeConfigurator<Entities.PurchaseOrderDeparture>(),
                    new Configurators.PurchaseReceptionProductWeightBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PurchaseSpent>(),
                    new Configurators.PurchaseZoneSpentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Role>(),
                    new Configurators.LegalProviderBudgetEntityTypeConfigurator(),
                    new Configurators.LegalProviderBudgetProductEntityTypeConfigurator(),
                    new Configurators.LegalProviderBudgetServiceBridgeEntityTypeConfigurator(),
                    new Configurators.NaturalProviderBudgetEntityTypeConfigurator(),
                    new Configurators.NaturalProviderBudgetProductEntityTypeConfigurator(),
                    new Configurators.NaturalProviderBudgetServiceBridgeEntityTypeConfigurator()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_purchasing";
    }
}

