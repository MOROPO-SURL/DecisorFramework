using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class WorkforceConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.WorkforceDisplayModel>
    {
        private string name;
        private System.DateTime at;
        private Domain.Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel organizationalStructure;
        private View.WorkforceConfigurationOrganizationalStructuringUnitViewModel rootOrganizationalUnity;
        private int priority = 1;

        public WorkforceConfigurationPageModel(Interop.API.Common.Models.Display.WorkforceDisplayModel model) : base(model)
        {
            if (model == null) return;
            
            Id = model.Id;
            name = model.Name;
            at = model.At;
            priority = model.Priority;
            organizationalStructure = model.OrganizationalStructure;
            rootOrganizationalUnity = organizationalStructure.RootStructuringUnit.ToConfigurationViewModel(model.OrganizationalUnits);
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<View.WorkforceConfigurationOrganizationalStructuringUnitViewModel> OrganizationalUnities { get; set; } = [];

        public Domain.Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel OrganizationalStructure { get => organizationalStructure; set => SetProperty(ref organizationalStructure, value, OrganizationalStructureChange_Callback); }

        public View.WorkforceConfigurationOrganizationalStructuringUnitViewModel RootOrganizationalUnity { get => rootOrganizationalUnity; private set => SetProperty(ref rootOrganizationalUnity, value); }

        private void OrganizationalStructureChange_Callback()
        {
            if (organizationalStructure == null) return;

            rootOrganizationalUnity = organizationalStructure.RootStructuringUnit.ToConfigurationViewModel(null);
        }
    }
}
