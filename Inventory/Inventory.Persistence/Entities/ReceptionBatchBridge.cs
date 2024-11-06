namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
	public class ReceptionBatchBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractReception, System.Guid, Batch, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Contract.AbstractReception Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Batch Stern { get; set; }
    }
}

