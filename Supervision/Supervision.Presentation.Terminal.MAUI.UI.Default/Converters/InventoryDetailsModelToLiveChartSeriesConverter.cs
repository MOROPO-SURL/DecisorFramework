using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.UI.Default.Converters
{
    public class InventoryStockDetailsModelToLiveChartSeriesConverter : Microsoft.Maui.Controls.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = "Recepciones",
                    Values = new double[] { 800, 300, 350, 850, 320, 700 }
                },
                new ColumnSeries<double>
                {
                    Name = "Salidas",
                    Values = new double[] { 200, 50, 0, 50, 200, 100 }
                },
                new LineSeries<double>
                {
                    Name = "Existencias",
                    Values = new double[] { 600, 250, 350, 800, 120, 600 }
                }
            };
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
