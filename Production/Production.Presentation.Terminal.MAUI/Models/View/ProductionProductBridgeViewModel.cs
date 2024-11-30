namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.View
{
    public class ProductionProductBridgeViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private decimal amount;

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public Inventory.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }
    }
}
