namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge
{
    public class ProductionColaboratorBridgeModel
    {
        public Display.ElaborationStepDisplayModel Step { get; set; }

        public Domain.Interop.API.Common.Models.Display.ColaboratorDisplayModel Colaborator { get; set; }

        public HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get; set; }
    }
}
