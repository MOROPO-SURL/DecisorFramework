using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class SupervisionGroupConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<SupervisionGroupDisplayModel>
    {
        private int priority = 1;
        private string name;
        private string description;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel representative;

        public SupervisionGroupConfigurationPageModel(SupervisionGroupDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            priority = model.Priority;
            name = model.Name;
            description = model.Description;
            representative = model.Representative;
            Members = new System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>(model.Members);
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Representative { get => representative; set => SetProperty(ref representative, value); }

        public System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel> Members { get; set; } = [];
    }
}
