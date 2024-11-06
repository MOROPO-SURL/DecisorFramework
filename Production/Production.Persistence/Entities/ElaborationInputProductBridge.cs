namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ElaborationInputProductBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Elaboration, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Elaboration Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Inventory.Persistence.Entities.Product Stern { get; set; }
    }
}