namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class SampleAnalysisServiceStepConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string DescriptionValidableProperty => nameof(Description);

        private string name;
        private string description;
        private int priority = 1;

        public SampleAnalysisServiceStepConfigurationPageModel(Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            name = model.Name;
            description = model.Description;
            priority = model.Priority;
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
