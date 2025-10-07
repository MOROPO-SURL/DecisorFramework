using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions
{
    public static class OrganizationalUnityDisplayModelExtensions
    {
        public static Models.View.WorkforceConfigurationOrganizationalUnityViewModel[] ToOrganizationalUnityViewModelChildren(this Interop.API.Common.Models.Display.WorkforceOrganizationalUnityDisplayModel[] targets)
        {
            var result = new System.Collections.Generic.List<Models.View.WorkforceConfigurationOrganizationalUnityViewModel>();

            foreach (var item in targets)
            {
                var model = new Models.View.WorkforceConfigurationOrganizationalUnityViewModel
                {
                    Id = item.Id,
                    Domain = item.OrganizationalUnity
                };

                model.ChiefVacant = item.ChiefVacant == null ? null : new Models.View.WorkforceConfigurationVacantViewModel
                {
                    Id = item.ChiefVacant.Id,
                    Priority = item.ChiefVacant.Priority,
                    OcupationMode = item.ChiefVacant.OcupationMode,
                    WorkPosition = item.ChiefVacant.WorkPosition,
                    SalaryStandard = item.ChiefVacant.SalaryStandard,
                    OrganizationUnity = model
                };

                if (item.Children != null)
                {
                    model.Children = item.Children.ToOrganizationalUnityViewModelChildren();
                }

                if (item.Vacants != null)
                {
                    model.Vacants = new System.Collections.ObjectModel.ObservableCollection<Models.View.WorkforceConfigurationVacantViewModel>(item.Vacants.Select(_model => new Models.View.WorkforceConfigurationVacantViewModel
                    {
                        Id = _model.Id,
                        Priority = _model.Priority,
                        OcupationMode = _model.OcupationMode,
                        WorkPosition = _model.WorkPosition,
                        SalaryStandard = _model.SalaryStandard,
                        OrganizationUnity = model
                    }));
                }

                result.Add(model);
            }

            return result.OrderBy(model => model.Domain.Priority).ToArray();
        }

        public static Models.View.OcupationsRawManageOrganizationalUnityViewModel[] ToOcupationsRawManageOrganizationalUnityViewModelChildren(this Interop.API.Common.Models.Display.WorkforceOrganizationalUnityDisplayModel[] targets, System.Collections.Generic.List<Interop.API.Common.Models.Display.OcupationDisplayModel> ocupations)
        {
            var result = new System.Collections.Generic.List<Models.View.OcupationsRawManageOrganizationalUnityViewModel>();

            foreach (var target in targets)
            {
                var model = new Models.View.OcupationsRawManageOrganizationalUnityViewModel
                {
                    Id = target.Id,
                    Name = target.OrganizationalUnity.Name,
                    Enabled = target.OrganizationalUnity.Enabled,
                    Priority = target.OrganizationalUnity.Priority,
                    Reference = target.OrganizationalUnity.Reference
                };

                if (target.Vacants != null)
                {
                    model.Vacants = target.Vacants.Select(_model =>
                    {
                        var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == _model.Id);

                        var result = new Models.View.OcupationsRawManageVacantViewModel
                        {
                            Id = _model.Id,
                            VacantOcupationMode = _model.OcupationMode,
                            WorkPosition = _model.WorkPosition,
                            SalaryStandard = _model.SalaryStandard,
                            Ocupation = ocupation
                        };

                        if (ocupation != null) ocupations.Remove(ocupation);

                        return result;
                    }).ToArray();
                }

                if (target.OrganizationalUnity.Children != null)
                {
                    model.Children = target.Children.ToOcupationsRawManageOrganizationalUnityViewModelChildren(ocupations);
                }

                result.Add(model);
            }

            return result.OrderBy(model => model.Priority).ToArray();
        }

        public static Models.View.VacantPickOrganizationalUnityViewModel[] ToVacantPickOrganizationalUnityViewModelChildren(this Interop.API.Common.Models.Display.WorkforceOrganizationalUnityDisplayModel[] targets, System.Collections.Generic.List<Interop.API.Common.Models.Display.OcupationDisplayModel> ocupations)
        {
            var result = new System.Collections.Generic.List<Models.View.VacantPickOrganizationalUnityViewModel>();

            foreach (var target in targets)
            {
                var model = new Models.View.VacantPickOrganizationalUnityViewModel
                {
                    Id = target.Id,
                    Name = target.OrganizationalUnity.Name,
                    Enabled = target.OrganizationalUnity.Enabled,
                    Priority = target.OrganizationalUnity.Priority,
                    Reference = target.OrganizationalUnity.Reference
                };

                if (target.Vacants != null)
                {
                    var vacants = new System.Collections.Generic.List<Interop.API.Common.Models.Display.VacantDisplayModel>();

                    foreach (var vacant in target.Vacants)
                    {
                        var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == vacant.Id);

                        if (ocupation != null)
                        {
                            ocupations.Remove(ocupation);
                        }
                        else
                        {
                            vacants.Add(vacant);
                        }
                    }

                    model.Vacants = vacants.ToArray();
                }

                if (target.OrganizationalUnity.Children != null)
                {
                    model.Children = target.Children.ToVacantPickOrganizationalUnityViewModelChildren(ocupations);
                }

                result.Add(model);
            }

            return result.OrderBy(model => model.Priority).ToArray();
        }
    }
}
