namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleLeaseOrganizationPostulationConfigurationPageModel : Contract.AbstractLeaseOrganizationPostulationConfigurationPageModel<Interop.API.Common.Models.Display.VehicleLeaseOrganizationPostulationDisplayModel, Persistence.Entities.VehicleLeaseOrganizationPostulation>
    {
        public static string ContactValidableProperty => nameof(Contact);
        public static string MainPostalContactItemValidableProperty => nameof(MainPostalContactItem);
        public static string TaxIdentificationNumberValidableProperty => nameof(TaxIdentificationNumber);
        public static string ArgumentValidableProperty => nameof(Argument);

        public VehicleLeaseOrganizationPostulationConfigurationPageModel(System.Guid offerId, Interop.API.Common.Models.Display.VehicleLeaseOrganizationPostulationDisplayModel model) : base(offerId, model)
        {
        }
    }
}
