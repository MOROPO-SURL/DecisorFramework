namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class IsoStandardConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.IsoStandardDisplayModel>
    {
        public static string IndexValidableProperty => nameof(Index);
        public static string NameValidableProperty => nameof(Name);

        private int index;
        private int priority = 1;
        private string name;
        private string description;

        public IsoStandardConfigurationPageModel(Interop.API.Common.Models.Display.IsoStandardDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            index = model.Index;
            priority = model.Priority;
            name = model.Name;
            description = model.Description;
        }

        public System.Guid Id { get; set; }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }
    }
}
