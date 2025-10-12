using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class PaymentTermsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<Persistence.Entities.PaymentTerm, System.Guid, PaymentTermDisplayModel>
    {
        public PaymentTermsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/commercial/paymentterms";
    }
}
