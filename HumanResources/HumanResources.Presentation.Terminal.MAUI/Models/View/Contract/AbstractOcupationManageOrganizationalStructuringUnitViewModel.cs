namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.Contract;

public abstract class AbstractOcupationManageOrganizationalStructuringUnitViewModel : Caney.MVVM.Core.Models.BaseBindableModel
{
    public System.Guid Id { get; set; }

    public Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel Context { get; set; }

    public TreeOcupationManageOrganizationalStructuringUnitViewModel Parent { get; set; }

    public OcupationsManageVacantViewModel[] Vacants { get; set; } = [];
}
