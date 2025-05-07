namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ElaborationInputProductClassificationBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Elaboration, System.Guid, Inventory.Persistence.Entities.Classification, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Elaboration Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Inventory.Persistence.Entities.Classification Stern { get; set; }

        public decimal Amount { get; set; }
    }
}
