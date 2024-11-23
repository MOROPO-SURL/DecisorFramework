namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge
{
    public class PurchaseEmployeeBridgeModel : Contract.AbstractPurchasePersonBridgeModel
    {
        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Employee { get; set; }
    }
}
