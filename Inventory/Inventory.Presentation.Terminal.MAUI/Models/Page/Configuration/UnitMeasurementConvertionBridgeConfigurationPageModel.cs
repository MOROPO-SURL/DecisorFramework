namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class UnitMeasurementConvertionBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel>
    {
        private Interop.API.Common.Models.Display.UnitMeasurementDisplayModel destination;
        private decimal convertion;

        public UnitMeasurementConvertionBridgeConfigurationPageModel(Interop.API.Common.Models.Display.UnitMeasurementDisplayModel source, Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel model) : base(model)
        {
            Source = source;

            if (model != null)
            {
                Destination = model.Destination;
                Convertion = model.Convertion;
            }
        }

        public Interop.API.Common.Models.Display.UnitMeasurementDisplayModel Source { get; set; }

        public Interop.API.Common.Models.Display.UnitMeasurementDisplayModel Destination { get => destination; set => SetProperty(ref destination, value); }

        public decimal Convertion { get => convertion; set => SetProperty(ref convertion, value); }

        public Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; } = [];
    }
}
