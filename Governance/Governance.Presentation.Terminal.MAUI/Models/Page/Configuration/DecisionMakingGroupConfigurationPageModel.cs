using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class DecisionMakingGroupConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel>
    {
        private int priority = 1;
        private string name;
        public string description;
        private Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel structure;
        private HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel leader;

        public DecisionMakingGroupConfigurationPageModel(Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Priority = model.Priority;
                Structure = model.Structure;
                Leader = model.Leader;
                Members = new ObservableCollection<HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel>(model.Members);
                Collaborators = new ObservableCollection<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel>(model.Collaborators);
            }
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel Structure { get => structure; set => SetProperty(ref structure, value); }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Leader { get => leader; set => SetProperty(ref leader, value); }

        public ObservableCollection<HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel> Members { get; set; } = [];

        public ObservableCollection<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel> Collaborators { get; set; } = [];

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel[] AvailableStructures { get; set; }
    }
}
