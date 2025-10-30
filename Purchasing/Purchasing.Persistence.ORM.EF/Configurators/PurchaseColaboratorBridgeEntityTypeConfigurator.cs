using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseColaboratorBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseColaboratorBridge, Entities.Purchase, System.Guid, Colaborator, System.Guid>
    {
        public PurchaseColaboratorBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ColaboratorBridges;
        }
    }
}
