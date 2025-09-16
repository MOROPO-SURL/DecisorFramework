namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleLeasePersonPostulationConfigurationPageModel : Contract.AbstractLeasePersonPostulationConfigurationPageModel<Interop.API.Common.Models.Display.VehicleLeasePersonPostulationDisplayModel, Persistence.Entities.VehicleLeasePersonPostulation>
    {
        public static string ContactValidableProperty => nameof(Contact);
        public static string MainPostalContactItemValidableProperty => nameof(MainPostalContactItem);
        public static string TaxIdentificationNumberValidableProperty => nameof(TaxIdentificationNumber);
        public static string BusinessKindNumberValidableProperty => nameof(BusinessKind);
        public static string ArgumentValidableProperty => nameof(Argument);

        public VehicleLeasePersonPostulationConfigurationPageModel(System.Guid offerId, Interop.API.Common.Models.Display.VehicleLeasePersonPostulationDisplayModel model) : base(offerId, model)
        {
        }
    }
}
