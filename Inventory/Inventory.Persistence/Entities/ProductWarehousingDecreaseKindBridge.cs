namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class ProductWarehousingDecreaseKindBridge
    {
        public Product Product { get; set; }
        public System.Guid ProductId { get; set; }

        public Enumerations.WarehousingDecreaseKind Kind { get; set; }

        public decimal MinDecrease { get; set; }

        public decimal MaxDecrease { get; set; }
    }
}
