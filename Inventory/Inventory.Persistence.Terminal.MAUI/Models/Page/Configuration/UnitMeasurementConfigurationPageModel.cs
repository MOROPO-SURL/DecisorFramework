namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class UnitMeasurementConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel>
    {
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
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Symbol { get => symbol; set => SetProperty(ref symbol, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
