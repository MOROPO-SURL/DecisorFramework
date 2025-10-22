namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class UnitMeasurementConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string SymbolValidableProperty => nameof(Symbol);

        private string name;
        private string symbol;
        private int priority = 1;

        public UnitMeasurementConfigurationPageModel(Interop.API.Common.Models.Display.UnitMeasurementDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Symbol = model.Symbol;
                Priority = model.Priority;
                ConvertionBridges = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel>(model.ConverstionBridges);
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Symbol { get => symbol; set => SetProperty(ref symbol, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel> ConvertionBridges { get; set; } = [];
    }
}
