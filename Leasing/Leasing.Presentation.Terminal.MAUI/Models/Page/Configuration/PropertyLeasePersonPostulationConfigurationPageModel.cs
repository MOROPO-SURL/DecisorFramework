namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertyLeasePersonPostulationConfigurationPageModel : Contract.AbstractLeasePersonPostulationConfigurationPageModel<Interop.API.Common.Models.Display.PropertyLeasePersonPostulationDisplayModel, Persistence.Entities.PropertyLeasePersonPostulation>
    {
        public PropertyLeasePersonPostulationConfigurationPageModel(System.Guid offerId, Interop.API.Common.Models.Display.PropertyLeasePersonPostulationDisplayModel model) : base(offerId, model)
        {
        }
    }
}
