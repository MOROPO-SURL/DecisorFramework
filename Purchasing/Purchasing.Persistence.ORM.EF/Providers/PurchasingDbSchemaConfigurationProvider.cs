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
                    new Configurators.LegalProviderEntityTypeConfigurator(),
                    new Configurators.LegalProviderPurchaseZoneBridgeEntityTypeConfigurator(),
                    new Configurators.NaturalProviderEntityTypeConfigurator(),
                    new Configurators.NaturalProviderPurchaseZoneBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseColaboratorBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePlanInputProductBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePlanLegalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePlanNaturalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePlanOutputProductBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseProductLegalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseProductNaturalProviderBridgeEntityTypeConfigurator(),
                    new Configurators.PurchasePurchaseSpentBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseReceptionProductWeightBridgeEntityTypeConfigurator(),
                    new Configurators.PurchaseZoneSpentBridgeEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => null;
    }
}

