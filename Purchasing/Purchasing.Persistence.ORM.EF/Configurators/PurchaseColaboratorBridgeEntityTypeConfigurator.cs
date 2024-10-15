namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseColaboratorBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseColaboratorBridge, Entities.Purchase, System.Guid, Essential.Persistence.Entities.Colaborator, System.Guid>
    {
        public PurchaseColaboratorBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ColaboratorBridges;
        }
    }
}
