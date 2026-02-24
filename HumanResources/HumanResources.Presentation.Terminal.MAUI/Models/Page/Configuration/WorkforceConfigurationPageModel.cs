using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class WorkforceConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.WorkforceDisplayModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string OrganizationalStructureValidableProperty => nameof(OrganizationalStructure);

    private readonly Interop.API.Common.Models.Display.WorkforceOrganizationalUnitDisplayModel[] organizationalUnits;

    private string name;
    private System.DateTime at;
    private Domain.Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel organizationalStructure;
    private View.TreeWorkforceConfigurationOrganizationalStructuringUnitViewModel rootWorkforceConfigurationOrganizationalStructuringUnit;
    private int priority = 1;

    public WorkforceConfigurationPageModel(Interop.API.Common.Models.Display.WorkforceDisplayModel model) : base(model)
    {
        if (model == null) return;
        
        Id = model.Id;
        organizationalUnits = model.OrganizationalUnits;
        name = model.Name;
        at = model.At;
        priority = model.Priority;
        organizationalStructure = model.OrganizationalStructure;
        rootWorkforceConfigurationOrganizationalStructuringUnit = organizationalStructure.RootStructuringUnit.ToConfigurationTreeViewModel(organizationalUnits, null);
    }

    public System.Guid Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public Domain.Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel OrganizationalStructure { get => organizationalStructure; set => SetProperty(ref organizationalStructure, value, OrganizationalStructureChange_Callback); }

    public View.TreeWorkforceConfigurationOrganizationalStructuringUnitViewModel RootWorkforceConfigurationOrganizationalStructurinUnit { get => rootWorkforceConfigurationOrganizationalStructuringUnit; set => SetProperty(ref rootWorkforceConfigurationOrganizationalStructuringUnit, value); }

    public Domain.Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel[] AvailableOrganizationalStructures { get; set; }

    public List<Interop.API.Common.Models.Input.WorkforceOrganizationalUnitInputModel> EditionOrganizationalUnits { get; private set; } = [];
    public List<Interop.API.Common.Models.Input.WorkforceOrganizationalUnitInputModel> IncomingOrganizationalUnits { get; private set; } = [];
    public List<Interop.API.Common.Models.Display.WorkforceOrganizationalUnitDisplayModel> OutgoingOrganizationalUnits { get; private set; } = [];

    private void OrganizationalStructureChange_Callback()
    {
        if (organizationalStructure == null) return;

        RootWorkforceConfigurationOrganizationalStructurinUnit = organizationalStructure.RootStructuringUnit.ToConfigurationTreeViewModel(organizationalUnits, null);
    }

    public Interop.API.Common.Models.Input.WorkforceOrganizationalUnitInputModel FindConfiguratingTargetWorkforceOrganizationalUnit(View.WorkforceConfigurationVacantViewModel model)
    {
        if (IncomingOrganizationalUnits.Count <= 0 && EditionOrganizationalUnits.Count <= 0) return null;

        foreach (var item in IncomingOrganizationalUnits)
        {
            if (item.OrganizationalStructuringUnitId != model.Context.Id) continue;

            return item;
        }

        foreach (var item in EditionOrganizationalUnits)
        {
            if (item.OrganizationalStructuringUnitId != model.Context.Id) continue;

            return item;
        }

        return null;
    }

    public Interop.API.Common.Models.Input.WorkforceOrganizationalUnitInputModel FindPersistedTargetWorkforceOrganizationalUnit(View.WorkforceConfigurationVacantViewModel model)
    {
        foreach (var item in organizationalUnits)
        {
            if (item.OrganizationalStructuringUnit.Id != model.Context.Id) continue;

            return new Interop.API.Common.Models.Input.WorkforceOrganizationalUnitInputModel
            {
                Id = item.OrganizationalStructuringUnit.Id,
                OrganizationalStructuringUnitId = item.OrganizationalStructuringUnit.Id
            };
        }

        return null;
    }
}