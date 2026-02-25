namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View;

public class TreeOcupationManageOrganizationalStructuringUnitViewModel : Contract.AbstractOcupationManageOrganizationalStructuringUnitViewModel
{
    public System.Collections.Generic.List<TreeOcupationManageOrganizationalStructuringUnitViewModel> DependencyChildren { get; set; } = [];

    public System.Collections.Generic.List<LeafOcupationManageOrganizationalStructuringUnitViewModel> CompositionChildren { get; set; } = [];
}