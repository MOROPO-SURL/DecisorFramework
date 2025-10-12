using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class WorkingGroupConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.WorkingGroupDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string ChiefValidableProperty => nameof(Chief);
        public static string QualitySpecialistValidableProperty => nameof(QualitySpecialist);

        private int priority = 1;
        private string name;
        private string description;
        private EmployeeDisplayModel chief;
        private EmployeeDisplayModel qualitySpecialist;

        public WorkingGroupConfigurationPageModel(Interop.API.Common.Models.Display.WorkingGroupDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            priority = model.Priority;
            name = model.Name;
            description = model.Description;
            chief = model.Chief;
            qualitySpecialist = model.QualitySpecialist;
            Employees = new System.Collections.ObjectModel.ObservableCollection<EmployeeDisplayModel>(model.Employees);
            Techniques = new System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel>(model.Techniques);
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public EmployeeDisplayModel Chief { get => chief; set => SetProperty(ref chief, value); }

        public EmployeeDisplayModel QualitySpecialist { get => qualitySpecialist; set => SetProperty(ref qualitySpecialist, value); }

        public System.Collections.ObjectModel.ObservableCollection<EmployeeDisplayModel> Employees { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel> Techniques { get; set; } = [];
    }
}
