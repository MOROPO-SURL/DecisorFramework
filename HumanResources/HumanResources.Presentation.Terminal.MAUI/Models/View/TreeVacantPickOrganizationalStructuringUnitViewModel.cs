namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View;

public sealed class TreeVacantPickOrganizationalStructuringUnitViewModel : Contract.AbstractVacantPickOrganizationalStructuringUnitViewModel
{
    public System.Collections.Generic.List<TreeVacantPickOrganizationalStructuringUnitViewModel> DependencyChildren { get; set; } = [];

    public System.Collections.Generic.List<LeafVacantPickOrganizationalStructuringUnitViewModel> CompositionChildren { get; set; } = [];
}