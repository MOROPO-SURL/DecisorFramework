namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge
{
    public class ProductionEmployeeBridgeModel
    {
        public Display.ElaborationStepDisplayModel Step { get; set; }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Employee { get; set; }

        public HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get; set; }
    }
}
