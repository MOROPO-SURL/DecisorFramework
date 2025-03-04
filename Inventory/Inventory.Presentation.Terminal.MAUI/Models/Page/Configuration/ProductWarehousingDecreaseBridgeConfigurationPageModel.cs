namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductWarehousingDecreaseBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel>
    {
        private Persistence.Enumerations.WarehousingDecreaseKind kind;
        private decimal minDecrease = 1;
        private decimal maxDecrease = 5;

        public ProductWarehousingDecreaseBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel model) : base(model)
        {
            if (model != null)
            {
                Kind = model.Kind;
                MinDecrease = model.MinDecrease;
                MaxDecrease = model.MaxDecrease;
            }
        }

        public Persistence.Enumerations.WarehousingDecreaseKind Kind { get => kind; set => SetProperty(ref kind, value); }

        public decimal MinDecrease { get => minDecrease; set => SetProperty(ref minDecrease, value); }

        public decimal MaxDecrease { get => maxDecrease; set => SetProperty(ref maxDecrease, value); }

        public Persistence.Enumerations.WarehousingDecreaseKind[] AvailableKinds { get; private set; } = [Persistence.Enumerations.WarehousingDecreaseKind.Transportation, Persistence.Enumerations.WarehousingDecreaseKind.Freezing];
    }
}
