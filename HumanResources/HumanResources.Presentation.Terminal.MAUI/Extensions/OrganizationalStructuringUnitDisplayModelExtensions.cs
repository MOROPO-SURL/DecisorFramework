using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;

public static class OrganizationalStructuringUnitDisplayModelExtensions
{
    public static Models.View.TreeWorkforceConfigurationOrganizationalStructuringUnitViewModel ToConfigurationTreeViewModel(this Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel target, WorkforceOrganizationalUnitDisplayModel[] workforceOrganizationalUnits, Models.View.TreeWorkforceConfigurationOrganizationalStructuringUnitViewModel parent)
    {
        var model = new Models.View.TreeWorkforceConfigurationOrganizationalStructuringUnitViewModel
        {
            Id = target.Id,
            Context = target,
            Parent = parent
        };

        var workforceOrganizationalUnit = workforceOrganizationalUnits?.FirstOrDefault(_model => _model.OrganizationalStructuringUnit.Id == target.Id);

        model.ChiefVacant = workforceOrganizationalUnit?.ChiefVacant == null ? null : new Models.View.WorkforceConfigurationVacantViewModel
        {
            Id = workforceOrganizationalUnit.ChiefVacant.Id,
            Priority = workforceOrganizationalUnit.ChiefVacant.Priority,
            OcupationMode = workforceOrganizationalUnit.ChiefVacant.OcupationMode,
            WorkPosition = workforceOrganizationalUnit.ChiefVacant.WorkPosition,
            SalaryStandard = workforceOrganizationalUnit.ChiefVacant.SalaryStandard,
            Context = model
        };

        if (workforceOrganizationalUnit?.Vacants != null)
        {
            model.Vacants = new System.Collections.ObjectModel.ObservableCollection<Models.View.WorkforceConfigurationVacantViewModel>(workforceOrganizationalUnit.Vacants.Select(_model => new Models.View.WorkforceConfigurationVacantViewModel
            {
                Id = _model.Id,
                Priority = _model.Priority,
                OcupationMode = _model.OcupationMode,
                WorkPosition = _model.WorkPosition,
                SalaryStandard = _model.SalaryStandard,
                Context = model
            }));
        }

        foreach (var child in target.Children)
        {
            if (child.Kind == Domain.Persistence.Enumerations.OrganizationalStructuringUnitKind.Dependency)
                model.DependencyChildren.Add(child.ToConfigurationTreeViewModel(workforceOrganizationalUnits, model));
            else
                model.CompositionChildren.Add(child.ToConfigurationLeafViewModel(workforceOrganizationalUnits, model));
        }

        return model;
    }

    private static Models.View.LeafWorkforceConfigurationOrganizationalStructuringUnitViewModel ToConfigurationLeafViewModel(this Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel target, WorkforceOrganizationalUnitDisplayModel[] workforceOrganizationalUnits, Models.View.TreeWorkforceConfigurationOrganizationalStructuringUnitViewModel parent)
    {
        var model = new Models.View.LeafWorkforceConfigurationOrganizationalStructuringUnitViewModel
        {
            Id = target.Id,
            Context = target,
            Parent = parent
        };

        //var workforceOrganizationalUnit = workforceOrganizationalUnits?.FirstOrDefault(_model => _model.OrganizationalStructuringUnit.Id == target.Id);

        //model.ChiefVacant = workforceOrganizationalUnit.ChiefVacant == null ? null : new Models.View.WorkforceConfigurationVacantViewModel
        //{
        //    Id = workforceOrganizationalUnit.ChiefVacant.Id,
        //    Priority = workforceOrganizationalUnit.ChiefVacant.Priority,
        //    OcupationMode = workforceOrganizationalUnit.ChiefVacant.OcupationMode,
        //    WorkPosition = workforceOrganizationalUnit.ChiefVacant.WorkPosition,
        //    SalaryStandard = workforceOrganizationalUnit.ChiefVacant.SalaryStandard,
        //    Context = model
        //};

        //if (workforceOrganizationalUnit.Vacants != null)
        //{
        //    model.Vacants = new System.Collections.ObjectModel.ObservableCollection<Models.View.WorkforceConfigurationVacantViewModel>(workforceOrganizationalUnit.Vacants.Select(_model => new Models.View.WorkforceConfigurationVacantViewModel
        //    {
        //        Id = _model.Id,
        //        Priority = _model.Priority,
        //        OcupationMode = _model.OcupationMode,
        //        WorkPosition = _model.WorkPosition,
        //        SalaryStandard = _model.SalaryStandard,
        //        Context = model
        //    }));
        //}

        return model;
    }

    public static Models.View.OcupationsManageOrganizationalUnityViewModel[] ToOcupationsManageOrganizationalUnitViewModelChildren(this Interop.API.Common.Models.Display.WorkforceOrganizationalUnitDisplayModel[] targets, System.Collections.Generic.List<Interop.API.Common.Models.Display.OcupationDisplayModel> ocupations)
    {
        var result = new System.Collections.Generic.List<Models.View.OcupationsManageOrganizationalUnityViewModel>();

        foreach (var target in targets)
        {
            var model = new Models.View.OcupationsManageOrganizationalUnityViewModel
            {
                Id = target.Id,
                //Name = target.OrganizationalStructuringUnit.Name,
                //Enabled = target.OrganizationalStructuringUnit.Enabled,
                //Priority = target.OrganizationalStructuringUnit.Priority,
                //Reference = target.OrganizationalUnity.Reference
            };

            if (target.Vacants != null)
            {
                var vacants = target.Vacants.Select(_model =>
                {
                    var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == _model.Id);

                    var result = new Models.View.OcupationsManageVacantViewModel
                    {
                        Id = _model.Id,
                        VacantId = _model.Id,
                        VacantOcupationMode = _model.OcupationMode,
                        WorkPosition = _model.WorkPosition,
                        SalaryStandard = _model.SalaryStandard,
                        Ocupation = ocupation
                    };

                    if (ocupation != null) ocupations.Remove(ocupation);

                    return result;
                }).ToList();

                if (target.ChiefVacant != null)
                {
                    vacants.Insert(0, new Models.View.OcupationsManageVacantViewModel
                    {
                        Id = target.ChiefVacant.Id,
                        VacantId = target.ChiefVacant.Id,
                        VacantOcupationMode = target.ChiefVacant.OcupationMode,
                        WorkPosition = target.ChiefVacant.WorkPosition,
                        SalaryStandard = target.ChiefVacant.SalaryStandard,
                        Ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == target.ChiefVacant.Id)
                    });
                }

                model.Vacants = vacants.ToArray();
            }
            else if (target.ChiefVacant != null)
            {
                model.Vacants = 
                [
                    new Models.View.OcupationsManageVacantViewModel
                    {
                        Id = target.ChiefVacant.Id,
                        VacantId = target.ChiefVacant.Id,
                        VacantOcupationMode = target.ChiefVacant.OcupationMode,
                        WorkPosition = target.ChiefVacant.WorkPosition,
                        SalaryStandard = target.ChiefVacant.SalaryStandard,
                        Ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == target.ChiefVacant.Id)
                    }
                ];
            }

            //if (target.Children != null)
            //{
            //    model.Children = target.Children.ToOcupationsManageOrganizationalUnityViewModelChildren(ocupations);
            //}

            result.Add(model);
        }

        return result.OrderBy(model => model.Priority).ToArray();
    }

    public static Models.View.VacantPickOrganizationalUnityViewModel[] ToVacantPickOrganizationalUnityViewModelChildren(this Interop.API.Common.Models.Display.WorkforceOrganizationalUnitDisplayModel[] targets, System.Collections.Generic.List<Interop.API.Common.Models.Display.OcupationDisplayModel> ocupations, Persistence.Enumerations.VacantOcupationMode[] vacantOcupationModes)
    {
        var result = new System.Collections.Generic.List<Models.View.VacantPickOrganizationalUnityViewModel>();

        foreach (var target in targets)
        {
            var model = new Models.View.VacantPickOrganizationalUnityViewModel
            {
                Id = target.Id,
                //Name = target.OrganizationalStructuringUnit.Name,
                //Enabled = target.OrganizationalStructuringUnit.Enabled,
                //Priority = target.OrganizationalStructuringUnit.Priority,
                //Reference = target.OrganizationalUnity.Reference
            };

            var _result = new System.Collections.Generic.List<Interop.API.Common.Models.Display.VacantDisplayModel>();

            if (target.ChiefVacant != null && vacantOcupationModes.Any(item => item == target.ChiefVacant.OcupationMode) && !ocupations.Any(_item => _item.VacantId == target.ChiefVacant.Id))
            {
                _result.Add(target.ChiefVacant);
            }

            var vacants = target.Vacants.Where(model => vacantOcupationModes.Any(item => item == model.OcupationMode)).ToArray();

            foreach (var vacant in vacants)
            {
                var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == vacant.Id);

                if (ocupation != null)
                {
                    ocupations.Remove(ocupation);
                }
                else
                {
                    _result.Add(vacant);
                }
            }

            model.Vacants = _result.ToArray();

            //if (target.Children != null)
            //{
            //    model.Children = target.Children.ToVacantPickOrganizationalUnityViewModelChildren(ocupations, vacantOcupationModes);
            //}

            result.Add(model);
        }

        return result.OrderBy(model => model.Priority).ToArray();
    }
}
