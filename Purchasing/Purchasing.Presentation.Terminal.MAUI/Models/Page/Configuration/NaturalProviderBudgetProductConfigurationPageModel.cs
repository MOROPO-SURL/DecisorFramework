namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalProviderBudgetProductConfigurationPageModel : Contract.AbstractProviderBugetProductConfigurationPageModel<Interop.API.Common.Models.Display.NaturalProviderBudgetProductDisplayModel, Persistence.Entities.NaturalProviderBudgetProduct>
    {
        public static string ProductValidableProperty => nameof(Product);
        public static string UnitPriceValidableProperty => nameof(UnitPrice);
        public static string CurrencyValidableProperty => nameof(Currency);
        public static string AmountValidableProperty => nameof(Amount);
        public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);
        public static string ClassificationValidableProperty => nameof(Classification);

        public NaturalProviderBudgetProductConfigurationPageModel(Interop.API.Common.Models.Display.NaturalProviderBudgetProductDisplayModel model) : base(model)
        {
        }
    }
}
