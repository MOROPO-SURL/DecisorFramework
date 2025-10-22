namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class GroundIntegralStudyServiceConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string ResponsibleValidableProperty => nameof(Responsible);

        private string name;
        private string description;
        private int priority = 1;
        private Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel responsible;

        public GroundIntegralStudyServiceConfigurationPageModel(Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            name = model.Name;
            description = model.Description;
            priority = model.Priority;
            responsible = model.Responsible;
            Members = [.. model.Members];
            Steps = [.. model.Steps];
            Documents = [.. model.Documents];
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public System.Collections.ObjectModel.ObservableCollection<Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel> Members { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.GroundIntegralStudyServiceStepDisplayModel> Steps { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];
    }
}
