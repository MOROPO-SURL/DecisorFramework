using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions
{
    public static class OrganizationalUnityDisplayModelExtensions
    {
        public static Models.View.WorkforceConfigurationOrganizationalUnityViewModel[] ToOrganizationalUnityViewModelChildren(this Interop.API.Common.Models.Display.OrganizationalUnityDisplayModel target)
        {
            var result = new System.Collections.Generic.List<Models.View.WorkforceConfigurationOrganizationalUnityViewModel>();

            foreach (var item in target.Children)
            {
                var model = new Models.View.WorkforceConfigurationOrganizationalUnityViewModel
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
                    model.Vacants = new System.Collections.ObjectModel.ObservableCollection<Models.View.WorkforceConfigurationVacantViewModel>(item.Vacants.Select(_model => new Models.View.WorkforceConfigurationVacantViewModel
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
        public static Models.View.OcupationsRawManageOrganizationalUnityViewModel[] ToOrganizationalUnityViewModelChildren(this Interop.API.Common.Models.Display.OrganizationalUnityDisplayModel target, System.Collections.Generic.List<Interop.API.Common.Models.Display.OcupationDisplayModel> ocupations)
        {
            var result = new System.Collections.Generic.List<Models.View.OcupationsRawManageOrganizationalUnityViewModel>();

            foreach (var item in target.Children)
            {
                var model = new Models.View.OcupationsRawManageOrganizationalUnityViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Enabled = item.Enabled,
                    Priority = item.Priority,
                    Reference = item.Reference
                };

                if (item.Vacants != null)
                {
                    model.Vacants = item.Vacants.Select(_model =>
                    {
                        var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == _model.Id);

                        var result = new Models.View.OcupationsRawManageVacantViewModel
                        {
                            Id = _model.Id,
                            NamingResolutionRequired = _model.NamingResolutionRequired,
                            WorkPosition = _model.WorkPosition,
                            SalaryStandard = _model.SalaryStandard,
                            Ocupation = ocupation
                        };

                        if (ocupation != null) ocupations.Remove(ocupation);

                        return result;
                    }).ToArray();
                }

                if (item.Children != null)
                {
                    model.Children = item.ToOrganizationalUnityViewModelChildren(ocupations);
                }

                result.Add(model);
            }

            return result.OrderBy(model => model.Priority).ToArray();
        }
    }
}
