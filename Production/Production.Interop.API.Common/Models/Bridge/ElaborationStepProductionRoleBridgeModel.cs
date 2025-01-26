namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge
{
    public class ElaborationStepProductionRoleBridgeModel
    {
        public Display.ProductionRoleDisplayModel Role { get; set; }

        public decimal Participation { get; set; }

        public bool Linked { get; set; }

        public string Description { get; set; }
    }
}
