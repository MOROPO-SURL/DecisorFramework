namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertyLeaseOrganizationPostulationConfigurationPageModel : Contract.AbstractLeaseOrganizationPostulationConfigurationPageModel<Interop.API.Common.Models.Display.PropertyLeaseOrganizationPostulationDisplayModel, Persistence.Entities.PropertyLeaseOrganizationPostulation>
    {
        public PropertyLeaseOrganizationPostulationConfigurationPageModel(System.Guid offerId, Interop.API.Common.Models.Display.PropertyLeaseOrganizationPostulationDisplayModel model) : base(offerId, model)
        {
        }
    }
}