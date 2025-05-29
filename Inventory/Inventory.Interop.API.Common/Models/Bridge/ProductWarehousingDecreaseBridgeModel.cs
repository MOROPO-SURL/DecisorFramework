namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Bridge
{
    public class ProductWarehousingDecreaseBridgeModel
    {
        public Persistence.Enumerations.WarehousingDecreaseKind Kind { get; set; }

        public decimal MinDecrease { get; set; }

        public decimal MaxDecrease { get; set; }
    }
}
