using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class WorkforceConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.WorkforceDisplayModel>
    {
        private string name;
        private System.DateTime at;
        private View.WorkforceConfigurationVacantViewModel chiefVacant;
        private int priority = 1;

        public WorkforceConfigurationPageModel(Interop.API.Common.Models.Display.WorkforceDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                name = model.Name;
                at = model.At;
                priority = model.Priority;

                var result = model.OrganizationalUnities.ToOrganizationalUnityViewModelChildren();

                foreach (var _item in result)
                {
                    OrganizationalUnities.Add(_item);

                    if (_item.ChiefVacant?.Id == model.OrganizationalStructure.Id) chiefVacant = _item.ChiefVacant;
                }

                chiefVacant ??= new View.WorkforceConfigurationVacantViewModel
                {
                    Id = model.OrganizationalStructure.Id,
                    OcupationMode = model.OrganizationalStructure.OcupationMode,
                    SalaryStandard = model.OrganizationalStructure.SalaryStandard,
                    WorkPosition = model.OrganizationalStructure.WorkPosition,
                    Priority = model.OrganizationalStructure.Priority
                };
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public View.WorkforceConfigurationVacantViewModel ChiefVacant { get => chiefVacant; set => SetProperty(ref chiefVacant, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<View.WorkforceConfigurationOrganizationalUnityViewModel> OrganizationalUnities { get; set; } = [];
    }
}
