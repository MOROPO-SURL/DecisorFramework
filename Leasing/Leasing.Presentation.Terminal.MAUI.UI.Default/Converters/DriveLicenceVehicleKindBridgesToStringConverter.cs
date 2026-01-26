using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Converters;

public class DriveLicenceVehicleKindBridgesToStringConverter : Microsoft.Maui.Controls.IValueConverter
{
    public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is not Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel[] concreteValue) return string.Empty;

        return string.Join(',', concreteValue.Select(item => item.Category.ToString()));
    }

    public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return null;
    }
}