namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CurrencyConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.CurrencyDisplayModel>
    {
        private string name;
        private string symbol;
        private int priority = 1;
        private bool useEndSymbolPresentation;

        public CurrencyConfigurationPageModel(Interop.API.Common.Models.Display.CurrencyDisplayModel model) : base(model)
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

        public bool UseEndSymbolPresentation { get => useEndSymbolPresentation; set => SetProperty(ref useEndSymbolPresentation, value); }
    }
}