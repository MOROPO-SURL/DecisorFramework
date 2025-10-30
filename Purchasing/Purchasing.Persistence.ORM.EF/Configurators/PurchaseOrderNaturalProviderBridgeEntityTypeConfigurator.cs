namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseOrderNaturalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseOrderNaturalProviderBridge, Entities.PurchaseOrder, System.Guid, Commercial.Persistence.Entities.NaturalProvider, System.Guid>
    {
        public PurchaseOrderNaturalProviderBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.NaturalProviderBridges;
        }
    }
}
