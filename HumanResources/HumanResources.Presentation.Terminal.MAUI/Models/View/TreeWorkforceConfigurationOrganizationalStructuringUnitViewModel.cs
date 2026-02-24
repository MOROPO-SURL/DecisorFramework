namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class TreeWorkforceConfigurationOrganizationalStructuringUnitViewModel : Contract.AbstractWorkforceConfigurationOrganizationalStructuringUnitViewModel
    {
        public System.Collections.Generic.List<TreeWorkforceConfigurationOrganizationalStructuringUnitViewModel> DependencyChildren { get; set; } = [];

        public System.Collections.Generic.List<LeafWorkforceConfigurationOrganizationalStructuringUnitViewModel> CompositionChildren { get; set; } = [];
    }
}
