namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ElaborationStepWorkPositionBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.ElaborationStepWorkPositionBridgeModel>
    {
        private decimal participation;
        private bool linked;
        private string description;

        public ElaborationStepWorkPositionBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.ElaborationStepWorkPositionBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                WorkPosition = model.WorkPosition;
                Participation = model.Participation;
                Linked = model.Linked;
                Description = model.Description;
            }
        }

        public HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get; set; }

        public decimal Participation { get => participation; set => SetProperty(ref participation, value); }

        public bool Linked { get => linked; set => SetProperty(ref linked, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel[] AvailableWorkPositions { get; set; } = [];
    }
}
