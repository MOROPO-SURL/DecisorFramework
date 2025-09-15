using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Providers
{
    public class HttpClientHelperProvider : Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper { get; private set; }

        public HttpClientHelperProvider()
        {
#if DEBUG
            var serverBaseUri = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android ? "https://10.0.2.2:7208" : "https://localhost:7208";
#else
            var serverBaseUri = "http://cmi.gpcmg.co.cu";
#endif

            HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(new System.Net.Http.HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
            }, serverBaseUri, GetAuthorizeHeader);
        }

        private System.Collections.Generic.KeyValuePair<string, string> GetAuthorizeHeader()
        {
            var session = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession;

            if (session == null)
            {
                return new System.Collections.Generic.KeyValuePair<string, string>();
            }
            else
            {
                return new System.Collections.Generic.KeyValuePair<string, string>(session.Type, session.Token);
            }
        }
    }
}
