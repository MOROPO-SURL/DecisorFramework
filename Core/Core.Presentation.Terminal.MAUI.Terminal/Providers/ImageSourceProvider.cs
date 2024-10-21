using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers
{
    public static class ImageSourceProvider
    {
        public static Microsoft.Maui.Controls.ImageSource GetByModel(Interop.API.Common.Models.Display.ImageDisplayModel model)
        {
            return Microsoft.Maui.Controls.ImageSource.FromUri(new System.Uri(string.Format("{0}media/images/{1}.{2}", Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper.ClientBaseAddress, model.Id, model.Extension)));
        }
    }
}
