using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.UI.Default.Converters
{
    public class InventoryStockDetailsModelToLiveChartXAxisConverter : Microsoft.Maui.Controls.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Axis[]
            {
                new() {
                    Labels = ["Abr", "May", "Jun", "Jul", "Ago", "Sep"],
                    LabelsRotation = 0,
                    SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
                    SeparatorsAtCenter = false,
                    TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
                    TicksAtCenter = true,
                    // By default the axis tries to optimize the number of 
                    // labels to fit the available space, 
                    // when you need to force the axis to show all the labels then you must: 
                    ForceStepToMin = true,
                    MinStep = 1
                }
            };
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
