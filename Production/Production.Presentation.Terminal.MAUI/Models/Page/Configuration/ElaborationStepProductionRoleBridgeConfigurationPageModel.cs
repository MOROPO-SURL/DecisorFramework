namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ElaborationStepProductionRoleBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.ElaborationStepProductionRoleBridgeModel>
    {
        private decimal participation;
        private bool linked;
        private string description;

        public ElaborationStepProductionRoleBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.ElaborationStepProductionRoleBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Role = model.Role;
                Participation = model.Participation;
                Linked = model.Linked;
                Description = model.Description;
            }
        }

        public Interop.API.Common.Models.Display.ProductionRoleDisplayModel Role { get; set; }

        public decimal Participation { get => participation; set => SetProperty(ref participation, value); }

        public bool Linked { get => linked; set => SetProperty(ref linked, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Interop.API.Common.Models.Display.ProductionRoleDisplayModel[] AvailableRoles { get; set; } = [];
    }
}
