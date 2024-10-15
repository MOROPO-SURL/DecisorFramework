namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class DepartureBatchBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractDeparture, System.Guid, Batch, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Contract.AbstractDeparture Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Batch Stern { get; set; }
    }
}
