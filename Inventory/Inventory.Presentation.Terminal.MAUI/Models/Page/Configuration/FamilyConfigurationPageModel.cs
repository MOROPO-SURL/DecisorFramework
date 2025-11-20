namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration
{
	public class FamilyConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.FamilyDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private string name;
        private string description;
        private int priority = 1;
        private Interop.API.Common.Models.Display.FamilyDisplayModel parent;

        public FamilyConfigurationPageModel(Interop.API.Common.Models.Display.FamilyDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Priority = model.Priority;
                Parent = model.Parent;
            }
        }

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Interop.API.Common.Models.Display.FamilyDisplayModel Parent { get => parent; set => SetProperty(ref parent, value); }

        public Interop.API.Common.Models.Display.FamilyDisplayModel[] AvailableParents { get; set; }
    }
}

