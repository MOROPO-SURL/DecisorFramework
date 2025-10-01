namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ResearchAreaConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ResearchAreaDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private int priority = 1;
        private string name;
        private string description;

        public ResearchAreaConfigurationPageModel(Interop.API.Common.Models.Display.ResearchAreaDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            priority = model.Priority;
            name = model.Name;
            description = model.Description;
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }
    }
}
