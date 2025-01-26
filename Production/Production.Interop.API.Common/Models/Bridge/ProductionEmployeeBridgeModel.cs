namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge
{
    public class ProductionEmployeeBridgeModel
    {
        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Employee { get; set; }

        public Display.ElaborationStepDisplayModel Step { get; set; }

        public Display.ProductionRoleDisplayModel Role { get; set; }
    }
}
