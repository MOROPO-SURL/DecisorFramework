namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalClientVehicleLeasingCollectConfigurationPageModel : Contract.AbstractLeasingCollectConfigurationPageModel<Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel, Persistence.Entities.LegalClientVehicleLeasingCollect>
    {
        public static string AmountValidableProperty => nameof(Amount);
        public static string LeasingValidableProperty => nameof(Leasing);

        private Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel leasing;

        public LegalClientVehicleLeasingCollectConfigurationPageModel(System.DateTime expectedAt, Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel model) : base(expectedAt, model)
        {
            if (model != null)
            {
                leasing = model.Leasing;
            }
        }

        public Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel Leasing { get => leasing; set => SetProperty(ref leasing, value); }
    }
}
