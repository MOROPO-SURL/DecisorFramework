namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.Contract;

public abstract class AbstractVacantPickOrganizationalStructuringUnitViewModel
{
    public Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel Context { get; set; }

    public TreeVacantPickOrganizationalStructuringUnitViewModel Parent { get; set; }

    public System.Collections.Generic.List<Interop.API.Common.Models.Display.VacantDisplayModel> Vacants { get; set; } = [];
}
