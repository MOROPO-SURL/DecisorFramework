namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class TrainingServiceConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.TrainingServiceDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private string name;
        private string description;
        private int priority = 1;

        public TrainingServiceConfigurationPageModel(Interop.API.Common.Models.Display.TrainingServiceDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id; 
            name = model.Name;
            description = model.Description;
            priority = model.Priority;
            Steps = [.. model.Steps];
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.TrainingServiceStepDisplayModel> Steps { get; set; } = [];
    }
}
