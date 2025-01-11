using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions
{
    public static class ImageDisplayModelExtensions
    {
        public static Microsoft.Maui.Controls.ImageSource ToImageSource(this Interop.API.Common.Models.Display.ImageDisplayModel target)
        {
            return Microsoft.Maui.Controls.ImageSource.FromUri(new System.Uri($"{Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress}media/images/{target.Id}{target.Extension}"));
        }
    }
}
