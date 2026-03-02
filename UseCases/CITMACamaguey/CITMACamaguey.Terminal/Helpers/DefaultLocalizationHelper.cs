using System.Globalization;

namespace MOROPO.CITMACamaguey.Decisor.Terminal.Helpers;

internal class DefaultLocalizationHelper : Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.ILocalizationHelperFacade
{
    public string GetString(string value, CultureInfo culture)
    {
        return LocalizationResources.ResourceManager.GetString(value, culture);
    }
}
