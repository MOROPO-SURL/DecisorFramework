using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions
{
    public static class OrganizationalUnityDisplayModelExtensions
    {
        public static Models.View.OrganizationalUnityViewModel[] ToOrganizationalUnityViewModelChildren(this Interop.API.Common.Models.Display.OrganizationalUnityDisplayModel target)
        {
            var result = new System.Collections.Generic.List<Models.View.OrganizationalUnityViewModel>();

            foreach (var item in target.Children)
            {
                var model = new Models.View.OrganizationalUnityViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Enabled = item.Enabled,
                    Priority = item.Priority,
                    Reference = item.Reference
                };

                if (item.Children != null)
                {
                    model.Children = item.ToOrganizationalUnityViewModelChildren();
                }

                if (item.Vacants != null)
                {
                    model.Vacants = new System.Collections.ObjectModel.ObservableCollection<Models.View.VacantViewModel>(item.Vacants.Select(_model => new Models.View.VacantViewModel
                    {
                        Id = _model.Id,
                        Priority = _model.Priority,
                        NamingResolutionRequired = _model.NamingResolutionRequired,
                        WorkPosition = _model.WorkPosition,
                        SalaryStandard = _model.SalaryStandard,
                        OrganizationUnity = model
                    }));
                }

                result.Add(model);
            }

            return result.OrderBy(model => model.Priority).ToArray();
        }
    }
}
