namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Configurators
{
	public class ReceptionBatchBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ReceptionBatchBridge, Entities.Contract.AbstractReception, System.Guid, Entities.Batch, System.Guid>
    {
        public ReceptionBatchBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.BatchBridges;
        }
    }
}

