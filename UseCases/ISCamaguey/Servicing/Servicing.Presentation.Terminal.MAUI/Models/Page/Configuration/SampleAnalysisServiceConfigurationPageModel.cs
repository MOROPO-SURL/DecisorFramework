namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class SampleAnalysisServiceConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string SampleKindValidableProperty => nameof(SampleKind);

        private string name;
        private string description;
        private int priority = 1;
        private Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel sampleKind;

        public SampleAnalysisServiceConfigurationPageModel(Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            name = model.Name;
            description = model.Description;
            priority = model.Priority;
            sampleKind = model.SampleKind;
            Steps = [.. model.Steps];
            Documents = [.. model.Documents];
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel SampleKind { get => sampleKind; set => SetProperty(ref sampleKind, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel> Steps { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];

        public Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel[] AvailableSampleKinds { get; set; }
    }
}
