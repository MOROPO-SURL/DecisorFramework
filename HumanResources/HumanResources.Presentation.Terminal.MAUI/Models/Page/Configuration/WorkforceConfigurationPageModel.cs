using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class WorkforceConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.WorkforceDisplayModel>
    {
        private string name;
        private System.DateTime at;
        private int priority = 1;

        public WorkforceConfigurationPageModel() : this(null) { }

        public WorkforceConfigurationPageModel(Interop.API.Common.Models.Display.WorkforceDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                At = model.At;
                Priority = model.Priority;

                foreach (var item in model.OrganizationalUnities)
                {
                    var result = new View.WorkforceConfigurationOrganizationalUnityViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Enabled = item.Enabled,
                        Priority = item.Priority,
                        Reference = item.Reference
                    };

                    if (item.Children != null)
                    {
                        result.Children = item.ToOrganizationalUnityViewModelChildren();
                    }

                    if (item.Vacants != null)
                    {
                        result.Vacants = new System.Collections.ObjectModel.ObservableCollection<Models.View.WorkforceConfigurationVacantViewModel>(item.Vacants.Select(__model => new View.WorkforceConfigurationVacantViewModel
                        {
                            Id = __model.Id,
                            Priority = __model.Priority,
                            NamingResolutionRequired = __model.NamingResolutionRequired,
                            WorkPosition = __model.WorkPosition,
                            SalaryStandard = __model.SalaryStandard,
                            OrganizationUnity = result
                        }));
                    }

                    OrganizationalUnities.Add(result);
                }
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<View.WorkforceConfigurationOrganizationalUnityViewModel> OrganizationalUnities { get; set; } = [];
    }
}
