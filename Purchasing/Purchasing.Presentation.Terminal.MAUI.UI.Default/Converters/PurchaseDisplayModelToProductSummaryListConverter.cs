using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Converters
{
    public class PurchaseDisplayModelToProductSummaryListConverter : Microsoft.Maui.Controls.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            var concreteValue = value as Interop.API.Common.Models.Display.PurchaseDisplayModel;

            var products = new List<Inventory.Interop.API.Common.Models.Display.ProductDisplayModel>();

            foreach (var bridge in concreteValue.LegalProviderProductBridges)
            {
                if (products.Any(item => item.Id == bridge.Provider.Id)) continue;

                products.Add(bridge.Product);
            }

            foreach (var bridge in concreteValue.NaturalProviderProductBridges)
            {
                if (products.Any(item => item.Id == bridge.Provider.Id)) continue;

                products.Add(bridge.Product);
            }

            var totalizations = new List<KeyValuePair<Inventory.Interop.API.Common.Models.Display.ProductDisplayModel, decimal>>();

            foreach (var product in products) 
            {
                var amount = 0m;

                foreach (var bridge in concreteValue.LegalProviderProductBridges)
                {
                    if (bridge.Product.Id != product.Id) continue;

                    amount += bridge.Amount;
                }

                foreach (var bridge in concreteValue.NaturalProviderProductBridges)
                {
                    if (bridge.Product.Id != product.Id) continue;

                    amount += bridge.Amount;
                }

                totalizations.Add(new KeyValuePair<Inventory.Interop.API.Common.Models.Display.ProductDisplayModel, decimal>(product, amount));
            }

            return string.Join(", ", totalizations.Select(item => string.Format("{0} ({1:F2} {2})", item.Key.Name, item.Value, item.Key.DefaultUnitMeasurement.Symbol)));
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
