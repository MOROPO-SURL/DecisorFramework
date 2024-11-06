using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Extensions;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Converters
{
	public class CategoryToTreeNameConverter : Microsoft.Maui.Controls.IValueConverter
	{
        public string Separator { get; set; }

		public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Interop.API.Common.Models.Display.CategoryDisplayModel)value).ToTreeName(Separator);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}

