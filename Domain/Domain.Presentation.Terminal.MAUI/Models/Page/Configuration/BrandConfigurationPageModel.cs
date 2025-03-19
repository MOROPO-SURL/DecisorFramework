namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class BrandConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.BrandDisplayModel>
    {
        private string name;
        private string description;
        private int priority;

        public BrandConfigurationPageModel(Interop.API.Common.Models.Display.BrandDisplayModel model) : base(model)
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
