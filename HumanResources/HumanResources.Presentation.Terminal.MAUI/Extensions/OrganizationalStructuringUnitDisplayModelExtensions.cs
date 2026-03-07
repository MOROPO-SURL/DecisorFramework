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

        return model;
    }

    public static Models.View.TreeOcupationManageOrganizationalStructuringUnitViewModel ToConfigurationTreeViewModel(this Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel target, System.Collections.Generic.List<WorkforceOrganizationalUnitDisplayModel> workforceOrganizationalUnits, System.Collections.Generic.List<OcupationDisplayModel> ocupations, Models.View.TreeOcupationManageOrganizationalStructuringUnitViewModel parent)
    {
        var model = new Models.View.TreeOcupationManageOrganizationalStructuringUnitViewModel
        {
            Id = target.Id,
            Context = target,
            Parent = parent
        };

        var workforceOrganizationalUnit = workforceOrganizationalUnits.FirstOrDefault(_model => _model.OrganizationalStructuringUnit.Id == target.Id);

        if (workforceOrganizationalUnit != null)
        {
            var vacants = workforceOrganizationalUnit.Vacants.Select(_model =>
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
            
            if (workforceOrganizationalUnit.ChiefVacant != null)
            {
                vacants.Insert(0, new Models.View.OcupationsManageVacantViewModel
                {
                    Id = workforceOrganizationalUnit.ChiefVacant.Id,
                    VacantId = workforceOrganizationalUnit.ChiefVacant.Id,
                    VacantOcupationMode = workforceOrganizationalUnit.ChiefVacant.OcupationMode,
                    WorkPosition = workforceOrganizationalUnit.ChiefVacant.WorkPosition,
                    SalaryStandard = workforceOrganizationalUnit.ChiefVacant.SalaryStandard,
                    Ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == workforceOrganizationalUnit.ChiefVacant.Id)
                });
            }

            model.Vacants = [.. vacants];
        }

        foreach (var child in target.Children)
        {
            if (child.Kind == Domain.Persistence.Enumerations.OrganizationalStructuringUnitKind.Dependency)
                model.DependencyChildren.Add(child.ToConfigurationTreeViewModel(workforceOrganizationalUnits, ocupations, model));
            else
                model.CompositionChildren.Add(child.ToConfigurationLeafViewModel(workforceOrganizationalUnits, ocupations, model));
        }

        return model;
    }

    private static Models.View.LeafOcupationManageOrganizationalStructuringUnitViewModel ToConfigurationLeafViewModel(this Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel target, System.Collections.Generic.List<WorkforceOrganizationalUnitDisplayModel> workforceOrganizationalUnits, System.Collections.Generic.List<OcupationDisplayModel> ocupations, Models.View.TreeOcupationManageOrganizationalStructuringUnitViewModel parent)
    {
        var model = new Models.View.LeafOcupationManageOrganizationalStructuringUnitViewModel
        {
            Id = target.Id,
            Context = target,
            Parent = parent
        };

        var workforceOrganizationalUnit = workforceOrganizationalUnits.FirstOrDefault(_model => _model.OrganizationalStructuringUnit.Id == target.Id);

        if (workforceOrganizationalUnit != null)
        {
            var vacants = workforceOrganizationalUnit.Vacants.Select(_model =>
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

            if (workforceOrganizationalUnit.ChiefVacant != null)
            {
                vacants.Insert(0, new Models.View.OcupationsManageVacantViewModel
                {
                    Id = workforceOrganizationalUnit.ChiefVacant.Id,
                    VacantId = workforceOrganizationalUnit.ChiefVacant.Id,
                    VacantOcupationMode = workforceOrganizationalUnit.ChiefVacant.OcupationMode,
                    WorkPosition = workforceOrganizationalUnit.ChiefVacant.WorkPosition,
                    SalaryStandard = workforceOrganizationalUnit.ChiefVacant.SalaryStandard,
                    Ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == workforceOrganizationalUnit.ChiefVacant.Id)
                });
            }

            model.Vacants = [.. vacants];
        }

        return model;
    }

    public static Models.View.TreeVacantPickOrganizationalStructuringUnitViewModel ToConfigurationTreeViewModel(this Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel target, System.Collections.Generic.List<WorkforceOrganizationalUnitDisplayModel> workforceOrganizationalUnits, System.Collections.Generic.List<OcupationDisplayModel> ocupations, Persistence.Enumerations.VacantOcupationMode[] vacantOcupationModes, Models.View.TreeVacantPickOrganizationalStructuringUnitViewModel parent)
    {
        var model = new Models.View.TreeVacantPickOrganizationalStructuringUnitViewModel
        {
            Context = target,
            Parent = parent
        };

        var workforceOrganizationalUnit = workforceOrganizationalUnits.FirstOrDefault(_model => _model.OrganizationalStructuringUnit.Id == target.Id);

        if (workforceOrganizationalUnit != null)
        {
            if (workforceOrganizationalUnit.ChiefVacant != null && vacantOcupationModes.Any(item => item == workforceOrganizationalUnit.ChiefVacant.OcupationMode) && !ocupations.Any(_item => _item.VacantId == workforceOrganizationalUnit.ChiefVacant.Id))
            {
                model.Vacants.Add(workforceOrganizationalUnit.ChiefVacant);
            }

            var vacants = workforceOrganizationalUnit.Vacants.Where(model => vacantOcupationModes.Any(item => item == model.OcupationMode)).ToArray();

            foreach (var vacant in vacants)
            {
                var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == vacant.Id);

                if (ocupation != null)
                {
                    ocupations.Remove(ocupation);
                }
                else
                {
                    model.Vacants.Add(vacant);
                }
            }
        }

        foreach (var child in target.Children)
        {
            if (child.Kind == Domain.Persistence.Enumerations.OrganizationalStructuringUnitKind.Dependency)
                model.DependencyChildren.Add(child.ToConfigurationTreeViewModel(workforceOrganizationalUnits, ocupations, vacantOcupationModes, model));
            else
                model.CompositionChildren.Add(child.ToConfigurationLeafViewModel(workforceOrganizationalUnits, ocupations, vacantOcupationModes, model));
        }

        return model;
    }

    private static Models.View.LeafVacantPickOrganizationalStructuringUnitViewModel ToConfigurationLeafViewModel(this Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel target, System.Collections.Generic.List<WorkforceOrganizationalUnitDisplayModel> workforceOrganizationalUnits, System.Collections.Generic.List<OcupationDisplayModel> ocupations, Persistence.Enumerations.VacantOcupationMode[] vacantOcupationModes, Models.View.TreeVacantPickOrganizationalStructuringUnitViewModel parent)
    {
        var model = new Models.View.LeafVacantPickOrganizationalStructuringUnitViewModel
        {
            Context = target,
            Parent = parent
        };

        var workforceOrganizationalUnit = workforceOrganizationalUnits.FirstOrDefault(_model => _model.OrganizationalStructuringUnit.Id == target.Id);

        if (workforceOrganizationalUnit != null)
        {
            if (workforceOrganizationalUnit.ChiefVacant != null && vacantOcupationModes.Any(item => item == workforceOrganizationalUnit.ChiefVacant.OcupationMode) && !ocupations.Any(_item => _item.VacantId == workforceOrganizationalUnit.ChiefVacant.Id))
            {
                model.Vacants.Add(workforceOrganizationalUnit.ChiefVacant);
            }

            var vacants = workforceOrganizationalUnit.Vacants.Where(model => vacantOcupationModes.Any(item => item == model.OcupationMode)).ToArray();

            foreach (var vacant in vacants)
            {
                var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == vacant.Id);

                if (ocupation != null)
                {
                    ocupations.Remove(ocupation);
                }
                else
                {
                    model.Vacants.Add(vacant);
                }
            }
        }

        return model;
    }
}
