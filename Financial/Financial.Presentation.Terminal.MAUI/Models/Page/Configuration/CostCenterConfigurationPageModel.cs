namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CostCenterConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.CostCenterDisplayModel>
    {
        private string name;
        private string description;
        private int priority = 1;

        public CostCenterConfigurationPageModel(Interop.API.Common.Models.Display.CostCenterDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}

