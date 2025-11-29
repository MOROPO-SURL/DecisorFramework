namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge
{
    public class ElaborationStepWorkPositionBridgeModel
    {
        public HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get; set; }

        public decimal? Participation { get; set; }

        public bool Relative { get; set; }

        public string Description { get; set; }
    }
}