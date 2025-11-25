
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Connect.Clients
{
    public class CertificationsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Certification, System.Guid, Common.Models.Input.CertificationInputModel, Common.Models.Display.CertificationDisplayModel, Common.Models.Filter.CertificationFilterModel>
    {
        public CertificationsAPIConnectClient(IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/quality/certifications";
    }
}
