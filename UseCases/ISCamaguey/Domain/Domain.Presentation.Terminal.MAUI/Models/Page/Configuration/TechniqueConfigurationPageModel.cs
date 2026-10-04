namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class TechniqueConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.TechniqueDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private int priority = 1;
        private string name;
        private string description;

        public TechniqueConfigurationPageModel(Interop.API.Common.Models.Display.TechniqueDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            priority = model.Priority;
            name = model.Name;
            description = model.Description;

            CubanStandards = [.. model.CubanStandards];
            IsoStandards = [.. model.IsoStandards];
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public System.Collections.ObjectModel.ObservableCollection<Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel> CubanStandards { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel> IsoStandards { get; set; } = [];
    }
}
