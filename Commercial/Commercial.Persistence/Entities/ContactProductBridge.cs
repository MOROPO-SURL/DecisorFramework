namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class ContactProductBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractContact, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Contract.AbstractContact Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        public Inventory.Persistence.Entities.Product Stern { get; set; }
    }
}
