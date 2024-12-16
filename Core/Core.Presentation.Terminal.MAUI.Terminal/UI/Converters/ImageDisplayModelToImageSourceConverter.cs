namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Converters
{
    public class ImageDisplayModelToImageSourceConverter : Microsoft.Maui.Controls.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            var model = value as Interop.API.Common.Models.Display.ImageDisplayModel;

            return Providers.ImageSourceProvider.GetByModel(model);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
