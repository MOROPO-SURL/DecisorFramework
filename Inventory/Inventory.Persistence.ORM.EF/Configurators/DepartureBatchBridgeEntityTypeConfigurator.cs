namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Configurators
{
    public class DepartureBatchBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.DepartureBatchBridge, Entities.Contract.AbstractDeparture, System.Guid, Entities.Batch, System.Guid>
    {
        public DepartureBatchBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.BatchBridges;
        }
    }
}