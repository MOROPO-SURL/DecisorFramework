namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Converters;

public class EducationLevelToIsTitulationTitleRequiredConverter : Microsoft.Maui.Controls.IValueConverter
{
    public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is not Domain.Persistence.Enumerations.EducationLevel concreteValue) return false;

        return concreteValue switch
        {
            Domain.Persistence.Enumerations.EducationLevel.Bachelor or Domain.Persistence.Enumerations.EducationLevel.Technical => true,
            _ => (object)false,
        };
    }

    public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return null;
    }
}
