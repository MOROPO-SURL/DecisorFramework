namespace MOROPO.EPTCamaguey.Decisor.Terminal.UI.Converters
{
    public class MenuFlyoutItemToViewConverter : Microsoft.Maui.Controls.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            var concreteValue = value as Microsoft.Maui.Controls.ShellItem;

            switch (concreteValue.Title)
            {
                case "Estructural":
                case "Activos":
                case "Complementarios":
                    return new Views.ModuleFlyoutSectionSubtitleContentView();

                default:
                    return new Views.ModuleFlyoutSectionTitleContentView();
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
