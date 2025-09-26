namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalClientVehicleLeasingCollectConfigurationPageModel : Contract.AbstractLeasingCollectConfigurationPageModel<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel, Persistence.Entities.NaturalClientVehicleLeasingCollect>
    {
        public static string AmountValidableProperty => nameof(Amount);
        public static string LeasingValidableProperty => nameof(Leasing);

        private Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel leasing;

        public NaturalClientVehicleLeasingCollectConfigurationPageModel(System.DateTime expectedAt, Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel model) : base(expectedAt, model)
        {
            if (model != null)
            {
                leasing = model.Leasing;
            }
        }

        public Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel Leasing { get => leasing; set => SetProperty(ref leasing, value); }
    }
}
