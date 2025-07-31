namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration
{
	public class ClassificationConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Input.ClassificationInputModel>
    {
        private string name;
        private string description;
        private int priority = 1;

        public ClassificationConfigurationPageModel(ProductConfigurationPageModel productConfigurationPageModel, Interop.API.Common.Models.Input.ClassificationInputModel model) : base(model)
        {
            ProductConfigurationPageModel = productConfigurationPageModel;

            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Priority = model.Priority;
            }
        }

        public ProductConfigurationPageModel ProductConfigurationPageModel { get; private set; }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}

