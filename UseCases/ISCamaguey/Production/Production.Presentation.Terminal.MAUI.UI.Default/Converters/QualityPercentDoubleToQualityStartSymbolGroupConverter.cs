using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Converters;

public sealed class QualityPercentDoubleToQualityStartSymbolGroupConverter : Microsoft.Maui.Controls.IValueConverter
{
    public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is not double concretValue) throw new System.InvalidOperationException();

        int level = System.Convert.ToInt32(double.Round(concretValue / 10D, 0));

        int filledStartCount = level / 2;

        if (filledStartCount == 5) return "\uF4CE\uF4CE\uF4CE\uF4CE\uF4CE";

        bool hasHalfFilledStart = level % 2 != 0;

        StringBuilder resultStringBuilder = new();

        for (int i = 0; i < filledStartCount; i++)
        {
            resultStringBuilder.Append("\uF4CE");
        }

        if (hasHalfFilledStart) resultStringBuilder.Append("\uF4D0");

        int emptyStartCount = 5 - filledStartCount - (hasHalfFilledStart ? 1 : 0);

        if (emptyStartCount > 0)
        {
            for (int i = 0; i < emptyStartCount; i++)
            {
                resultStringBuilder.Append("\uF4D2");
            }
        }

        return resultStringBuilder.ToString();
    }

    public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return null;
    }
}
